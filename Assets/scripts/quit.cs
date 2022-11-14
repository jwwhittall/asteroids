using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void OnMouseDown()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }
}
