using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    bool inRange;
    bool  holding;
    float timePassedHolding;
    GameObject player;
    public int mode;
    public GameObject floor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = true;
            player = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            inRange = false;
            player = null;
            holding = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange&&Input.GetKeyDown(KeyCode.Space))
        {
            holding = !holding;
            Debug.Log(holding);
        }
        if(!holding&&player!=null)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        }
        if(holding&&inRange)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.transform.position = transform.GetChild(1).position + player.transform.position - player.transform.GetChild(0).position;
            if(mode == 2)
            {
                Destroy(floor);
            }
            else if(mode == 3)
            {
                Debug.Log("Exit");
            }
        }
        
    }
}
