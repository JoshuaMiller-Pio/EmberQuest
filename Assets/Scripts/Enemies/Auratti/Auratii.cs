using Mono.Cecil;
using System;
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
    
    float timer = 2;
    float ShootCooldown = 1;
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

        ShootCooldown -= Time.deltaTime;
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

            Debug.Log(state);
            Debug.Log(DistToTarget);
        if(DistToTarget <= 4 && DistToTarget >= -4)
        {

            state = AIstate.attack;
            if(ShootCooldown <= 0)
            {
                Attack();
                ShootCooldown = 2;
            }
        }
        else if ((DistToTarget > 10 || DistToTarget < -10) && state == AIstate.attack)
        {
            state = AIstate.patrol;
        }
        else
        {
            state = AIstate.chase;
        }

    }

    void PatrolMovement()
    {
        distance =  UnityEngine.Random.Range(-2, 3);
        RigComp.velocity = new Vector2(distance * speed, RigComp.velocity.y);
    }

    void ChaseMovement()
    {
        target = new Vector2(player.transform.position.x + 3, transform.position.y);
        
            StartCoroutine(ChaseLerp(target));

        
    }


    IEnumerator ChaseLerp(Vector2 TargetPos)
    {
        if (!feelers.againstwall)
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
        else if(feelers.againstwall)
        {
            state = AIstate.patrol;
        }
       
    }

    void Attack()
    {

        Instantiate(bullet, bullet_Spawner.transform.position, Quaternion.identity);
        PlayShoot();
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
            PlayTakeDamage();
        }

        if(collision.gameObject.tag == "Player")
        {
            state = AIstate.chase;
        } 
       

    }
}

 

