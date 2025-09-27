using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class src_cambiarmasa : MonoBehaviour
{
    public Dropdown menumasa; //en referencia a las tres opciones
    public src_MASimulador masimulador; //para script de la masa
    public Transform objetomasa; //"Transform" para colocar un objeto

    void Start()
    {
        menumasa.onValueChanged.AddListener(CambiarTipoDeMasa); //inicializar el evento de abajo "void"
    }

   void CambiarTipoDeMasa(int opcion)
   {

    Vector3 nuevaEscala = Vector3.one; //XD pues un nuevo Vector3 que será para escalar

    //switch para mantener un orden en los 3 casos
    switch (opcion)
    {
        case 0:  //Masa mediana
        masimulador.masa = 1f; //cambiando valor de la masa (usando variable del otro script)
        masimulador.ActualizarMasita(masimulador.masa);
        nuevaEscala = new Vector3(1f, 1f, 1f); //dimensiones de la masa en los ejes + vector3 pa su posición
        break;

        case 1: //Masa pequeña
        masimulador.masa = 0.3f;
        masimulador.ActualizarMasita(masimulador.masa);
        nuevaEscala = new Vector3(0.8f, 0.8f, 1f);
        break;

        case 2: //Masa grandota
        masimulador.masa = 10.0f;
        masimulador.ActualizarMasita(masimulador.masa);
        nuevaEscala = new Vector3(1.5f, 1.5f, 1f);
        break;
    }
    
    Vector3 posactual = objetomasa.position; //Guardar posición antes de cambiar escala (para que no vuele)
    objetomasa.localScale = nuevaEscala; //aplicar la escala visual (todo esto para que no traspase el suelo)
    float diferenciaAltura = nuevaEscala.y / 3f - objetomasa.localScale.y / 3f; //Calcular cuando cambió la altura (de nuevo para que no vuele XDDDD)

    //Ajustar posición 
    objetomasa.position = new Vector3(posactual.x, posactual.y + diferenciaAltura, posactual.z); //cambios en la posición en los 3 ejes
   }

}
