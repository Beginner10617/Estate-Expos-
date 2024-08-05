using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KnifeLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject knife;
    public float speed;
    public float timePeriod;
    System.Random rnd;
    float time;
    void Start()
    {
        rnd = new System.Random();
        time = timePeriod;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= timePeriod)
        {
            time -= timePeriod;
            GameObject obj = Instantiate(knife, new Vector3(8.5f,(float) (rnd.NextDouble()-0.5) * 6, 0), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
    }
}
