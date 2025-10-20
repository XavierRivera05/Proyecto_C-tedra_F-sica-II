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
    public int ancho = 440;
    public int alto = 120;
    public int puntosMaximos = 220;
    [Range(1, 3)] public int grosorlinea = 1;
    public float optimizarG = 0.1f;

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
    private bool necesitaRedibujar = false;

    void Start()
    {
        textura = new Texture2D(ancho, alto, TextureFormat.RGB24, false);
        textura.filterMode = FilterMode.Point; // ✅ Líneas más nítidas y delgadas
        grafico.texture = textura;
        grosorlinea = 1; // ✅ Forzar grosor mínimo
        Limpiar();
    }

    void Update()
    {
        if (masimulador == null) return;

        tiempoAcumulado += Time.deltaTime;
        if (tiempoAcumulado < optimizarG) return;
        tiempoAcumulado = 0f;

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
            necesitaRedibujar = true;
        }

        Dibujar();
    }

    void Dibujar()
    {
        if (necesitaRedibujar || energiasC.Count == 1)
        {
            DibujarTodo();
            necesitaRedibujar = false;
        }
        else
        {
            DibujarUltimoSegmento();
        }

        textura.Apply(false);
    }

    void DibujarTodo()
    {
        Limpiar();
        if (energiasC.Count < 2) return;

        float maxE = Mathf.Max(1f, masimulador.GetEnergiaMecanica());

        DibujarLineaConectada(energiasC, colorCinetica, maxE);
        DibujarLineaConectada(energiasP, colorPotencial, maxE);
        DibujarLineaConectada(energiasM, colorMecanica, maxE);
    }

    void DibujarUltimoSegmento()
    {
        if (energiasC.Count < 2) return;

        float maxE = Mathf.Max(1f, masimulador.GetEnergiaMecanica());
        int i = energiasC.Count - 1;

        DibujarSegmento(i - 1, i, energiasC, colorCinetica, maxE);
        DibujarSegmento(i - 1, i, energiasP, colorPotencial, maxE);
        DibujarSegmento(i - 1, i, energiasM, colorMecanica, maxE);
    }

    void DibujarLineaConectada(List<float> valores, Color color, float maxE)
    {
        for (int i = 1; i < valores.Count; i++)
        {
            DibujarSegmento(i - 1, i, valores, color, maxE);
        }
    }

    void DibujarSegmento(int indice1, int indice2, List<float> valores, Color color, float maxE)
    {
        int x1 = Mathf.RoundToInt(indice1 * (ancho / (float)puntosMaximos));
        int y1 = Mathf.RoundToInt(valores[indice1] / maxE * (alto - 1));

        int x2 = Mathf.RoundToInt(indice2 * (ancho / (float)puntosMaximos));
        int y2 = Mathf.RoundToInt(valores[indice2] / maxE * (alto - 1));

        DibujarLineaRapida(x1, y1, x2, y2, color);
    }

    void DibujarLineaRapida(int x1, int y1, int x2, int y2, Color color)
    {
        int dx = Mathf.Abs(x2 - x1);
        int dy = Mathf.Abs(y2 - y1);
        int sx = x1 < x2 ? 1 : -1;
        int sy = y1 < y2 ? 1 : -1;
        int err = dx - dy;

        while (true)
        {
            if (grosorlinea <= 1)
            {
                if (x1 >= 0 && x1 < ancho && y1 >= 0 && y1 < alto)
                    textura.SetPixel(x1, y1, color);
            }
            else
            {
                PintarPunto(x1, y1, color);
            }

            if (x1 == x2 && y1 == y2) break;

            int e2 = 2 * err;
            if (e2 > -dy) { err -= dy; x1 += sx; }
            if (e2 < dx) { err += dx; y1 += sy; }
        }
    }

    void PintarPunto(int x, int y, Color color)
    {
        for (int gx = -grosorlinea; gx <= grosorlinea; gx++)
        {
            for (int gy = -grosorlinea; gy <= grosorlinea; gy++)
            {
                int px = x + gx;
                int py = y + gy;
                if (px >= 0 && px < ancho && py >= 0 && py < alto)
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
    }
}

