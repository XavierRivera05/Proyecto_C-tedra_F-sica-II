using UnityEngine;
using UnityEngine.UI;

public class src_BarrasEnergiaInteractiva : MonoBehaviour
{
    public src_MASimulador masimulador;

    public Image barraCinetica;
    public Image barraPotencial;
    public Image barraMecanica;

    public float escalaMaxima = 300f; // ancho máximo en píxeles
    public float suavizado = 10f;     // velocidad de interpolación

    void Update()
    {
        if (masimulador == null || masimulador.pausado) return;

        float Ec = masimulador.GetEnergiaCinetica();
        float Ep = masimulador.GetEnergiaPotencial();
        float Em = masimulador.GetEnergiaMecanica();

        float ecNorm = Mathf.Clamp01(Ec / Em);
        float epNorm = Mathf.Clamp01(Ep / Em);

        // Interpolación suave
        ActualizarBarra(barraCinetica, ecNorm);
        ActualizarBarra(barraPotencial, epNorm);
        ActualizarBarra(barraMecanica, 1f); // energía mecánica constante
    }

    void ActualizarBarra(Image barra, float valorNormalizado)
    {
        Vector2 actual = barra.rectTransform.sizeDelta;
        float nuevoAncho = Mathf.Lerp(actual.x, valorNormalizado * escalaMaxima, Time.deltaTime * suavizado);
        barra.rectTransform.sizeDelta = new Vector2(nuevoAncho, actual.y);
    }
}
