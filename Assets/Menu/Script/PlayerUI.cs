using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [Header("life")]
    [SerializeField] GameObject lifePoint1;
    [SerializeField] GameObject lifePoint2;
    [SerializeField] GameObject lifePoint3;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] int actualLife;

    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    void Update()
    {

        if (actualLife == 0)
        {
            lifePoint1.SetActive(false);
            lifePoint2.SetActive(false);
            lifePoint3.SetActive(false);
            gameOverScreen.SetActive(true);
        }
        else if (actualLife == 1)
        {
            lifePoint1.SetActive(true);
            lifePoint2.SetActive(false);
            lifePoint3.SetActive(false);
        }
        else if (actualLife == 2)
        {
            lifePoint1.SetActive(true);
            lifePoint2.SetActive(true);
            lifePoint3.SetActive(false);
        }
        else if (actualLife == 3)
        {
            lifePoint1.SetActive(true);
            lifePoint2.SetActive(true);
            lifePoint3.SetActive(true);
        }
    }


    public void SetLife(int life)
    {
        actualLife = life;
    }
}
