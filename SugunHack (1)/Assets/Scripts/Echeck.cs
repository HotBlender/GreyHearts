using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Echeck : MonoBehaviour
{

    public GameObject all;
    public GameObject canv;
    public GameObject Etext;
    private bool dogged = false;
    void Update()
    {
        if (dogged && Input.GetKeyDown(KeyCode.E))
        {
            all.SetActive(true);
            canv.SetActive(true);
            SceneManager.LoadScene(4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Dog")
        {
            Etext.SetActive(true);
            dogged = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Dog")
        {
            Etext.SetActive(false);
            dogged = false;
        }
    }
}
