using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject smallTable;
    public GameObject knifeLauncher;
    void Start()
    {
        knifeLauncher.GetComponent<KnifeLauncher>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Pickable"))
        {
            Destroy(other.gameObject);
            smallTable.SetActive(true);
            knifeLauncher.GetComponent<KnifeLauncher>().enabled = true;
        }
    }
}
