using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text goldUI;
    public Image healthBar, potion, potion1, potion2;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGoldUI();
        UpdatePotionsUI();
    }

    public void UpdateGoldUI()
    {
        goldUI.text = GameManager.Instance.gold.ToString();
    }

    public void UpdatePotionsUI()
    {
        if(GameManager.Instance.healthPotions == 0)
        {
            potion.gameObject.SetActive(false);
            potion1.gameObject.SetActive(false);
            potion2.gameObject.SetActive(false);
        }

        if (GameManager.Instance.healthPotions == 1)
        {
            potion.gameObject.SetActive(true);
            potion1.gameObject.SetActive(false);
            potion2.gameObject.SetActive(false);
        }

        if (GameManager.Instance.healthPotions == 2)
        {
            potion.gameObject.SetActive(true);
            potion1.gameObject.SetActive(true);
            potion2.gameObject.SetActive(false);
        }

        if (GameManager.Instance.healthPotions == 2)
        {
            potion.gameObject.SetActive(true);
            potion1.gameObject.SetActive(true);
            potion2.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
