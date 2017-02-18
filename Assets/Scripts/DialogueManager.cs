using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;
    public bool dialogueActive;
    public string[] dialogueLines;
    public int currentLine;

    private PlayerController playerController;
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueActive = false;
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyUp(KeyCode.Space)) 
        {
            currentLine++;
        }

        if(currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
            playerController.canMove = true;
        }

        dText.text = dialogueLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
        playerController.gameObject.GetComponent<Animator>().SetBool("Attack", false);
        playerController.canMove = false;
    }
}