using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject cam;
    private void Start()
    {
        cam.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            if(cam.activeSelf)
            {
                cam.SetActive(false);
            }
            else
            {
                cam.SetActive(true);
            }
        }
    }
}
