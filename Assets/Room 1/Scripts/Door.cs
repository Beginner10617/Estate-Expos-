using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour, Interactable
{
    public GameObject codeDisplayPanel;
    public string correctCode = "6969"; // The correct code to unlock the chest
    public GameObject codeInputPanel; // UI Panel for code input
    public TMP_InputField codeInputField; // InputField for entering the code
    public Button submitButton; // Button to submit the code
    public Text messageText; // Text component to display messages
    int currentSceneIndex;

    void Start()
    {
        // Ensure the code input panel and message text are hidden at the start
        codeInputPanel.SetActive(false);
        messageText.gameObject.SetActive(false);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
        Debug.Log("Door");
        codeInputPanel.SetActive(true);
        codeInputField.text = ""; // Clear the input field
    }

    void CheckCode()
    {
        // Check if the entered code is correct
        if (codeInputField.text == correctCode)
        {
            // Display the success message
            StartCoroutine(DisplayMessage("Level Complete!", 5f));
            SceneManager.LoadScene(currentSceneIndex + 1);

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
        codeDisplayPanel.SetActive(false);
        messageText.gameObject.SetActive(false);
    }
}
