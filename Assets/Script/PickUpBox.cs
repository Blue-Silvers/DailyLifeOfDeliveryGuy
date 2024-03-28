using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    
    [SerializeField] int money;
    [SerializeField] int upgradePrice;
    [SerializeField] int healPrice;
    [SerializeField] int ammoPrice;
    [SerializeField] TextMeshProUGUI MoneyTxt;

    [SerializeField] GameObject Shop, deathScreen;

    bool gameIsPaused;
    int nbUpgrade = 1;
    [SerializeField] TextMeshProUGUI nbUpgradeTxt;
    [SerializeField] GameObject upgradeButton, interactButton;


    int RdEscape;
    private void Start()
    {
        money = 0;
        MoneyTxt.text = money.ToString();

    }

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
        if (Input.GetKey(KeyCode.E) && (other.gameObject.tag == "Ammo" || other.gameObject.tag == "Heal" || other.gameObject.tag == "Money"))
        {

                money += 10;
                MoneyTxt.text = money.ToString();

            Destroy(other.gameObject);
            Invoke("DontShowInteract", 0.1f);
        }
        else if (Input.GetKey(KeyCode.E) && other.gameObject.tag == "Upgrade")
        {

            Time.timeScale = 0f;
            Shop.SetActive(true);
        }

        if (other.gameObject.tag == "Ammo" || other.gameObject.tag == "Heal" || other.gameObject.tag == "Money" || other.gameObject.tag == "Upgrade")
        {
            interactButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ammo" || other.gameObject.tag == "Heal" || other.gameObject.tag == "Money" || other.gameObject.tag == "Upgrade")
        {
            interactButton.SetActive(false);
        }
    }

    void DontShowInteract()
    {
        interactButton.SetActive(false);
    }


    //Shop
    public void Resume()
    {
        Shop.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void BuyUpgrade()
    {
        if (money >= upgradePrice)
        {
            nbUpgrade += 1;
            money -= upgradePrice;
            MoneyTxt.text = money.ToString();

            if (nbUpgrade > 3)
            {
                upgradeButton.SetActive(false);
            }

            nbUpgradeTxt.text = nbUpgrade.ToString();
        }
    }
    public void BuyHeal()
    {
        if (money >= healPrice)
        {
            money -= healPrice;
            MoneyTxt.text = money.ToString();

        }
    }
    public void BuyAmmo()
    {
        if (money >= ammoPrice)
        {
            money -= ammoPrice;

            MoneyTxt.text = money.ToString();

        }
    }

    void Death()
    {
        deathScreen.SetActive(true);
    }
}
