using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_flotandotexto2 : MonoBehaviour
{
    public float amplitud = 10f;
    public float frecuencia = 1f;
    private Vector3 posicioninicial;

    void Start()
    {
        posicioninicial = transform.localPosition;    
    }

    void Update()
    {
        float desplazamientoX = Mathf.Sin(Time.time * frecuencia) * amplitud;
        transform.localPosition = posicioninicial + new Vector3(desplazamientoX, 0, 0);
    }
}
