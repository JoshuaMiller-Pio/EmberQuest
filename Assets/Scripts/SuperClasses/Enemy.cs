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
        //SpriteOrientation();

        if (true)//fix
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

    //commented out
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
        yield return null;
    }
    #endregion

    void Attack()
    {

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
        if(collision.tag == "fire")
        {
            health--;
        }
    }
    #endregion
}
