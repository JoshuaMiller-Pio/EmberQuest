using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    float SpecialFiretime = 2 ;
    float ultFiretime = 1 ;
    float BaseFiretime = 1 ;
    public GameObject spawn, attack, specialAttack, ult;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        OnButtonClick();

    }
    void OnButtonClick()
    {
        SpecialFiretime -= Time.deltaTime;
        BaseFiretime -= Time.deltaTime;
        
            if (Input.GetMouseButton(0) && BaseFiretime <= 0)
            {
                BaseFiretime = 1;
                Instantiate(attack, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
            }
           

            if(SpecialFiretime <= 0 && Input.GetMouseButton(1))
            {
                Instantiate(specialAttack, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                SpecialFiretime = 2;

            }


            if ( Input.GetKeyDown("q"))
            {

                Instantiate(ult, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                ultFiretime = 1;

            }

        

            
    }
}
