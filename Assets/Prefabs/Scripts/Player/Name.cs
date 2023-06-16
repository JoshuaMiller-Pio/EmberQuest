using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public TMP_InputField input;
    public Button confirm;
    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(AddName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public  void AddName() 
    {
        Debug.Log(input.text.ToString());
        GameManager.Instance.name = input.text.ToString();

    }
}
