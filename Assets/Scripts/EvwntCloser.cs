using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EvwntCloser : MonoBehaviour
{
    public GameObject ge1;
    public GameObject ge2;
    public GameObject ge3;
    public GameObject ge4;
    public GameObject ge5;
    public GameObject toto;
    public GameObject gee;
    public GameObject ima;
    public GameObject exit;
    public Image img;
    public Animation bot;

    public SpriteRenderer img1Bot;
    public Sprite img1Zam;

    bool check = false;
    bool fini = false;

    public void Update()
    {
        if(!check && ge1.GetComponent<TileSet>().cap && ge2.GetComponent<TileSet>().cap && ge3.GetComponent<TileSet>().cap)
        {
            ge1.GetComponent<Animator>().enabled = true;
            ge2.GetComponent<Animator>().enabled = true;
            ge3.GetComponent<Animator>().enabled = true;
            ge4.GetComponent<Animator>().enabled = true;
            ge5.GetComponent<Animator>().enabled = true;
            img.color = new Color(0,90,0);
            check = true;
            StartCoroutine(zus());
        }
        if(fini)
        {
            img1Bot.sprite = img1Zam;
            gee.SetActive(false);
            ima.SetActive(false);
            toto.SetActive(true);
            exit.SetActive(false);
            bot.Play();
        }
    }

    private IEnumerator zus()
    {
        fini = false;
        yield return new WaitForSeconds(3);
        fini = true;
    }
}
