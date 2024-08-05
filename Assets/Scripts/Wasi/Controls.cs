using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Controls : MonoBehaviour
{
    public float walkingSpeed;
    public float jumpSpeed;
    public List<GameObject> chains;
    bool isOnGround = false;
    GameObject ToPick;
    Vector3 Hold;
    Animator animator;
    System.Random rnd;

    void Start()
    {
        transform.position = GameObject.FindWithTag("Entrance").transform.position;
        animator = GetComponent<Animator>();
        rnd = new System.Random();
        for(int i=0; i<10; i++)
        {
            GameObject buff = chains[i%3];
            int temp = rnd.Next(3);
            chains[i%3] = chains[temp];
            chains[temp] = buff;
        }
        for(int i=0; i<3; i++)
        {
            chains[i].GetComponent<Chains>().mode = i;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Pickable"))
        {
            ToPick = other.gameObject;    
            Hold = ToPick.transform.position - transform.position ;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Pickable"))
        {
            ToPick = null;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    { 
        if(other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("Pickable"))
        {
           isOnGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("Pickable"))
        { 
           isOnGround = false;
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - walkingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(10, 10, 1);
            if(isOnGround) {animator.SetFloat("Blend", 1);}
            else {animator.SetFloat("Blend", 0);}
        } 
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + walkingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(-10, 10, 1);
            if(isOnGround) {animator.SetFloat("Blend", 1);}
            else {animator.SetFloat("Blend", 0);}
        }
        else
        {
            animator.SetFloat("Blend", 0);
        }

        if(Input.GetKeyDown(KeyCode.S) && isOnGround)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpSpeed);
        }
        if(Input.GetKey(KeyCode.Space)&&ToPick!=null)
        {
            ToPick.transform.position = transform.position + new Vector3(Hold.x,1,0);
            //ToPick.transform.rotation = Quaternion.identity;
        }
    }
}
