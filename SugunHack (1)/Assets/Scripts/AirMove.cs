using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMove : MonoBehaviour
{
    float speed;
    double lol;
    // Update is called once per frame
    void Start()
    {
        speed = Random.Range(0.4f, 0.8f); 
    }
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f);
    }
}
