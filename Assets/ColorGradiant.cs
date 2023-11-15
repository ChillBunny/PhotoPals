using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradiant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var gradient = new Gradient();

        // Blend color from red at 0% to blue at 100%
        var colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(Color.red, 0.0f);
        colors[1] = new GradientColorKey(Color.blue, 1.0f);

        // Blend alpha from opaque at 0% to transparent at 100%
        var alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(0.0f, 1.0f);

        gradient.SetKeys(colors, alphas);

        // What's the color at the relative time 0.25 (25%) ?
        Debug.Log(gradient.Evaluate(0.25f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
