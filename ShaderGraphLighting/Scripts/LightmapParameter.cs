using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class LightmapParameter : MonoBehaviour
{
    private MeshRenderer renderer;

    [SerializeField] public Vector4 lightmapOffset;
    [SerializeField] public string paramName = "_LightmapOffset";

#if UNITY_EDITOR

    void OnEnable()
    {
        Lightmapping.bakeCompleted += BakeComplete;
        renderer = GetComponent<MeshRenderer>();
    }

    void BakeComplete()
    {
        lightmapOffset = renderer.lightmapScaleOffset;
    }
#endif


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.sharedMaterial.SetVector(paramName, lightmapOffset);
    }


}
