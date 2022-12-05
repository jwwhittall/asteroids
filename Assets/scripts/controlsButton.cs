using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlsButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Asteroids");
    }
}
