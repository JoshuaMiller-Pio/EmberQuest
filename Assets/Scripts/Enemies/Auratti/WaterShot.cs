using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShot : MonoBehaviour
{
    float inital, current;
    float time = 2;
    // Start is called before the first frame update
    void Start()
    {
        inital = transform.position.x;
        GetComponent<Rigidbody2D>().AddForce(-transform.right * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        BurnOut();

    }

    //after time 2 seconds fire burns off
    void BurnOut()
    {
        current = transform.position.x;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
