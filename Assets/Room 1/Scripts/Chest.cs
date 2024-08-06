using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour, Interactable
{
    public string correctCode = "8754"; // The correct code to unlock the chest
    public GameObject codeInputPanel; // UI Panel for code input
    public TMP_InputField codeInputField; // InputField for entering the code
    public Button submitButton; // Button to submit the code
    public GameObject codeDisplayPanel;
    public Text messageText; // Text component to display messages
    public GameObject paintingInteractor;


    void Start()
    {
        // Ensure the code input panel and message text are hidden at the start
        codeInputPanel.SetActive(false);
        messageText.gameObject.SetActive(false);
        paintingInteractor.SetActive(false);

        // Add listener to the submit button
        submitButton.onClick.AddListener(CheckCode);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && codeInputPanel.activeSelf)
        {
            Debug.Log("Esc Pressed");
            codeInputPanel.SetActive(false);
            messageText.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        Debug.Log("Chest");
        codeInputPanel.SetActive(true);
        codeInputField.text = ""; // Clear the input field
    }

    void CheckCode()
    {
        // Check if the entered code is correct
        if (codeInputField.text == correctCode)
        {
            // Display the success message
            StartCoroutine(DisplayMessage("Chest Unlocked! Key for secret vault behind painting found.", 5f));
        }
        else
        {
            // Display the failure message
            StartCoroutine(DisplayMessage("Incorrect code! Try again.", 5f));
        }

        // Hide the code input panel
        codeInputPanel.SetActive(false);
    }

    IEnumerator DisplayMessage(string message, float duration)
    {
        messageText.text = message;
        codeDisplayPanel.SetActive(true);
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        paintingInteractor.gameObject.SetActive(true);
        codeDisplayPanel.SetActive(false);
        messageText.gameObject.SetActive(false);
    }

    
}
