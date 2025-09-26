using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_visualresorte : MonoBehaviour
{
    //variables de tipo transform para colocar otros objetos como valor
    public Transform puntofijo;
    public Transform masita;
    public LineRenderer resortevisual;

    void Start()
    {
        //por el momento no añado nada aquí equisde
    }

    
    void Update()
    {
        int curva = 20; //número de curvas del resorte 
        resortevisual.positionCount = curva;

        //configuración del Vector 3 (posicion visual)
        Vector3 start = puntofijo.position;
        Vector3 end = masita.position;
        Vector3 direction = (end - start).normalized;
        float longitud = Vector3.Distance(start,end);

        for (int i = 0; i < curva; i++)
        {
            float tito = (float)i / (curva - 1);
            Vector3 pos = Vector3.Lerp(start,end, tito);

            //crear una "ondulación" con la función seno para simular un resorte chino
            pos += Vector3.Cross(direction, Vector3.forward) * Mathf.Sin(tito * Mathf.PI * 20) * 0.1f; //el pi sirve para los ciclos, y el 0.1f es amplitud

            resortevisual.SetPosition(i, pos);
        }
    }
}
