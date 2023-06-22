using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool inRange = false;
    bool limiter = false;
    public GameObject document;
    
    // Start is called before the first frame update
    void Start()
    {
        document.SetActive(true);
        if (GameManager.Instance.hasDocs)
        {
            document.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange && !limiter)
        {
            pickup();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

         inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            inRange = false;
        }
    }

    private void pickup()
    {
        if (Input.GetKeyDown("e"))
        {
            limiter = true; //makes sure code only runs once
            PlayerController.play_pickup = true;
            if(gameObject.tag == "herb")
            {
             GameManager.Instance.numOfHerbs++;
             Destroy(gameObject);

            }
            else if(gameObject.tag == "page")
            {
                GameManager.Instance.hasDocs = true;
                document.SetActive(false);
            }
        }
    }
}
