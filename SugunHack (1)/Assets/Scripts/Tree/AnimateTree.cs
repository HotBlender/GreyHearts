using UnityEngine;
using System.Collections.Generic;

public class AnimateTree : MonoBehaviour
{



    Mesh mesh;
    Vector3[] verts_ref;
    Vector3[] verts;
    float time_offset;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        verts_ref = mesh.vertices;
        verts = new Vector3[verts_ref.Length];
        System.Array.Copy(verts_ref, verts, verts_ref.Length);
        time_offset = Random.Range(0, 10000);
    }

    void OnBecameInvisible()
    {
        enabled = false;
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void Update()
    {
        float time = time_offset + Time.time;
        float x_tweak = 0.060f;
        float y_tweak = 0.0085f;
        float val_x = Mathf.Sin(time);
        float val_y = Mathf.Cos(time);
        float k = 1.0f;

        for (int i = (int)(verts.Length * 0.4f); i < verts.Length; ++i)
        {
            //print("lol");
            Vector3 v = verts_ref[i];

            if (i % 5 == 0) k = 1.0f;
            if (i % 5 == 1) k = 1.2f;

            v.x = v.x + k * x_tweak * val_x;
            v.y = v.y + k * y_tweak * val_y;
            verts[i] = v;
        }
        mesh.vertices = verts;
    }
}