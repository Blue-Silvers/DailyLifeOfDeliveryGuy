using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    public int firstItemPricePUB;
    public int secondItemPricePUB;
    public int thirdItemPricePUB;
    public int money;
    [SerializeField] TextMeshProUGUI MoneyTxt;
    public static PickUpBox instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        money = 20;
        MoneyTxt.text = money.ToString();

    }

    private void Update()
    {
        MoneyTxt.text = money.ToString();
    }



    //Shop

    public void BuyFirstItem()
    {
        if (money >= firstItemPricePUB)
        {
            money -= firstItemPricePUB;
        }
    }
    public void BuySecondItem()
    {
        if (money >= secondItemPricePUB)
        {
            money -= secondItemPricePUB;
        }
    }
    public void BuyThirdItem()
    {
        if (money >= thirdItemPricePUB)
        {
            money -= thirdItemPricePUB;
        }
    }


}
