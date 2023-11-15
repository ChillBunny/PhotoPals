using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiadorDePaneles : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    void Start()
    {
        // Asegúrate de que solo uno de los paneles esté activo al inicio
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void CambiarPanel()
    {
        // Cambia la visibilidad de los paneles al presionar el botón
        panel1.SetActive(!panel1.activeSelf);
        panel2.SetActive(!panel2.activeSelf);
    }
}