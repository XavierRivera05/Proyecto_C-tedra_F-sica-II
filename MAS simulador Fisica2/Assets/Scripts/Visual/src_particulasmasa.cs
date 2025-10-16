using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;        
using UnityEngine.VFX;


public class src_particulasmasa : MonoBehaviour
{
    public ParticleSystem sistema; //variable del sistema de partículas
    public src_MASimulador masimulador; //referencia al padre del objeto

    void Start()
    {
        //la variable busca al objeto padre!!
        masimulador = GetComponentInParent<src_MASimulador>();
    }

    void Update()
    {
        //calcular la cinética con la fórmula Ec = 1/2mv^2
        float velocidad =  masimulador.amplitud * masimulador.omega * Mathf.Sin(masimulador.omega * Time.time + masimulador.fifi);
        float energia = 0.5f * masimulador.masa * Mathf.Pow(velocidad, 2);

        //cambiar la emisión de partículas según energía
        var emission = sistema.emission;
        emission.rateOverTime = energia * 5f;

        //cambio de color :v
        var main = sistema.main;
        main.startColor = Color.Lerp(Color.white, Color.gray, energia / 10f);
    }
}
