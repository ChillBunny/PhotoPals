using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DesactivarDespuesDeTiempo : MonoBehaviour
{
    public float tiempoParaDesactivar = 5f; // Ajusta este valor al tiempo que desees

    void Start()
    {
        // Invoca el método DesactivarGameObject después de 'tiempoParaDesactivar' segundos
        Invoke("DesactivarGameObject", tiempoParaDesactivar);
    }

    void DesactivarGameObject()
    {
        // Desactiva el GameObject al que se adjunta este script
        gameObject.SetActive(false);
    }
}
