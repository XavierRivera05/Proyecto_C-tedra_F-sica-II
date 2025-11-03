using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class src_textoNPC : MonoBehaviour
{
    public TextMeshProUGUI textoNPC;
    [TextArea(2, 4)]
    public string[] frases; //tipo lista
    public float intervalo = 15f; // segundos para cambiar de textitos
    private float tiempo = 0f;

    void Start()
    {
        MostrarFraseAleatoria();
    }

    void Update()
    {
      tiempo += Time.deltaTime;

      if (tiempo >= intervalo)
      {
        MostrarFraseAleatoria();
        tiempo = 0f;
      }
    }

    void MostrarFraseAleatoria()
    {
        int index = Random.Range(0, frases.Length);
        textoNPC.text = frases[index];
    }
}
