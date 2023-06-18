using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{
    bool inRange = false;
    bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange && !hasRun)
        {
            pickup();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("range");
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
            hasRun = true;
            GameManager.Instance.numOfHerbs++;
            Destroy(gameObject);
        }
    }
}
