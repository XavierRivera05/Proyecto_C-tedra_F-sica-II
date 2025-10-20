using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class src_CambiarPantallas : MonoBehaviour
{
    public GameObject panelSimulacion;
    public GameObject panelGraficas;
    public GameObject principal;

    public Button btnIrAGraficas;
    public Button btnRegresar;

    void Start()
    {
        MostrarSimulacion();

        // Conectar botones
        if (btnIrAGraficas != null)
            btnIrAGraficas.onClick.AddListener(MostrarGraficas);

        if (btnRegresar != null)
            btnRegresar.onClick.AddListener(MostrarSimulacion);
    }

    public void MostrarSimulacion()
    {
        if (panelSimulacion != null && panelGraficas != null)
        {
            panelSimulacion.SetActive(true);
            panelGraficas.SetActive(false);
            if (principal != null) principal.SetActive(true);
            Debug.Log("Mostrando Simulación");
        }
    }

    public void MostrarGraficas()
    {
        if (panelSimulacion != null && panelGraficas != null)
        {
            panelSimulacion.SetActive(false);
            panelGraficas.SetActive(true);
            if (principal != null) principal.SetActive(false);
            Debug.Log("Mostrando Gráficas");
        }
    }
}
