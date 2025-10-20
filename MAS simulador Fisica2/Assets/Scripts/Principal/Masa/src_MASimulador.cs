using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_MASimulador : MonoBehaviour
{
    // Variables principales (públicas y privadas)
    public float amplitud = 2f;
    public float masa = 1f;
    public float k = 5f;
    public float fifi = 0f;
    public float omega;
    private float tiempo;
    
    [HideInInspector] public bool pausado = false;
    [HideInInspector] public float tiempoTotal = 0f;
    
    void Start()
    {
        omega = Mathf.Sqrt(k / masa); // Fórmula frecuencia angular con Mathf
        tiempo = 0; // Inicializar el tiempo en 0s
        tiempoTotal = 0f;
    }

    void Update()
    {
        if (!pausado)
        {
            tiempo += Time.deltaTime; // Tiempo transcurrido
            tiempoTotal += Time.deltaTime;
            
            float x = amplitud * Mathf.Cos(omega * tiempo + fifi); // Fórmula de posición
            transform.position = new Vector3(x, transform.position.y, 0); // Actualizar pos del obj
        }
    }

    // Actualizar el valor de la masa y actualizar frecuencia angular (función)
    public void ActualizarMasita(float masaNueva) // Se crea una nueva variable
    {
        masa = masaNueva;
        omega = Mathf.Sqrt(k / masa);
    }
    
    // Actualizar constante K y recalcular omega
    public void ActualizarConstante(float kNueva)
    {
        k = kNueva;
        omega = Mathf.Sqrt(k / masa);
    }
    
    // Alternar pausa
    public void AlternarPausa()
    {
        pausado = !pausado;
    }

    // ========== FUNCIONES DE ENERGÍA ==========
    
    // Obtener posición actual
    public float GetPosicion()
    {
        return amplitud * Mathf.Cos(omega * tiempo + fifi);
    }

    // Obtener velocidad actual (CORREGIDO)
    public float GetVelocidad()
    {
        return -amplitud * omega * Mathf.Sin(omega * tiempo + fifi);
    }

    // Calcular energía cinética: Ec = (1/2) * m * v²
    public float GetEnergiaCinetica()
    {
        float v = GetVelocidad();
        return 0.5f * masa * v * v;
    }

    // Calcular energía potencial: Ep = (1/2) * k * x²
    public float GetEnergiaPotencial()
    {
        float x = GetPosicion();
        return 0.5f * k * x * x;
    }

    // Calcular energía mecánica total: Em = (1/2) * k * A²
    public float GetEnergiaMecanica()
    {
        return 0.5f * k * amplitud * amplitud;
    }
}