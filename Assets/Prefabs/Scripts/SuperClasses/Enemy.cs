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
    Rigidbody2D RigComp;
    public GameObject player, feelers;
    public LayerMask wall;

    States CurrentState;
    enum States {Patrol, Attack, Search}



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
    }

    private void Update()
    {
        movementTime -= Time.deltaTime;
        if (!playerInRange && movementTime <= 0 && (CurrentState == States.Patrol))
        {
            enemyRandomMovement();
        }
    }

    #region Movement
    void enemyRandomMovement()
    {
        int move = UnityEngine.Random.Range(0, 2);
        float[] moveDir = new float[] { -1, 1 };
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
        RigComp.velocity = new Vector2(moveDir[move] * 5, RigComp.velocity.y);
        movementTime = 2;



    }
    void TargetedMovement()
    {
        StartCoroutine(walk());
        CurrentState = States.Search;
    }

    IEnumerator walk()
    {
        float time = 0;
        bool attackRange = false;
        Vector2 targetLocationleft, CurrentLocation, targetLocationright;
        CurrentLocation = transform.position;
        targetLocationleft = new Vector2(player.transform.position.x + 4, transform.position.y);
        targetLocationright = new Vector2(player.transform.position.x - 4, transform.position.y);
        while(!attackRange)
        {
            if (transform.position.x >= player.transform.position.x && !isagainstwall("right"))
            {
                spriteRenderer.flipX = false;
                while (time < 1)
                {
                    RigComp.MovePosition(UnityEngine.Vector2.Lerp(CurrentLocation, targetLocationleft, time / 1));
                    time += Time.deltaTime;
                    yield return null;
                }
                transform.position = targetLocationleft;

            }
            else if (transform.position.x <= player.transform.position.x && !isagainstwall("left"))
            {
                spriteRenderer.flipX = true;
                while (time < 1)
                {
                    RigComp.MovePosition(UnityEngine.Vector2.Lerp(CurrentLocation, targetLocationright, time / 1));

                    time += Time.deltaTime;
                    yield return null;
                }
                transform.position = targetLocationright;
            }

            /*if(transform.position > 1 && transform.position < 5)
            {

            }*/
        }
      
    }
    #endregion



    #region BoolChecks
    bool isagainstwall(string checker)
    {
        if (Physics2D.Raycast(transform.position, -transform.right, 1f, wall) && checker == "left"/*left*/ )
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



    #region triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
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

        }

    }
    #endregion
}
