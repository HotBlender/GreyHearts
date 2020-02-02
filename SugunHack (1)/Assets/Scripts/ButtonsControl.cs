using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour
{
    public void StartButt()
    {
        SceneManager.LoadScene(1);
        print("lol");
    }

    public void FinishButt()
    {
        Application.Quit();
    }

    public void Authors()
    {

    }
}
