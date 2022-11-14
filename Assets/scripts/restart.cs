using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        this.gameManager.Restart();
        this.spriteRenderer.enabled = false;
        this.rCollider.enabled = false;
    }
}
