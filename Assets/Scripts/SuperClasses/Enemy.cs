using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy:MonoBehaviour
{
    enum enemytypes { Auratii, bird };
    float health, damage;
    bool playerInRange = false;
    float movementTime = 2;
    SpriteRenderer spriteRenderer;
    CircleCollider2D feeler;
    int move;
    Rigidbody2D RigComp;
    public GameObject player, feelers;
    public LayerMask wall;
    bool attackRange = false;
    States CurrentState;
    enum States {Patrol, Attack, Chase}



    #region Properties
    public float Health 
    {
        get { return health; }
        set { health = value; }
    }
    public float Damage 
    {
        get { return damage; }
        set { damage = value; }
    }
    public Enemy(int EnemyType, float health, float damage)
    {
        Health = health;
        Damage = damage;
    }
    #endregion





    private void Awake()
    {
        RigComp = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        feeler = feelers.GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        movementTime -= Time.deltaTime;
        SpriteOrientation();
        Debug.Log(attackRange);
        if (!playerInRange && movementTime <= 0 && (CurrentState == States.Patrol))
        {
            enemyRandomMovement();
        }
    }

    #region Movement
    void enemyRandomMovement()
    {
         move = UnityEngine.Random.Range(0, 2);
        float[] moveDir = new float[] { -1, 1 };
        RigComp.velocity = new Vector2(moveDir[move] * 5, RigComp.velocity.y);
        movementTime = 2;



    }
    void TargetedMovement()
    {
        CurrentState = States.Chase;
        StartCoroutine(walk());
    }

    void SpriteOrientation()
    {
        if (move > 0)
        {
            spriteRenderer.flipX = true;
            feeler.offset = new Vector2(5, feeler.offset.y);
        }
        else
        {
            spriteRenderer.flipX = false;
            feeler.offset = new Vector2(0, feeler.offset.y);

        }
    }
    IEnumerator walk()
    {
        float time = 0;
        
        Vector2 targetLocationleft, CurrentLocation, targetLocationright;
        while (!attackRange)
        {
            CurrentLocation = transform.position;
        targetLocationleft = new Vector2(player.transform.position.x + 4, transform.position.y);
        targetLocationright = new Vector2(player.transform.position.x - 4, transform.position.y);
        
            if (transform.position.x >= player.transform.position.x && !isagainstwall("right"))
            {
                move = -1;
                while (time < 1)
                {
                    RigComp.MovePosition(UnityEngine.Vector2.Lerp(CurrentLocation, targetLocationleft, time / 1.5f));
                    time += Time.deltaTime;
                    yield return null;
                }
                transform.position = targetLocationleft;

            }
            else if (transform.position.x <= player.transform.position.x && !isagainstwall("left"))
            {
                move = 1;

                while (time < 1)
                {
                    RigComp.MovePosition(UnityEngine.Vector2.Lerp(CurrentLocation, targetLocationright, time / 1.5f));

                    time += Time.deltaTime;
                    yield return null;
                }
                transform.position = targetLocationright;
            }

            if((transform.position.x > player.transform.position.x + 1 && transform.position.x < player.transform.position.x + 5) || (transform.position.x < player.transform.position.x - 1 && transform.position.x > player.transform.position.x - 5))
            {
                CurrentState = States.Attack;
                Attack();
                attackRange = true;
            }
            yield return null;
        }
      
    }
    #endregion

    void Attack()
    {
        while(CurrentState == States.Attack && attackRange)
        {
            //crashes
            if(!((transform.position.x > player.transform.position.x + 1 && transform.position.x < player.transform.position.x + 5) || (transform.position.x < player.transform.position.x - 1 && transform.position.x > player.transform.position.x - 5)))
            {
                attackRange = false;
                

            }

                break;

        }
    }
    

    #region BoolChecks
    bool isagainstwall(string checker)
    {
        if (Physics2D.Raycast(transform.position, -transform.right, 1f, wall) && checker == "left" )
        {
            //touching wall
            Debug.Log("wall");
            return true;

        }
        else if (Physics2D.Raycast(transform.position, transform.right, 1f, wall) && checker == "right")
        {
            Debug.Log("wall");
            return true;
        }
        //not touching wall
        return false;

    }
    #endregion

    void EnemyDeath()
    {
        Destroy(this.gameObject);
    }


    #region triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire" && gameObject.tag != "Finder")
        {
           float damage = collision.GetComponent<FireAttacks_SuperClass>().damage;
           
            health -= damage;
            
            Debug.Log(health);
            if (health <= 0)
            {
                EnemyDeath();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = true;
            TargetedMovement();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
            CurrentState = States.Patrol;
        }

    }
    #endregion
}
