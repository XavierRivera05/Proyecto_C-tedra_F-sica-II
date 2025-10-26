using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //para poder cambiar de escena

public class src_botones : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //cambiar según el orden
    }

    public void Salir()
    {
        Debug.Log("Comprobar salir XD");
        Application.Quit();  //quitar la aplicación, funciona solo al exportar obviamente
    }
}
