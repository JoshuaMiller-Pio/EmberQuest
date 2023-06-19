using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.WSA;

public class ArmRotation : MonoBehaviour
{
    public GameObject arm, torso,Player;
    float angle;
    bool inRange;
    CapsuleCollider2D aim;
    // Start is called before the first frame update
    private void Awake()
    {
        aim = arm.GetComponent<CapsuleCollider2D>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            TargetLocking();
        }
    }

   void  TargetLocking()
    {
        Vector2 direction = transform.position - Player.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle, Vector3.forward);
        arm.transform.rotation = Quaternion.Slerp(arm.transform.rotation, rotate, 10 * Time.deltaTime);
        if (angle >= 100 || angle <= -100)
        {
            torso.GetComponent<SpriteRenderer>().flipX = true;
            arm.GetComponent<SpriteRenderer>().flipY = true;
            aim.offset.Set(-37.12582f, 2.341053f);
        }
        else
        {
            torso.GetComponent<SpriteRenderer>().flipX = false;
            arm.GetComponent<SpriteRenderer>().flipY = false;
            aim.offset.Set(-27.79f, 2.341053f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
         if(collision.tag == "Player")
         {
            inRange = false;
         }
    }
}
