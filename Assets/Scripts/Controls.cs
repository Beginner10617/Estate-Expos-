using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float walkingSpeed;
    public float jumpSpeed;
    bool isOnGround = false;
    void Start()
    {
        transform.position = GameObject.FindWithTag("Entrance").transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    { 
        if(other.gameObject.CompareTag("Ground"))
        {
           isOnGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        { 
           isOnGround = false;
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - walkingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + walkingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && isOnGround)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpSpeed);
        }
    }
}
