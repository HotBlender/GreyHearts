using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float dumping = 1.5f;
    public float minX = -8f;
    public float maxX = 70f;
    public Vector2 offset = new Vector2(3f, 0f);
    public bool isLeft;
    private Transform player;
    private int lastX;



    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerisleft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if(playerisleft && player.position.x >= -8 && player.position.x <= 64)
        {
            transform.position = new Vector3(player.position.x - offset.x * Time.deltaTime, player.position.y + offset.y * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x * Time.deltaTime, player.position.y + offset.y * Time.deltaTime, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        //Cam.transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);

        if(player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX)
                isLeft = false;
            else isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if(isLeft)
            {
                target = new Vector3(player.position.x - offset.x * Time.deltaTime, player.position.y + offset.y * Time.deltaTime, transform.position.z);
            }
            else target = new Vector3(player.position.x + offset.x * Time.deltaTime, player.position.y + offset.y * Time.deltaTime, transform.position.z);
            if (player.position.x >= minX && player.position.x <= maxX)
            {
                Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
                transform.position = currentPosition;
            }
            
        }
    }
}
