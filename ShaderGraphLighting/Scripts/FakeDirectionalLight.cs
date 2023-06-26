using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FakeDirectionalLight : MonoBehaviour
{
    public Material[] Mats;
    public Color color;
    public float intensity = 1;
    public bool inheritFromLight;
    private static readonly int DirectionalDirection = Shader.PropertyToID("_Directional_Direction");
    private static readonly int DirectionalColor = Shader.PropertyToID("_Directional_Color");

    private Light _light;
    private static readonly int DirectionalIntensity = Shader.PropertyToID("_Directional_Intensity");

    private void OnEnable()
    {
        if (inheritFromLight)
        {
            _light = GetComponent<Light>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (inheritFromLight)
        {
            color = _light.color;
            intensity = _light.intensity;
        }

        foreach (var Mat in Mats)
        {
            Mat.SetVector(DirectionalDirection, transform.forward.normalized);
            Mat.SetColor(DirectionalColor, color);
            Mat.SetFloat(DirectionalIntensity, intensity);
        }
        
    }
}
