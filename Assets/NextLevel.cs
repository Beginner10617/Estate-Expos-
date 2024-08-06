using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
