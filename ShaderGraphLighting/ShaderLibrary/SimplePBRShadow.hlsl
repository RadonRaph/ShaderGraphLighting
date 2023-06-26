
#ifdef UNIVERSAL_LIGHTING_INCLUDED
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
#endif


void GetShadowCoord_half(float3 PositionWS, out half4 shadowCoord)
{
    shadowCoord = 0;
    #ifdef UNIVERSAL_LIGHTING_INCLUDED
    shadowCoord = TransformWorldToShadowCoord(PositionWS);
    #endif
 
}

void GetMainLightShadow_half(half4 shadowCoord, out half shadowStrength)
{
    shadowStrength = 1;
    
    #ifdef UNIVERSAL_LIGHTING_INCLUDED
    shadowStrength = MainLightRealtimeShadow(shadowCoord);
    #endif
}

void MainLightRealtimeShadow_half(float4 shadowCoord, out half shadowStrength)
{
    shadowStrength = 1;
    #ifdef UNIVERSAL_LIGHTING_INCLUDED

    ShadowSamplingData shadowSamplingData = GetMainLightShadowSamplingData();
    half4 shadowParams = GetMainLightShadowParams();
    shadowStrength = SampleShadowmap(TEXTURE2D_ARGS(_MainLightShadowmapTexture, sampler_MainLightShadowmapTexture), shadowCoord, shadowSamplingData, shadowParams, false);
    #endif

}