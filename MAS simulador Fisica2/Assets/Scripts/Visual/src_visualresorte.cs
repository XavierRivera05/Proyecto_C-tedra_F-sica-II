using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_visualresorte : MonoBehaviour
{
    //variables de tipo transform para colocar otros objetos como valor
    public Transform puntofijo;
    public Transform masita;
    public Transform resortevisual;

    void Start()
    {
        //por el momento no añado nada aquí equisde
    }

    
    void Update()
    {
        //posicionar el resorte visual en el centro del obj_masa y punto fijo
        resortevisual.position = (masita.position + puntofijo.position) / 2;

        //usar un Vector para ajustar el sprite(imagen)
        Vector3 direction = masita.position - puntofijo.position;
        resortevisual.up = direction.normalized;

        //Escalar el sprite para que se estire
        float distancia = direction.magnitude;
        resortevisual.localScale = new Vector3(1, distancia, 1);
    }
}
