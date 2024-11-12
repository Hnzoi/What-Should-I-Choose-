    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Interactable : MonoBehaviour
    {
        public GameObject interactIcon; // Reference to the interaction icon
        private bool isPlayerNearby = false; // Flag to check if player is nearby
        private bool isInteracted = false; // Flag to check if interaction has occurred
        public float interactionCooldown = 2f; // Cooldown time in seconds

        private GameObject Dialoug;

        void Start()
        {
            interactIcon.SetActive(false); // Hide the icon at the start
            Dialoug = transform.Find("Dialoug").gameObject;
        }

        void Update()
        {
            // Show the interact icon when the player is nearby
            if (isPlayerNearby)
            {
                interactIcon.SetActive(true); // Show the icon

                // Check for interaction
                if (Input.GetKeyDown(KeyCode.Space) && !isInteracted) // Change the key as needed
                {
                    InteractionManager.Instance.StartInteraction();
                    isInteracted = true; // Set the flag to prevent further interaction
                    StartCoroutine(popupChat());
                }
            }
            else
            {
                interactIcon.SetActive(false); // Hide the icon when out of range
                Dialoug.SetActive(false);
            }
        }

        private IEnumerator popupChat()
        {
            Dialoug.SetActive(true);
            yield return new WaitForSeconds(interactionCooldown);
            Dialoug.SetActive(false);
            InteractionManager.Instance.EndInteraction();
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
