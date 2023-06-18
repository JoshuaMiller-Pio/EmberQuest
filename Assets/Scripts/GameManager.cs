using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    private string _PlayerName;
    public bool HasHerbs;

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

    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfHerbs == 2 && !HasHerbs)
        {
            HasHerbs = true;
        }
    }

    public void PlayerDead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   public void VilliageTrans()
   {
        SceneManager.LoadScene(1);
   }
   public void CaveTrans()
   {
        SceneManager.LoadScene(2);
   }
}
