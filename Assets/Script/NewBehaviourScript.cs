using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] int firstItemPrice;
    [SerializeField] int secondItemPrice;
    [SerializeField] int thirdItemPrice;

    int money;
    [SerializeField] GameObject Shop;

    [SerializeField] GameObject interactButton;
    bool gameIsPaused;


    int RdEscape;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Shop.SetActive(true);
        }
        interactButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Shop.SetActive(false);
        interactButton.SetActive(false);
    }


    //Shop
    public void Resume()
    {
        Shop.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void BuyFirstItem()
    {
        if (money >= firstItemPrice)
        {
            money -= firstItemPrice;
        }
    }
    public void BuySecondItem()
    {
        if (money >= secondItemPrice)
        {
            money -= secondItemPrice;

        }
    }
    public void BuyThirdItem()
    {
        if (money >= thirdItemPrice)
        {
            money -= thirdItemPrice;

        }
    }

}
