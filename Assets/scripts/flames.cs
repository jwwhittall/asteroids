using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flames : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public player player;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (player._thrusting == true)
        {
            this.spriteRenderer.enabled = true;
        }
        else this.spriteRenderer.enabled = false;
    }
}
