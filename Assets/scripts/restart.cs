using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D rCollider;
    public AudioSource lAudio;

    public GameManager gameManager;


    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[0];
        rCollider = this.GetComponent<BoxCollider2D>();
        lAudio = this.GetComponent<AudioSource>();

        this.spriteRenderer.enabled = false;
        this.rCollider.enabled = false;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Asteroids");
        PlayerPrefs.DeleteAll();
    }
}
