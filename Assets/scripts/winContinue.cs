using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winContinue : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D rCollider;
    public AudioSource wAudio;

    public GameManager gameManager;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rCollider = this.GetComponent<BoxCollider2D>();
        wAudio = this.GetComponent<AudioSource>();

        this.spriteRenderer.enabled = false;
        this.rCollider.enabled = false;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Asteroids");
    }
}
