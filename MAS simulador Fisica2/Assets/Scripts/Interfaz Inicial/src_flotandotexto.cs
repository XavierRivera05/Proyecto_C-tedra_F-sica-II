using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_flotandotexto : MonoBehaviour
{
    public float amplitud = 10f;
    public float frecuencia = 1f;
    private Vector3 posinicial;

    void Start()
    {
        posinicial = transform.localPosition;    
    }

    void Update()
    {
        float desplazamientoY = Mathf.Sin(Time.time + frecuencia) * amplitud;
        transform.localPosition = posinicial + new Vector3(0, desplazamientoY, 0);
    }
}
