using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D rCollider;

    public GameManager gameManager;


    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rCollider = this.GetComponent<BoxCollider2D>();

        this.spriteRenderer.enabled = false;
        this.rCollider.enabled = false;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Asteroids");
    }
}
