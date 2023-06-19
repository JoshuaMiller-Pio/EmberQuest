using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    public GameObject Arvin, Cordelia, CordeliaGenPanel, CordeliaQuestPanel, Fitsly, FitslyGenPanel, FitslyQuestPanel, ArvinCanvas, ArvinGenPanel, ArvinQuestDonePanel, CordeliaCanvas, FitzlyCanvas, Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fitsly" && Input.GetKeyDown(KeyCode.E)) 
        {
            FitzlyCanvas.gameObject.SetActive(true);
            DialogueManager.ConversationOn();
            if (DialogueManager.ArvinQuestDone)
            {
                FitslyGenPanel.gameObject.SetActive(false);
                FitslyQuestPanel.gameObject.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "Cordelia" && Input.GetKeyDown(KeyCode.E))
        {
            CordeliaCanvas.gameObject.SetActive(true);
            DialogueManager.ConversationOn();
            if (DialogueManager.gotPlants)
            {
                CordeliaGenPanel.gameObject.SetActive(false);
                CordeliaQuestPanel.gameObject.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "Arvin" && Input.GetKeyDown(KeyCode.E))
        {
            ArvinCanvas.gameObject.SetActive(true);
            DialogueManager.ConversationOn();
            if (DialogueManager.GotEvidence)
            {
                ArvinGenPanel.gameObject.SetActive(false);
                ArvinQuestDonePanel.gameObject.SetActive(true);    
            }
        }

        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
