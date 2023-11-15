using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityTransition : MonoBehaviour
{
    public float transitionDuration = 2f; // Duración de la transición en segundos
    public int numLoops = 3; // Número de veces que se repetirá la transición
    private float currentDuration = 0f;
    private Color originalColor;
    private Color targetColor = new Color(1f, 1f, 1f, 0f); // Color original con opacidad reducida
    private bool increasingOpacity = true; // Comienza con aumento de opacidad
    private int loopCount = 0;

    private void Start()
    {
        // Almacenar el color original del objeto
        originalColor = GetComponent<Image>().color;
    }

    private void Update()
    {
        // Incrementar el tiempo actual
        currentDuration += Time.deltaTime;

        // Calcular el factor de interpolación
        float t = Mathf.Clamp01(currentDuration / transitionDuration);

        // Invertir la dirección de la transición si la opacidad llega a 0
        if (t >= 1f && !increasingOpacity)
        {
            targetColor.a = 1f; // Establecer la opacidad al máximo
            increasingOpacity = true; // Cambiar la dirección de la transición
            currentDuration = 0f; // Reiniciar el tiempo actual
        }

        // Interpolar entre el color original y el color objetivo
        Color lerpedColor = Color.Lerp(originalColor, targetColor, t);

        // Aplicar el color interpolado al objeto
        GetComponent<Image>().color = lerpedColor;

        // Verificar si la transición ha terminado
        if (currentDuration >= transitionDuration)
        {
            currentDuration = 0f;

            // Cambiar dirección de la transición (de aumento a disminución o viceversa)
            increasingOpacity = !increasingOpacity;

            // Incrementar el contador de bucles
            loopCount++;

            // Verificar si se alcanzó el número máximo de bucles
            if (loopCount >= numLoops)
            {
                // Puedes agregar lógica adicional aquí, como desactivar la transición
                // o realizar alguna acción después de que se complete la animación deseada.
                enabled = false; // Desactiva el script después de completar los bucles.
            }
        }
    }
}
