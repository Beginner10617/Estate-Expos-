using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour, Interactable
{
    public GameObject codeDisplayPanel; // UI Panel that will display the code
    public Text codeText; // Text component to display the code
    public float displayDuration = 5f; // Duration to display the code

    void Start()
    {
        codeDisplayPanel.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("Bed");
        StartCoroutine(DisplayCodeForDuration());

    }

    IEnumerator DisplayCodeForDuration()
    {
        // Display the code
        codeDisplayPanel.SetActive(true);
        codeText.gameObject.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the code display panel
        codeDisplayPanel.SetActive(false);
        codeText.gameObject.SetActive(false);
    }
}
