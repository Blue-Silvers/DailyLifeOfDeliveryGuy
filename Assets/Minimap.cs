using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    GameObject[] player;
    GameObject thePlayer;
    [SerializeField] Image playerIcon;


    void Update()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject gameObjectPlayer in player)
        {
            thePlayer = gameObjectPlayer as GameObject;
        }

        if (thePlayer != null)
        {
            transform.position = new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z);
            float newAngle = thePlayer.transform.rotation.eulerAngles.y;
            playerIcon.rectTransform.localRotation = Quaternion.Euler(0, 0, -newAngle);
        }
    }
}
