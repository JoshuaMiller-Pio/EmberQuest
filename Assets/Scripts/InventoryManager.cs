using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject plant, document, journalCordText, journalArvinText;
    public TMP_Text plantCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.hasDocs)
        {
            document.SetActive(true);
        }
        if (GameManager.Instance.numOfHerbs >= 1)
        {
            plant.SetActive(true);
            plantCount.text = "X " + GameManager.Instance.numOfHerbs.ToString();
        }
        if (GameManager.Instance.cordFirst)
        {
            journalCordText.SetActive(true);
        }
        if (GameManager.Instance.arvinFirst)
        {
            journalArvinText.SetActive(true);
        }
    }
}
