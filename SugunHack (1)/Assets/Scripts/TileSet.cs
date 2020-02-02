using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TileSet : MonoBehaviour
{
    bool mouseDown = false;
    bool setted = false;
    Vector3 InPos;
    public int needInd;
    public bool cap = false;
    GameObject ga;

    void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseDown = false;
    }
    void Start()
    {
        InPos = this.transform.position;    
    }

    void Update()
    {
        Vector3 cur = Input.mousePosition;

        cur = Camera.main.ScreenToWorldPoint(cur);

        cur.z = 0;
        if(mouseDown)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ga = hit.transform.gameObject;
                if (hit.transform.tag != "circle")
                {
                    this.transform.position = cur;
                    setted = false;
                    cap = false;
                }
                else
                {
                    if (hit.transform.GetComponent<CircleIdent>().ind != 0)
                    {
                        this.transform.position = hit.transform.position;
                        setted = true;
                        hit.transform.GetComponent<CircleIdent>().toSet = needInd;
                        if (hit.transform.GetComponent<CircleIdent>().ind == needInd)
                            cap = true;
                    }
                }
            }
            else
            {
                this.transform.position = cur;
                setted = false;
                cap = false;
            }
        }
        else if(!setted)
        {
            this.transform.position = InPos;

        }

    }
}
