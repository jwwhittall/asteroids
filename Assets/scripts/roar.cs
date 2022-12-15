using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roar : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        StartCoroutine(despawn());
    }

    IEnumerator despawn()
    {
        yield return new WaitForSeconds(2);
        spriteRenderer.enabled = false;
    }
}
