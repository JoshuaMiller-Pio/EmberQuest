using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    private string PlayerName;
 

    #region Properties
    public string playerName
    {
        set { PlayerName = value; }
        get { return PlayerName; }
    }

    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
