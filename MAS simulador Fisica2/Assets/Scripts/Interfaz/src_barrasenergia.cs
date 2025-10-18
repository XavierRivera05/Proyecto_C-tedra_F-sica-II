using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class src_barrasenergia : MonoBehaviour
{
   public src_MASimulador masimulador;
   public Image barraCinetica;
   public Image barraPotencial;
   public Image barraMecanica;

    void Update()
    {
        if (masimulador == null) return;

        float Ec = masimulador.GetEnergiaCinetica();
        float Ep = masimulador.GetEnergiaPotencial();
        float Em = masimulador.GetEnergiaMecanica();

        float maxE = Em; //energía total constante

        barraCinetica.fillAmount = Ec / maxE;
        barraPotencial.fillAmount = Ep / maxE;
        barraMecanica.fillAmount = Em / maxE;
    }
}
