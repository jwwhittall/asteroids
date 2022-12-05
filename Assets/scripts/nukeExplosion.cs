using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nukeExplosion : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void toggle()
    {
        if (spriteRenderer.enabled == true)
        {
            spriteRenderer.enabled = false;
        }
        else if (spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;
        }
    }
}
