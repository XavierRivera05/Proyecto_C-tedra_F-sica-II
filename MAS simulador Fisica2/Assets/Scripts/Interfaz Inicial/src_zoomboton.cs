using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class src_zoomboton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 escalaN = Vector3.one;
    public Vector3 escalaH = new Vector3(1.1f, 1.1f, 1f);
    public float velocidad = 5f;

    private bool mouseEncima = false;

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, mouseEncima ? escalaH : escalaN, Time.deltaTime * velocidad);
    }

    public void OnPointerEnter(PointerEventData eventData) => mouseEncima = true;
    public void OnPointerExit(PointerEventData eventData) => mouseEncima = false;

    void OnDisable() //para que regrese al tamaño original al cambiar de panel
    {
        mouseEncima = false;
        transform.localScale = escalaN;
    }
}
