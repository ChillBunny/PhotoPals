using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour
{
     public bool presionado = false;
     public float velocidad = 600f;

    public void AlternarRotacion()
    {
        presionado = !presionado;

        if (!presionado)
        {
            transform.rotation = Quaternion.identity;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (presionado)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * velocidad); // Ajusta la velocidad de rotación como desees.
        }        
    }
}

