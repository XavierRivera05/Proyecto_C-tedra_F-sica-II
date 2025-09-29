using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_cinetica : MonoBehaviour
{
    public float masa;
    public float velocidad;

    public float CalcularCinetica()//usar la fórmula de energía cinética en una clase
    {
        //return para devolver el resultado y usarlo cuando se necesite
        return 0.5f * masa * Mathf.Pow(velocidad, 2); //Pow es para exponencial 
    }

    //para futuras cosas (actualizar la masa de energía cinética en otro script)
    public void Actualizarmasa(float nuevamasa)
    {
        masa = nuevamasa;
    }

    //actualizar velocidad en cosas futuras
    public void Actualizarvelocidad(float nuevavelocidad)
    {
        velocidad = nuevavelocidad;
    }
}
