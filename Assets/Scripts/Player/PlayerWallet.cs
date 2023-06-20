using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = GameManager.Instance.gold;
    }

    public void AddGold()
    {
        gold = gold + 500;
        GameManager.Instance.gold = gold;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
