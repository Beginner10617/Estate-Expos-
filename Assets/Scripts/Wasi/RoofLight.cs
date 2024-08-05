using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RoofLight : MonoBehaviour
{
    // Start is called before the first frame update
    Transform Hing;
    public Transform nail;
    void Start()
    {
        Hing = transform.GetChild(0);
        transform.position = nail.position + (transform.position - Hing.position);
        transform.position = new Vector3(transform.position.x, 3.9f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = nail.position + (transform.position - Hing.position);
        transform.position = new Vector3(transform.position.x, 3.9f, 0);
    }
}
