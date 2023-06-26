using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FakeLight : MonoBehaviour
{
    public Material[] Mats;
    
    public Color color;
    public float intensity = 1;
    public float radius = 1;
    
    public bool inheritFromLight;
    private Light _light;
    
    private static readonly int PointLightPosition = Shader.PropertyToID("_PointLight_Position");
    private static readonly int PointLightColor = Shader.PropertyToID("_PointLight_Color");
    private static readonly int PointLightRadius = Shader.PropertyToID("_PointLight_Radius");

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 1);
    }

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
            radius = _light.range;
        }
        
        foreach (var Mat in Mats)
        {
            Mat.SetVector(PointLightPosition, transform.position);
            Mat.SetColor(PointLightColor, color);
            Mat.SetFloat(PointLightRadius, radius);
        }
        
    }
}
