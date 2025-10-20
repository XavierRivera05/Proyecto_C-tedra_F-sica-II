using UnityEngine;
using UnityEngine.UI;

public class src_PantallaInicio : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelSimulacion;
    public Button btnComenzar;

    void Start()
    {
        panelInicio.SetActive(true);
        panelSimulacion.SetActive(false);

        btnComenzar.onClick.AddListener(IniciarSimulacion);
    }

    void IniciarSimulacion()
    {
        panelInicio.SetActive(false);
        panelSimulacion.SetActive(true);
    }
}
