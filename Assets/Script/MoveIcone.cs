using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveIcone : MonoBehaviour
{
    GameObject[] player;
    GameObject thePlayer;

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
            //float newAngle = thePlayer.transform.rotation.eulerAngles.y;
            //transform.rotation = Quaternion.Euler(90, newAngle, 0);
        }
    }
}
