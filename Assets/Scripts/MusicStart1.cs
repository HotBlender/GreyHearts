using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart1 : MonoBehaviour
{
    public AudioSource au;
    public AudioSource au2;
    bool first = false;
    bool second = false;
    float sec;


    private void Start()
    {
        StartCoroutine(check());
    }
    private void Update()
    {
        if(first && !au2.isPlaying && !second)
        {
            au2.Play();
            second = true;
        }
    }

    IEnumerator check()
    {
        yield return new WaitForSeconds(4.9f);
        first = true;
    }
}
