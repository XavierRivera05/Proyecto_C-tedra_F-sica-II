using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class src_PanelPausa : MonoBehaviour
{
    public src_MASimulador masimulador;
    public GameObject panelPausa;
    public TextMeshProUGUI txtInfoPausa;
    public UnityEngine.UI.Button btnContinuar;
    public UnityEngine.UI.Button btnPausa;
    public GameObject txtFrecuenciaNormal; // ← AGREGAR ESTA LÍNEA
    
    private float tiempoDesdeUltimaPausa = 0f;
    
    void Start()
    {
        panelPausa.SetActive(false);
        btnPausa.onClick.AddListener(AlternarPausa);
        btnContinuar.onClick.AddListener(AlternarPausa);
    }
    
    void Update()
    {
        if (!masimulador.pausado)
        {
            tiempoDesdeUltimaPausa += Time.deltaTime;
        }
    }
    
    public void AlternarPausa()
    {
        masimulador.AlternarPausa();
        panelPausa.SetActive(masimulador.pausado);
        
        if (masimulador.pausado)
        {
            MostrarInfoPausa();
            // ← AGREGAR ESTAS LÍNEAS
            if (txtFrecuenciaNormal != null)
            {
                txtFrecuenciaNormal.SetActive(false); // Ocultar el texto
            }
        }
        else
        {
            tiempoDesdeUltimaPausa = 0f;
            // ← AGREGAR ESTAS LÍNEAS
            if (txtFrecuenciaNormal != null)
            {
                txtFrecuenciaNormal.SetActive(true); // Mostrar el texto
            }
        }
    }
    
    void MostrarInfoPausa()
    {
        float omega = Mathf.Sqrt(masimulador.k / masimulador.masa);
        float frecuencia = omega / (2f * Mathf.PI);
        
        float posicion = masimulador.GetPosicion();
        float velocidad = masimulador.GetVelocidad();
        
        if (txtInfoPausa != null)
        {
            txtInfoPausa.text ="Frecuencia: " + frecuencia.ToString("F2") + " Hz\n\n" +
                               "Velocidad: " + velocidad.ToString("F2") + " m/s\n\n" +
                               "Posición: " + posicion.ToString("F2") + " m\n\n" +
                               "Tiempo oscilando: " + tiempoDesdeUltimaPausa.ToString("F2") + " s\n\n";
        }
    }
}