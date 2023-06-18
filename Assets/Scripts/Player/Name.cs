using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public TMP_InputField input;
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
}
