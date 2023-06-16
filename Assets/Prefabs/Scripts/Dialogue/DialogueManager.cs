using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool cordFirstDone;
    public bool ArvinFirstDone;
    public bool gotPlants;
    public bool ArvinQuestDone;
    public bool GotEvidence;
    public bool inConversation;
    public bool inMenu;
    // Start is called before the first frame update
    void Start()
    {
        cordFirstDone = false;
        ArvinFirstDone = false;
        gotPlants = false;
        GotEvidence = false;
        ArvinQuestDone = false;
        inConversation = true;
        inMenu = false;
    }

    #region Get Bools
    public bool CheckCord()
    {
        return cordFirstDone;
    }

    public bool CheckArvin()
    {
        return ArvinFirstDone;
    }

    public bool CheckPlants()
    {
        return gotPlants;
    }

    public bool CheckGotEvidence() 
    {
        return GotEvidence;
    }

    public bool CheckArvinQuest()
    {
        return ArvinQuestDone;
    }


    public bool CheckInConversation()
    {
        return inConversation;
    }

    public bool CheckInMenu()
    {
        return inMenu;
    }
    #endregion

    #region Set Bools
    public void ChatWithCord()
    {
        cordFirstDone=true;
    }

    public void ChatWithArvin() 
    {
        ArvinFirstDone = true;
    }

    public void ChatWithPlants() 
    {
        gotPlants=true; 
    }

    public void FoundEvidence()
    {
        GotEvidence=true;
    }

    public void FinishedArvin()
    {
        ArvinQuestDone=true;
    }

    public void ConversationOn()
    {
        inConversation = true;

    }

    public void InMenuOn()
    {
        inMenu = true;

    }

    public void ConversationOff()
    {
        inConversation = false;

    }

    public void InMenuOff()
    {
        inMenu = false;

    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        
    }
   
}
