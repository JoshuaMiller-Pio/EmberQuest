using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy:MonoBehaviour
{
    float health, damage;
    public LayerMask wall;
    public AudioSource Walk, shoot, Takedamage;
    public enum AIstate { patrol = 0 , chase = 1, attack = 2 }



    #region Properties
    public float Health 
    {
        get { return health; }
        set { health = value; }
    }
    public  float Damage 
    {
        get { return damage; }
        set { damage = value; }
    }
    public  Enemy(float health, float damage)
    {
        Health = health;
        Damage = damage;
    }
    #endregion

    private void Awake()
    {

    }

    private void Update()
    {

    }








    public void EnemyDeath()
    {
        Destroy(this.gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "fire")
        {
            health--;
        }
      
    }



   public void PlayShoot()
    {
        shoot.Play();
    }
   public void PlayTakeDamage()
    {
        Takedamage.Play();
    }
}
