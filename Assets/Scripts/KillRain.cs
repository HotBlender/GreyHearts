using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRain : MonoBehaviour
{
    public GameObject bomb;
    bool bs = true;
    bool bibi = false;
    private int a;
    public float time = 4f;

    void Update()
    {
        if(bs && !bibi)
        {
            bs = false;
            bibi = true;
            StartCoroutine(tutu());
        }
    }

    IEnumerator tutu()
    {
        yield return new WaitForSeconds(time);
        a = Random.Range(0, 72);
        Vector3 pos = new Vector3(a, 20, -3);
        Instantiate(bomb, pos, Quaternion.EulerAngles(0, 0, 50));
        bibi = false;
        bs = true;
    }
}
