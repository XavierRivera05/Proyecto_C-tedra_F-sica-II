using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_fondomovimiento : MonoBehaviour
{
    public float velocidad = 0.1f;
    private Renderer rendersito; //acceder al material con Renderer
    private Vector2 impresion; //esto se aplica a la textura

    void Start()
    {
        rendersito = GetComponent<Renderer>(); //Obtenemos el material
    }

    void Update()
    {
        //crear el movimiento diagonal
        impresion += new Vector2(velocidad, velocidad) * Time.deltaTime; 
        //mover la textura
        rendersito.material.mainTextureOffset = impresion;
    }
}
