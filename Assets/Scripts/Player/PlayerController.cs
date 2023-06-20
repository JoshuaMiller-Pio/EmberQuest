using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigComp;
    BoxCollider2D CollComp;
    public static bool play_pickup;
    public GameObject legs, torso,arm, caveSpawn;
    public LayerMask ground;
    public static float angle;
    SpriteRenderer torsoRend;
    public bool inConversation, Spawnned;
    float DirX;
    private Animator LegAniComp;
    public GameObject NarratorCanvas;
    float Health, initialHealth;
    float scenetrans = 5;
    public AudioSource walk, pickup, jump, damage;
    bool iswalking, playonce = false;
    #region Properties

    public float health
    {
        set { Health = value; }
        get { return Health; }
    }


    #endregion

    private void Awake()
    {
        LegAniComp = legs.GetComponent<Animator>();
        rigComp = GetComponent<Rigidbody2D>();
        CollComp = GetComponent<BoxCollider2D>();
        torsoRend = torso.GetComponent<SpriteRenderer>();
        inConversation = false;
        Spawnned = false;
        caveSpawn = GameObject.FindGameObjectWithTag("CaveSwitch");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.incave)
        {
         gameObject.transform.position = caveSpawn.transform.position;

        }
        health = 10;
        initialHealth = health;
        if(GameManager.Instance.narratorFirst == false)
        {
            NarratorCanvas.gameObject.SetActive(true);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
        onKeyDown();
        MouseMovement();
        if (Input.GetKey(KeyCode.R))
        {
            TakeHealthPotion();
        }
        if (play_pickup)
        {
            playPickup();
            play_pickup = false;
        }

        if (iswalking && !playonce)
        {
            playWalk();
            playonce = true;
        }

    }

    #region movement

    //detects key press and moves the player
    void onKeyDown()
    {
        if(GameManager.Instance.inConversation == false && GameManager.Instance.inMenu == false)
        {
             DirX = Input.GetAxis("Horizontal");

            //jump
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rigComp.velocity = new Vector2(rigComp.velocity.x, 5f);
                playJump();
            }
            //left  and right movement
            rigComp.velocity = new Vector2((DirX * 5f), rigComp.velocity.y);
            if (DirX < 0)
            {
                isWalking();
                legs.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (DirX > 0)
            {
                isWalking();
                legs.GetComponent<SpriteRenderer>().flipX = false;

            }
            else
            {
                isIdle();
            }

        }
        
    }
    #endregion

    void isDead()
    {
        GameManager.Instance.PlayerDead();
    }

  public void TakeHealthPotion()
    {
        if (GameManager.Instance._HealthPotions >= 1) 
        {
            GameManager.Instance._HealthPotions--;
            GameManager.Instance.health = GameManager.Instance.maxHealth;
        }
    }
    public void AddHealthPotion()
    {
       
            GameManager.Instance._HealthPotions++;      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
           // Auratii attack = collision.gameObject.GetComponent<Auratii>();
             Health -= 2;
            playDamage();
            if (health <= 0)
            {
                isDead();
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Death")
        {
            isDead();
        }
    }


    #region Mouse Detection
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
    #endregion


    #region bool checks 
    bool isGrounded()
    {
        
        return Physics2D.Raycast(transform.position, -transform.up, 1.5f, ground);
         
    }
    #endregion



    #region AnimationCalls
    void isWalking()
    {
        LegAniComp.SetBool("isWalking", true);
        iswalking = true;
    }
    void isIdle()
    {

        LegAniComp.SetBool("isWalking", false);
        iswalking = false;
        pauseWalk();
    }
    #endregion

    #region Audio
    void playWalk()
    {
        walk.Play();
    }
    void pauseWalk()
    {
        walk.Pause();
        playonce = false;

    }
    void playPickup()
    {
        pickup.Play();
    }
    void playDamage()
    {
        damage.Play();
    }
    void playJump()
    {
        pauseWalk();
        jump.Play();
    } 

    #endregion
}
