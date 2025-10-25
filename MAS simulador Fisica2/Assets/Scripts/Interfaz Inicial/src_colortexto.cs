using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class src_colortexto : MonoBehaviour
{
    public TextMeshProUGUI textitos;
    public Color colorA = Color.cyan;
    public Color colorB = Color.magenta;
    public float velocidad = 1f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time * velocidad, 1f);
        textitos.color = Color.Lerp(colorA, colorB, t);
    }
}
