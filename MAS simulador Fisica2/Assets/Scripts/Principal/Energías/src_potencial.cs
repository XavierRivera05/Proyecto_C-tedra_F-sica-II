using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_potencial : MonoBehaviour
{
    public float k; //la constante elástica
    public float elonmusk; //La elongación XD

    public float CalcularPotencial() //usar fórmula de energía potencial elástica
    {
        return 0.5f * k * Mathf.Pow(elonmusk, 2); //devoler resultado con return, pow = exponencial
    }

    //Para cosas futuras, actualizar el valor de k
    public void Actualizark(float nuevak)
    {
        k = nuevak;
    }

    public void Actualizarelongacion(float nuevaelongacion)
    {
        elonmusk = nuevaelongacion;
    }
}
