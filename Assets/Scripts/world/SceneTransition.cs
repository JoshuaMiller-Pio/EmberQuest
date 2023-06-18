using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    float time = 3f;
    bool StartTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(StartTime == true && gameObject.tag == "VillageSwitch")
       {
            time -= Time.deltaTime;
            sceneSwitchVillage();
       }
        if (StartTime == true && gameObject.tag == "CaveSwitch")
        {
            Debug.Log("enter cave");
            time -= Time.deltaTime;
            sceneCaveVillage();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            StartTime = true;
            
        }
    }
    void sceneSwitchVillage()
    {
        if(time <= 0)
        {
            GameManager.Instance.VilliageTrans();

        }
        
    }
    void sceneCaveVillage()
    {
        if (time <= 0)
        {
            GameManager.Instance.CaveTrans();

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        StartTime = false;
        time = 3f;
    }
  
}
