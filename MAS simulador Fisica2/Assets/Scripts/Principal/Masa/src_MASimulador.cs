using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_MASimulador : MonoBehaviour
{
      //variables principales (públicas y privadas)
    public float amplitud = 2f;
    public float masa = 1f;
    public float k = 5f;
    public float fifi = 0f;
    private float omega;
    private float tiempo;
    
    void Start()
    {
        omega = Mathf.Sqrt(k/masa); //fórmula frecuencia angular con Mathf
        tiempo = 0; //inicializar el tiempo en 0s
    }

    
    void Update()
    {
        tiempo += Time.deltaTime; //tiempo transcurrido

        float x = amplitud * Mathf.Cos(omega * tiempo + fifi); //fórmula de posición
        transform.position = new Vector3(x, transform.position.y, 0); //actualizar pos del obj
    }

    //actualizar el valor de la masa y actualizar frecuencia angular (funcion)
    public void ActualizarMasita(float masaNueva) //se crea una nueva variable
    {
        masa = masaNueva;
        omega = Mathf.Sqrt(k/masa);
    }
}
