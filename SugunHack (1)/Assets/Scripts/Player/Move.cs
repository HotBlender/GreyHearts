using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpSpeed = 5.5f;
    public LayerMask groundLayer;
    public GameObject player;
    private float scale = 1f;
    public MeshRenderer tt;
    public MeshRenderer tut;
    private bool Et = false;
    public GameObject ima;
    public GameObject gee;
    public GameObject toto;
    private bool eturu = false;
    public Animation robZoom;
    public Animation Dog;

    public Animator anim;
    //public GameObject Cam;

    private Rigidbody2D rb;

    public Transform gCheck;
    private float scaleX = 1.0f; 
    private float scaleY = 1.0f;

    public float TimeBetweenJumps = 0.5f;
    public float TimeTilNextJump = -1;

    float gg;
    float gg1;
    float hh;
    float h;
    float hh1;

    public AudioSource au;
    public AudioSource au2;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hh = player.transform.position.x;
        scale = gameObject.transform.localScale.x;
        StartCoroutine(tutori());
    }

   

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Velocity", h);
        //Collider2D TouchesGround = Physics2D.OverlapPoint(gCheck.position, groundLayer);
        //Debug.Log(TouchesGround);
        gg1 = gg;
        gg = player.transform.position.y;
        

        
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        //Cam.transform.position += new Vector3(speed * h * Time.deltaTime, 0f);

        if (player.transform.position.x < hh)
        {
            player.transform.localScale = new Vector2(-scale, scale);
        }
        if(player.transform.position.x > hh)
            player.transform.localScale = new Vector2(scale, scale);
        hh = player.transform.position.x;

        if (Input.GetKeyDown(KeyCode.E) && Et && !eturu)
        {
            robZoom.Play();
            au.Stop();
            StartCoroutine(nume());
        }
    }

    IEnumerator nume()
    {
        yield return new WaitForSeconds(0.3f);
        ima.SetActive(true);
        gee.SetActive(true);
        toto.SetActive(false);
        eturu = true;
        au2.Play();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "bot" && !eturu)
        {
            tt.enabled = true;
            tt.transform.gameObject.GetComponent<Animation>().Play();
            Debug.Log("Welcome");
            Et = true;
            tut.enabled = false;
        }
        else if (col.transform.tag == "teleport")
        {
            SceneManager.LoadScene(2);
        }
        else if(col.transform.name == "TriggerDog")
        {
            Dog.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "bot")
        {
            tt.enabled = false;
            Debug.Log("EXit");
            Et = false;
        }
    }

    private IEnumerator tutori()
    {
        yield return new WaitForSeconds(1);
        tut.transform.gameObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1);
        tut.transform.gameObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1);
        tut.transform.gameObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1);
        tut.enabled = false;
    }
}
