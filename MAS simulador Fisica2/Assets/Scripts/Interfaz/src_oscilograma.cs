using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class src_oscilograma : MonoBehaviour
{
    [Header("Variables principales")]
    public src_MASimulador masimulador;
    public RawImage grafico;

    [Header("Configuración del gráfico")]
    public int ancho = 300;
    public int alto = 150;
    public int puntosMaximos = 150;
    [Range(1, 5)] public int grosorlinea = 1;
    public float optimizarG = 0.05f; // cada 0.05 s (20 FPS)

    [Header("Colores del gráfico")]
    public Color colorCinetica = Color.red;
    public Color colorPotencial = Color.blue;
    public Color colorMecanica = Color.green;
    public Color colorFondo = Color.white;

    private Texture2D textura;
    private List<float> energiasC = new List<float>();
    private List<float> energiasP = new List<float>();
    private List<float> energiasM = new List<float>();
    private float tiempoAcumulado = 0f;

    void Start()
    {
        textura = new Texture2D(ancho, alto, TextureFormat.RGB24, false);
        textura.filterMode = FilterMode.Point;
        grafico.texture = textura;
        Limpiar();
    }

    void Update()
    {
        if (masimulador == null) return;

        // Controlar frecuencia de actualización
        tiempoAcumulado += Time.deltaTime;
        if (tiempoAcumulado < optimizarG)
            return;
        tiempoAcumulado = 0f;

        // Calcular energías del sistema
        float Ec = masimulador.GetEnergiaCinetica();
        float Ep = masimulador.GetEnergiaPotencial();
        float Em = masimulador.GetEnergiaMecanica();

        energiasC.Add(Ec);
        energiasP.Add(Ep);
        energiasM.Add(Em);

        if (energiasC.Count > puntosMaximos)
        {
            energiasC.RemoveAt(0);
            energiasP.RemoveAt(0);
            energiasM.RemoveAt(0);
        }

        Dibujar();
    }

    void Dibujar()
    {
        // Borrar solo la última columna (más eficiente)
        int col = energiasC.Count - 1;
        if (col < 1) return;

        int x = Mathf.RoundToInt(col * (ancho / (float)puntosMaximos));

        // Dibujar una línea vertical con los valores actuales
        float maxE = Mathf.Max(1f, masimulador.GetEnergiaMecanica());
        int yC = Mathf.RoundToInt(energiasC[col - 1] / maxE * (alto - 1));
        int yP = Mathf.RoundToInt(energiasP[col - 1] / maxE * (alto - 1));
        int yM = Mathf.RoundToInt(energiasM[col - 1] / maxE * (alto - 1));

        // Fondo en blanco de esa columna
        for (int y = 0; y < alto; y++)
            textura.SetPixel(x, y, colorFondo);

        // Dibuja los puntos de cada energía
        PintarPunto(x, yC, colorCinetica);
        PintarPunto(x, yP, colorPotencial);
        PintarPunto(x, yM, colorMecanica);

        textura.Apply(false);
    }

    void PintarPunto(int x, int y, Color color)
    {
        for (int gx = -grosorlinea; gx <= grosorlinea; gx++)
        {
            for (int gy = -grosorlinea; gy <= grosorlinea; gy++)
            {
                int px = Mathf.Clamp(x + gx, 0, ancho - 1);
                int py = Mathf.Clamp(y + gy, 0, alto - 1);
                textura.SetPixel(px, py, color);
            }
        }
    }

    void Limpiar()
    {
        Color[] pixeles = new Color[ancho * alto];
        for (int i = 0; i < pixeles.Length; i++)
            pixeles[i] = colorFondo;
        textura.SetPixels(pixeles);
        textura.Apply(false);
    }
}

