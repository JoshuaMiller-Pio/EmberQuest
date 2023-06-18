using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public TMP_InputField input;
    public TMP_Text[] playerNameSlots = new TMP_Text[11];
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public  void AddName() 
    {
        GameManager.Instance.playerName = input.text.ToString();

    }

    public  void UpdateName()
    {
        foreach (var slot in playerNameSlots) 
        {
            slot.text = input.text.ToString();
        }
    }
}
