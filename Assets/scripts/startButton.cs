using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    void OnMouseDown()
    { 
        SceneManager.LoadScene("Asteroids");

    }
}
