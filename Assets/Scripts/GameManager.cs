using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update

    private string _PlayerName;
    public bool HasHerbs, cordFirst, arvinFirst, fitsFirst, hasDocs, arvinQuestDone, narratorFirst, inConversation, inMenu, incave;


    public int _Gold, _Health, _HealthPotions;
    private int _NumOfHerbs;


    #region Properties
    public string playerName
    {
        set { _PlayerName = value; }
        get { return _PlayerName; }
    }
    public int numOfHerbs
    {
        set { _NumOfHerbs = value; }
        get { return _NumOfHerbs;}
    }
    public int gold
    {
        set { _Gold = value; }
        get { return _Gold; }
    }
    public int health
    {
        set { _Health = value; }
        get { return _Health; }
    }
    public int healthPotions
    {
        set { _HealthPotions = value; }
        get { return _HealthPotions; }
    }

    #endregion
    void Start()
    {
        _Health = 10;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (DialogueManager.inConversation)
        {
            inConversation = true;
        }

        if (DialogueManager.inConversation == false)
        {
            inConversation = false;
        }

        if (DialogueManager.inMenu)
        {
            inMenu = true;
        }

        if (DialogueManager.inMenu == false)
        {
            inMenu = false;
        }

        if (numOfHerbs == 2 && !HasHerbs)
        {
            HasHerbs = true;
        }

        if (DialogueManager.cordFirstDone)
        {
            cordFirst = true;
        }

        if (DialogueManager.ArvinFirstDone)
        {
            arvinFirst = true;
        }

        if (DialogueManager.ArvinQuestDone)
        {
            arvinQuestDone = true;
        }

        if(DialogueManager.GotEvidence) 
        {
            hasDocs = true;
        }

        if (DialogueManager.narratorFirstDone)
        {
            narratorFirst = true;
        }
    }

    public void PlayerDead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   public void VilliageTrans()
   {
        SceneManager.LoadScene(1);
        Village_caveSpawn();
   }
   public void CaveTrans()
   {
        SceneManager.LoadScene(2);
        incave = true;
   }
    void Village_caveSpawn()
    {
        if (GameManager.Instance.incave && SceneManager.GetActiveScene().buildIndex == 2 )
        {
            GameObject cave_spawn = GameObject.FindGameObjectWithTag("CaveSwitch");
            gameObject.transform.position = cave_spawn.transform.position;

            Debug.Log("yes");
        }
    }
}
