using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject plant, document;
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
    }
}
