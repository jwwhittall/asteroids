using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nukeCollider : MonoBehaviour
{
    public BoxCollider2D nCollider;
    public nukeExplosion explosionAni;


    void Awake()
    {
        nCollider = this.GetComponent<BoxCollider2D>();
        nCollider.enabled = false;
    }

    public void nuke()
    {
        nCollider.enabled = true;
        this.Invoke(nameof(nukeOff), 0.7f);
        explosionAni.toggle();
    }

    public void nukeOff()
    {
        nCollider.enabled = false;
        explosionAni.toggle();
    }
}
