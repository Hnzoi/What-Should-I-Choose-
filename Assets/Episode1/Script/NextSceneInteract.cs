using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneInteract : MonoBehaviour
{
    public GameObject interactIcon; // Reference to the interaction icon
    public float interactionCooldown = 2f; // Cooldown time in seconds
    public List<GameObject> scenes; // List to store the scenes
    public GameObject player; // Reference to the player GameObject

    private bool isPlayerNearby = false; // Flag to check if player is nearby
    private bool isInteracted = false; // Flag to check if interaction has occurred

    // Start is called before the first frame update
    void Start()
    {
        interactIcon.SetActive(false);

        // Ensure the first scene is active at the start
        if (scenes.Count > 0)
        {
            scenes[0].SetActive(true); // Show the first scene
        }

        // Hide other scenes initially
        for (int i = 1; i < scenes.Count; i++)
        {
            scenes[i].SetActive(false); // Hide all other scenes
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby)
        {
            interactIcon.SetActive(true); // Show the icon

            // Check for interaction
            if (Input.GetKeyDown(KeyCode.Space) && !isInteracted) // Change the key as needed
            {
                InteractionManager.Instance.StartInteraction();
                isInteracted = true;

                // Hide the first scene after interaction
                if (scenes.Count > 0)
                {
                    scenes[0].SetActive(false); // Hide the first scene
                }

                // Show the second scene if it exists
                if (scenes.Count > 1)
                {
                    scenes[1].SetActive(true); // Show the second scene
                }

                // Hide the player
                if (player != null) // Check if the player GameObject is assigned
                {
                    player.SetActive(false);
                }
                else
                {
                    Debug.LogError("Player GameObject is not assigned in the inspector.");
                }
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Set the flag when the player enters the trigger
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Reset the flag when the player exits the trigger
            interactIcon.SetActive(false); // Hide the icon when player exits
            isInteracted = false; // Reset the interaction flag
        }
    }
}
