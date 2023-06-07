using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigComp;
    BoxCollider2D CollComp;
    public GameObject legs, torso,arm;
    public LayerMask ground;
    public static float angle;
    SpriteRenderer torsoRend;
    public bool inConversation;
    // Start is called before the first frame update
    void Start()
    {
        rigComp = GetComponent<Rigidbody2D>();
        CollComp = GetComponent<BoxCollider2D>();
        colorchange();
        torsoRend = torso.GetComponent<SpriteRenderer>();
        inConversation = false;
    }

    // Update is called once per frame
    void Update()
    {
        onKeyDown();
        MouseMovement();
 
    }

    void onKeyDown()
    {
        if(inConversation == false)
        {
            float DirX = Input.GetAxis("Horizontal");

            //jump
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rigComp.velocity = new Vector2(rigComp.velocity.x, 5f);
            }
            //left  and right movement
            rigComp.velocity = new Vector2((DirX * 5f), rigComp.velocity.y);
            if (DirX < 0)
            {
                legs.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (DirX > 0)
            {
                legs.GetComponent<SpriteRenderer>().flipX = false;

            }
        }
        
    }

    void MouseMovement()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle, Vector3.forward);
        arm.transform.rotation = Quaternion.Slerp(arm.transform.rotation, rotate, 10 * Time.deltaTime);
        if (angle >= 100 || angle <= -100)
        {
            torso.GetComponent<SpriteRenderer>().flipX = true;
            arm.GetComponent<SpriteRenderer>().flipY = true;
            arm.transform.localPosition = new Vector2(-0.115f, -0.17f);
        }
        else
        {
            torso.GetComponent<SpriteRenderer>().flipX = false;
            arm.GetComponent<SpriteRenderer>().flipY = false;
            arm.transform.localPosition = new Vector2(  0.141f, -0.17f);

        }
    }

    public void ConversationOn()
    {
        inConversation = true; 
        
    }

    public void ConversationOff()
    {
        inConversation = false; 
        
    }

    public bool IsInConversation() 
    { 
        return inConversation; 
    }
    bool isGrounded()
    {
        
        return Physics2D.Raycast(transform.position, -transform.up, 1f, ground);
         
    }
    

    void colorchange()
    {
        Debug.Log("colour change");
        torsoRend.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time * 10, 1));
    }
}
