using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CallToDelievery : MonoBehaviour
{
    int rdCall;
    bool doIt;

    [SerializeField] bool house1, house2;

    TextMeshPro theOrder1, theOrder2;
    string order1, order2;

    [SerializeField] GameObject houseLocate1, houseBox1, houseLocate2, houseBox2;

    string[] shopNeedToGo = new string[] { "Fried Chicken", "Pizza", "Fast Food", "Coffee" };
    // Start is called before the first frame update
    void Start()
    {
        houseLocate1.SetActive(false);
        houseLocate2.SetActive(false);
        houseBox1.SetActive(false);
        houseBox2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            rdCall = Random.Range(0, 10000);
            if (rdCall < 5)
            {
                HouseToDeliever();
                doIt = true;
            }
        }

        if (house1 == true)
        {
            theOrder1 = GameObject.Find("TextHouse1").GetComponent<TextMeshPro>();
            if (theOrder1 != null)
            {
                theOrder1.text = order1;
            }
            houseLocate1.SetActive(true);
            houseBox1.SetActive(true );
        }
        else
        {
            theOrder1 = GameObject.Find("TextHouse1").GetComponent<TextMeshPro>();
            if (theOrder1 != null)
            {
                theOrder1.text = "Nothing";
            }
        }
        if (house2 == true)
        {
            theOrder2 = GameObject.Find("TextHouse2").GetComponent<TextMeshPro>();
            if (theOrder2 != null)
            {
                theOrder2.text = order2;
            }
            houseLocate2.SetActive(true);
            houseBox2.SetActive(true);
        }
        else
        {
            theOrder2 = GameObject.Find("TextHouse2").GetComponent<TextMeshPro>();
                if (theOrder2 != null)
                {
                    theOrder2.text = "Nothing";
                }
        }
    }

    private void HouseToDeliever()
    {
        if(house1 == true && house2 == false)
        {
            order2 = shopNeedToGo[Random.Range(0, shopNeedToGo.Length)];

            house2 = true;
        }
        else if(house2 == true && house1 == false) 
        {

            order1 = shopNeedToGo[Random.Range(0, shopNeedToGo.Length)];

            house1 = true;
        }
        else if (house1 == false && house2 == false)
        {
            int htd = Random.Range(0, 2);
            if (htd == 1)
            {
                order1 = shopNeedToGo[Random.Range(0, shopNeedToGo.Length)];

                house1 = true;
            }
            else
            {
                order2 = shopNeedToGo[Random.Range(0, shopNeedToGo.Length)];

                house2 = true;
            }
        }
    }
}
