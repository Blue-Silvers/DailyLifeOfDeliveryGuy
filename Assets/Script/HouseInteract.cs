using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.MaterialProperty;
using static UnityEditor.Progress;

public class HouseInteract : MonoBehaviour
{

    [SerializeField] GameObject interactButton, dialogBox;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            dialogBox.SetActive(true);
        }
        interactButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interactButton.SetActive(false);
    }
}
