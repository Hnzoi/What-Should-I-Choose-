using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Reference to TextMeshPro component
    public List<string> dialogues; // List of dialogue lines
    public List<Canvas> dialogueCanvases; // List of canvases for each type of dialogue
    public float typingSpeed = 0.05f; // Delay between each character
    private int currentLine = 0; // Track the current line in the dialogue
    private int currentCanvasIndex = 0; // Track the current canvas in the sequence
    private bool isTyping; // Track if the typewriter effect is currently typing

    void Start()
    {
        // Ensure only the first canvas is active at start
        for (int i = 0; i < dialogueCanvases.Count; i++)
        {
            dialogueCanvases[i].gameObject.SetActive(i == 0);
        }
        ShowNextDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogues[currentLine];
                isTyping = false;
            }
            else
            {
                currentLine++;
                ShowNextDialogue();
            }
        }
    }

    void ShowNextDialogue()
    {
        if (currentLine < dialogues.Count)
        {
            StartCoroutine(TypeMessage(dialogues[currentLine]));
        }
        else
        {
            // Move to the next canvas if there is one, or end dialogue if all canvases are shown
            currentLine = 0; // Reset for the next canvas
            if (currentCanvasIndex < dialogueCanvases.Count - 1)
            {
                dialogueCanvases[currentCanvasIndex].gameObject.SetActive(false); // Deactivate current canvas
                currentCanvasIndex++;
                dialogueCanvases[currentCanvasIndex].gameObject.SetActive(true); // Activate next canvas
                ShowNextDialogue();
            }
            else
            {
                dialogueCanvases[currentCanvasIndex].gameObject.SetActive(false); // Deactivate last canvas
                Debug.Log("Dialogue sequence completed.");
            }
        }
    }

    IEnumerator TypeMessage(string message)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in message.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}
