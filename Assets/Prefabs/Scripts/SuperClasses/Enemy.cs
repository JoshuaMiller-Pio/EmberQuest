using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy:MonoBehaviour
{
    enum enemytypes { Auratii, bird };
    float health, damage;
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
}
