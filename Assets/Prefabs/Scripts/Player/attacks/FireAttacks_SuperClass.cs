using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttacks_SuperClass : MonoBehaviour
{
    float Damage,FizzleDistance;
    float time,initial;
    bool PassThru;
    #region accessors and mutators
    public float damage
    {
        set { Damage = value;} get { return Damage; }
    }
    public float fizzleDistance
    {
        set { FizzleDistance = value; } get { return FizzleDistance; }
    }
    #endregion

    public FireAttacks_SuperClass(float damage, float fizzleDist, bool passThru)
    {
        this.damage = damage;
        this.fizzleDistance = fizzleDist;
        PassThru = passThru;
        time = fizzleDist;
    }
    public void Start()
    {
        initial = transform.position.x;
        GetComponent<Rigidbody2D>().AddForce(transform.right * 10, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
      
    }
   public  void fizzleCalc()
   {
        fizzleDistance -= Time.deltaTime;
        if (fizzleDistance <= 0)
        {
            Extinguish();
        }
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!(collision.tag == "Player" || collision.tag == "Finder" || collision.tag == "fire") && !PassThru )
        {
            Extinguish();
            Debug.Log(collision.gameObject.tag);
        }
    }
    void Extinguish()
    {
        
        GameObject.Destroy(this.gameObject);
    }
}
