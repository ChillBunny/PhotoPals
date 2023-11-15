using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreDeNuevaEscena;

    // Método llamado por el botón al ser presionado
    public void CambiarEscena()
    {
        // Cambia a la nueva escena
        SceneManager.LoadScene(nombreDeNuevaEscena);
    }
}