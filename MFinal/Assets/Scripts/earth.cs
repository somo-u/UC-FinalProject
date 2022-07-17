using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class earth : MonoBehaviour
{
    public GameObject[] panels;

    int currentpanel;

    public void correctAnswer()
    {
        if (currentpanel + 1 != panels.Length)
        {
            panels[currentpanel].SetActive(false);
            currentpanel++;
            panels[currentpanel].SetActive(true);
        }
       
    }
    public void NewS()
    {
        SceneManager.LoadScene(3);
    }
}
