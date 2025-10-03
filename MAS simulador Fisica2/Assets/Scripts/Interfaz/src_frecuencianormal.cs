using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //llamar al componente de canvas

public class src_frecuencianormal : MonoBehaviour
{
   public src_MASimulador masimulador; //referencia al script que tiene masa y k
   public TextMeshProUGUI txtfrecuencia;

    void Update()
    {
        //colocar la fórmula de la frecuencia :)
        float frecuencia = (1f / (2f * Mathf.PI)) * Mathf.Sqrt(masimulador.k / masimulador.masa);

        //orientado a texto
        txtfrecuencia.text = "Frecuencia = " + frecuencia.ToString("F2") + "Hz"; //F2 le dice a Unity que muestre el número como decimal
    }
}
