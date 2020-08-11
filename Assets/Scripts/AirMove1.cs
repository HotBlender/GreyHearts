using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMove1 : MonoBehaviour
{
    float speed;
    double lol;
    // Update is called once per frame
    void Start()
    {
        speed = 0.28f; 
    }
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f);
    }
}
