using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    float SpecialFiretime = 2;
    float ultFiretime = 8;
    float BaseFiretime = 1 ;
    public bool reloadUlt, reloadMid, reloadBasic;
    
    public GameObject spawn, attack, specialAttack, ult;
    public Image imgBasic, imgMid, imgUlt;
    Renderer BasicRenderer, MidRenderer, UltRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        BasicRenderer = imgBasic.gameObject.GetComponent<Renderer>();
        MidRenderer = imgMid.gameObject.GetComponent<Renderer>();
        UltRenderer = imgUlt.gameObject.GetComponent<Renderer>();
        reloadBasic = false;
        reloadMid = false;
        reloadUlt = false;
        
    }

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

            if (Input.GetMouseButton(0) && BaseFiretime <= 0 && reloadBasic == false)
            {
                Instantiate(attack, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                BaseFiretime = 1;
                reloadBasic = true;
                StartCoroutine(ReloadBasic());
            }


            if (SpecialFiretime <= 0 && Input.GetMouseButton(1) && reloadMid == false)
            {
                Instantiate(specialAttack, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                SpecialFiretime = 2;
                reloadMid = true;
                StartCoroutine(Reloadmid());
            }


            if (Input.GetKeyDown("q") && reloadUlt == false)
            {

                Instantiate(ult, spawn.transform.position, Quaternion.AngleAxis(PlayerController.angle, Vector3.forward));
                ultFiretime = 1;
                reloadUlt = true;
                StartCoroutine(ReloadUltimate());
                
            }
        }      
    }

    public IEnumerator ReloadUltimate()
    {
       /* var norm = 1;
        var col = imgUlt.gameObject.GetComponent<Image>().material.color;
        var trans = 0.5f;
        col.a = trans;*/
       imgUlt.gameObject.SetActive(false);
        yield return new WaitForSeconds(6);
       // col.a = norm;
       imgUlt.gameObject.SetActive(true);
        reloadUlt = false;
    }

    public IEnumerator ReloadBasic()
    {
        imgBasic.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        imgBasic.gameObject.SetActive(true);
        reloadBasic = false;
    }

    public IEnumerator Reloadmid()
    {
        imgMid.gameObject.SetActive(false);
        yield return new WaitForSeconds(4);
        imgMid.gameObject.SetActive(true);
        reloadMid = false;
    }
}
