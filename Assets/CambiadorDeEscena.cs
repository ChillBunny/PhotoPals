using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar


    // Método llamado por el botón al ser presionado
    public void CambiarEscena()
    {
        // Cambia a la nueva escena
        SceneManager.LoadScene(1);
    }
}