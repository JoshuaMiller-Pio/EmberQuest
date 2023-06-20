using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    float SpecialFiretime = 2;
    float ultFiretime = 8;
    float BaseFiretime = 1 ;

    public GameObject spawn, attack, specialAttack, ult;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        OnButtonClick();

    }
    //left click basic attack. right click special. "Q" ult
    void OnButtonClick()
    {
        if(DialogueManager.inConversation == false && DialogueManager.inMenu == false)
        {
            SpecialFiretime -= Time.deltaTime;
            BaseFiretime -= Time.deltaTime;

            if (Input.GetMouseButton(0) && BaseFiretime <= 0)
            {
                Instantiate(attack, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                BaseFiretime = 1;
            }


            if (SpecialFiretime <= 0 && Input.GetMouseButton(1))
            {
                Instantiate(specialAttack, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                SpecialFiretime = 2;

            }


            if (Input.GetKeyDown("q"))
            {

                Instantiate(ult, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                ultFiretime = 1;

            }
        }      
    }
}
