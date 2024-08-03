using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Vibrations : MonoBehaviour
{
    System.Random rnd;
    Vector3 position;
    void Start()
    {
        position = new Vector3();
        rnd = new System.Random();
    }
    // Update is called once per frame
    void Update()
    {
        position = new Vector3((float) rnd.NextDouble() * (rnd.Next(0, 3) - 1 - transform.position.x), (float) rnd.NextDouble() * (rnd.Next(0, 3) - 1 - transform.position.x)/2, 0);
        transform.position = transform.position + (position - transform.position) * Time.deltaTime;
    }
}
