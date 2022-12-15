using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    public Text hpText;

    public boss harrow;

    void Start()
    {
        this.hpText = GetComponent<Text>();
    }

    void Update()
    {
        hpText.text = harrow.hp.ToString();
    }
}
