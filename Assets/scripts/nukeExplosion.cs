using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nukeExplosion : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator controller;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void toggle()
    {
       
        if (spriteRenderer.enabled == true)
        {
            controller.Play("explosion", -1, 0.0f);
            spriteRenderer.enabled = false;
        }
        else if (spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;
        }
    }
}
