using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WiresCut : MonoBehaviour
{

    GameObject ga;
    public GameObject blue;
    public GameObject yell;
    public GameObject tt;
    public GameObject all;
    public GameObject par;
    private Text te;
    int colrig = 0;


    private void Start()
    {
        te = tt.transform.gameObject.GetComponent<Text>();
    }

    public void Ex()
    {
        SceneManager.LoadScene(3);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cur = Input.mousePosition;

            cur = Camera.main.ScreenToWorldPoint(cur);
            cur.z = 0;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ga = hit.transform.gameObject;
                if (hit.transform.tag == "wire")
                {
                    Debug.Log(hit.transform.tag);
                    if (hit.transform.gameObject.GetComponent<CircleIdent>().ind == 1)
                    {
                        Vector3 pos = hit.transform.position;
                        Destroy(hit.transform.gameObject);
                        GameObject ogj = Instantiate(blue, pos, Quaternion.EulerAngles(0, 0, 0));
                        ogj.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                        ogj.transform.SetParent(par.transform);
                        colrig++;
                    }
                    else if (hit.transform.gameObject.GetComponent<CircleIdent>().ind == 4)
                    {
                        Vector3 pos = hit.transform.position;
                        Destroy(hit.transform.gameObject);
                        GameObject ogj = Instantiate(yell, pos, Quaternion.EulerAngles(0, 0, 0));
                        ogj.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                        ogj.transform.SetParent(par.transform);
                        colrig++;
                    }
                    else
                    {
                        Debug.Log("Dog Died");
                        tt.SetActive(true);
                        StartCoroutine(next());
                    }
                }
            }
        }

        if(colrig >= 3)
        {
            all.SetActive(false);
        }
    }

    IEnumerator next()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
