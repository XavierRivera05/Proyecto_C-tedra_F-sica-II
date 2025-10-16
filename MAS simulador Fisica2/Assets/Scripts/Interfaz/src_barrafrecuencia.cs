using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_barrafrecuencia : MonoBehaviour
{
   public src_MASimulador masimulador;
   private RectTransform barrita;
   private float tiempo;
   private float anchobarra = 50f;

    void Start()
    {
        barrita = GetComponent<RectTransform>();
    }

    void Update()
    {
        //Fórmula de la frecuencia
        float frecuencia = (1f / (2f * Mathf.PI)) * Mathf.Sqrt(masimulador.k / masimulador.masa);
        tiempo += Time.deltaTime;

        //oscilación horizontal
        float ancho = Mathf.Abs(Mathf.Sin(2 * Mathf.PI * frecuencia * tiempo)) * anchobarra;

        //Actualizar ancho de la barra :v
        barrita.sizeDelta = new Vector2(ancho, barrita.sizeDelta.y);  
    }
}
