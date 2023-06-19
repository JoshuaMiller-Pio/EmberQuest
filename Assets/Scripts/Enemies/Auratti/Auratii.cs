using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Auratii : Enemy
{
    GameObject player;
    public GameObject arm, torso , feeler, bullet_Spawner, bullet;
    bool againstwall;
    
    float timer = 2;
    float debugtimer = 3;
    AIstate state;
     Vector2 target;
    float distance, DistToTarget;
    float speed = 3f;
    Rigidbody2D RigComp;


    Auratii() : base(50, 2)
    {

    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        state = AIstate.patrol;
        RigComp = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        debugtimer -= Time.deltaTime;
        if(debugtimer <= 0 || state == AIstate.chase)
        {
            Debug.Log(state);
            debugtimer = 1;
        }

        DistToTarget = transform.position.x - player.transform.position.x;
        timer -= Time.deltaTime;
        if(Health <= 0)
        {
            EnemyDeath();

        }

        if (timer <= 0 && state == AIstate.patrol)
        {
            PatrolMovement();
            SpriteOrientation();
            timer = 2;
        }
        if (state == AIstate.chase)
        {
            ChaseMovement();
        }

        if(DistToTarget == 3 || DistToTarget == -3)
        {
            state = AIstate.attack;
      
            Attack();
        }
        else if ((DistToTarget > 3 || DistToTarget < -3) && state == AIstate.attack )
        {
            state = AIstate.patrol;
        }

    }

    void PatrolMovement()
    {
        distance =  Random.Range(-2, 3);
        RigComp.velocity = new Vector2(distance * speed, RigComp.velocity.y);
    }

    void ChaseMovement()
    {
        target = new Vector2(player.transform.position.x + 3, transform.position.y);
        
            StartCoroutine(ChaseLerp(target));

        
    }


    IEnumerator ChaseLerp(Vector2 TargetPos)
    {
        if (!againstwall)
        {
            float time = 0;
            UnityEngine.Vector3 CurrentPos = transform.position;

            while (time < 1)
            {
                transform.position = UnityEngine.Vector2.Lerp(CurrentPos, TargetPos, time / 1);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = TargetPos;
        }
        else if(againstwall)
        {
            state = AIstate.patrol;
        }
       
    }

    void Attack()
    {
        Instantiate(bullet, bullet_Spawner.transform);
    }

    void SpriteOrientation()
    {
        if(distance >= 0)
        {
            arm.GetComponent<SpriteRenderer>().flipY = true;
            arm.transform.rotation = Quaternion.Euler(0, 0, 180);
            torso.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            arm.GetComponent<SpriteRenderer>().flipY = false;
            arm.transform.rotation = Quaternion.Euler(0, 0, 0);
            torso.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fire" )
        {
            FireAttacks_SuperClass attack = collision.gameObject.GetComponent <FireAttacks_SuperClass > ();
            Health -= attack.damage;
        }

        if(collision.gameObject.tag == "Player")
        {
            state = AIstate.chase;
        } 
        if(collision.gameObject.tag == "ground")
        {
            againstwall = true;
        }

    }
}

 

