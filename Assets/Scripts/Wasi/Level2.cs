using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public float speed;
    public List<GameObject> toActive;
    public List<GameObject> toinActive;
    GameObject ToPick;
    int n = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            ToPick = other.gameObject;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            ToPick = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
        }   
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 0);
        }   
        if(Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0);
        }   
        if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
        } 
        if(Input.GetKey(KeyCode.Space)&&ToPick!=null)
        {
            ToPick.SetActive(false);
            ToPick = null;
            n--;
        }
        if(n == 0)
        {
            foreach(GameObject obj in toActive)
            {
                obj.SetActive(true);
            }
            foreach(GameObject obj in toinActive)
            {
                obj.SetActive(false);
            }
            n = -1;
        }
    }
}
