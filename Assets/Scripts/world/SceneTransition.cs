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
       if(StartTime == true)
       {
            time -= Time.deltaTime;
            sceneSwitch();
       }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartTime = true;
            
        }
    }
    void sceneSwitch()
    {
        if(time <= 0)
        {
            GameManager.Instance.VilliageTrans();

        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        StartTime = false;
        time = 3f;
    }
  
}
