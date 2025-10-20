using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class src_MostrarValoresEnergias : MonoBehaviour
{
    public src_MASimulador masimulador;
    
    [Header("Textos de valores")]
    public TextMeshProUGUI txtValorFrecuencia;
    public TextMeshProUGUI txtValorCinetica;
    public TextMeshProUGUI txtValorPotencial;
    public TextMeshProUGUI txtValorMecanica;
    
    void Update()
    {
        if (masimulador == null) return;
        
        // Calcular valores
        float omega = Mathf.Sqrt(masimulador.k / masimulador.masa);
        float frecuencia = omega / (2f * Mathf.PI);
        float ec = masimulador.GetEnergiaCinetica();
        float ep = masimulador.GetEnergiaPotencial();
        float em = masimulador.GetEnergiaMecanica();
        
        // Actualizar textos
        if (txtValorFrecuencia != null)
            txtValorFrecuencia.text = frecuencia.ToString("F2") + " Hz";
        
        if (txtValorCinetica != null)
            txtValorCinetica.text = ec.ToString("F2") + " J";
        
        if (txtValorPotencial != null)
            txtValorPotencial.text = ep.ToString("F2") + " J";
        
        if (txtValorMecanica != null)
            txtValorMecanica.text = em.ToString("F2") + " J";
    }
}