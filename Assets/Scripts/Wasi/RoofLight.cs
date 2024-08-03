using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RoofLight : MonoBehaviour
{
    // Start is called before the first frame update
    Transform Hing;
    System.Random rnd;
    float time;
    public float frequency;
    public Transform nail;
    void Start()
    {
        time = 0;
        rnd = new System.Random();
        Hing = transform.GetChild(0);
        transform.position = nail.position + (transform.position - Hing.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0,15 * Mathf.Cos(frequency * time));
        time += Time.deltaTime;
        transform.position = nail.position + (transform.position - Hing.position);
    }
}
