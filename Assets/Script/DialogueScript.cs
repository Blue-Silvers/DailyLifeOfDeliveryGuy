using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;
    [SerializeField] GameObject colliderBox, icone;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textcomponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textcomponent.text = lines[index];
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length-1) 
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            PickUpBox.instance.money += 50;
            icone.SetActive(false);
            colliderBox.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
