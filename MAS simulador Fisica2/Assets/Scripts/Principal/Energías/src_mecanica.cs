using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_mecanica : MonoBehaviour
{
    //variables para llamar a los scripts de ec y ep
    public src_cinetica energiacinetica;
    public src_potencial energiapotencial;

    //calcular la energía mecánica (misma lógica XD)
    public float Calculartotal()
    {
        //returnamos las variables y usamos las fórmulas de los otros scripts
        return energiacinetica.CalcularCinetica() + energiapotencial.CalcularPotencial(); 
    }
}
