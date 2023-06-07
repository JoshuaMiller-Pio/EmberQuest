using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Auratii : Enemy
{

    Rigidbody2D RigComp;

    public GameObject player;
    bool playerInRange = false;

    SpriteRenderer spriteRenderer;
    float movementTime = 2;
    Auratii() : base(0,50,10)
    {

    }
    private void Start()
    {
        RigComp = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        movementTime -= Time.deltaTime;
        if (!playerInRange && movementTime<= 0)
        {
            enemyRandomMovement();
        }
    }
    void enemyRandomMovement()
    {
       int move =  Random.Range(0, 2);
        float[] moveDir = new float[] { -1, 1 };
        Debug.Log(move);
        if (move > 0)
        {
           spriteRenderer.flipX = true;
        }
        else
        {
           spriteRenderer.flipX = false;

        }
            RigComp.velocity = new Vector2(moveDir[move] * 5, RigComp.velocity.y);
        movementTime = 2;
           

        
    }

    void TargetedMovement()
    {
                StartCoroutine(walk());
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
        if(collision.tag == "Player")
        {
          playerInRange = false;

        }

    }
    
    IEnumerator walk()
    {
        float time = 0;
        Vector2 targetLocationleft, CurrentLocation, targetLocationright;
        CurrentLocation = transform.position;
        targetLocationleft = new Vector2(player.transform.position.x + 4, transform.position.y);
        targetLocationright = new Vector2(player.transform.position.x - 4, transform.position.y);
        if (transform.position.x > player.transform.position.x)
        {
            while (time < 1)
            {
                transform.position = UnityEngine.Vector2.Lerp(CurrentLocation, targetLocationleft, time / 1);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetLocationleft;
            spriteRenderer.flipX = false;

        }
        else
        {
            while (time < 1)
            {
                transform.position = UnityEngine.Vector2.Lerp(CurrentLocation, targetLocationright, time / 1);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetLocationright;
            spriteRenderer.flipX = true;
        }
    }

}
