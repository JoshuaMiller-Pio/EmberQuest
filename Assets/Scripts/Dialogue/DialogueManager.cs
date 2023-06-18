using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public static bool cordFirstDone, ArvinFirstDone ,gotPlants, ArvinQuestDone, GotEvidence, inConversation, inMenu, fitsFirstDone, narratorFirstDone;
    // Start is called before the first frame update
    [SerializeField]
    void Start()
    {
        cordFirstDone = false;
        ArvinFirstDone = false;
        gotPlants = false;
        GotEvidence = false;
        ArvinQuestDone = false;
        inConversation = true;
        inMenu = false;
        narratorFirstDone = false;
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

    public void NarratorFirstDone()
    {
        narratorFirstDone = true;

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
        if (GameManager.Instance.HasHerbs && !gotPlants) 
        {
            gotPlants = GameManager.Instance.HasHerbs;
        }

        if (GameManager.Instance.hasDocs && !GotEvidence)
        {
            GotEvidence = GameManager.Instance.hasDocs;
        }

        if (GameManager.Instance.arvinFirst && !ArvinFirstDone)
        {
            ArvinFirstDone = GameManager.Instance.arvinFirst;
        }

        if (GameManager.Instance.arvinQuestDone && !ArvinQuestDone)
        {
            ArvinFirstDone = GameManager.Instance.arvinFirst;
        }

        if (GameManager.Instance.fitsFirst && !fitsFirstDone)
        {
            fitsFirstDone = GameManager.Instance.fitsFirst;
        }

        if (GameManager.Instance.cordFirst && !cordFirstDone)
        {
            cordFirstDone = GameManager.Instance.cordFirst;
        }

        if (GameManager.Instance.narratorFirst && !narratorFirstDone)
        {
            narratorFirstDone = GameManager.Instance.narratorFirst;
        }
    }
   
}
