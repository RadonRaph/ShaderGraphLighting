# ShaderGraphLighting
Recreating Unity's lighting shader inside shadergraph to make them more accessible and customizable. 


# Overview 

This project constains subgraphs needed to do Physically Based Rendering (PBR) :
- PointLightPBR : Calculate a point light radiance based on Light Info (direction, radius, color) and surface info (BRDF, normal vector)
- DirectionnalPBR :  Calculate a directionnal light radiance based on Light Info (direction, color) and surface info (BRDF, normal vector)
- BRDF : Gives the BRDF factors used for PBR lighting based on Albedo, Smoothness and Metallic
- GlobalIllumination :  Calculate the indirect lighting and reflection (Lightmap, Skybox, Reflection Probe) -> /!\ Still WIP /!\
- SimplePBRShadow : Return the mainlight shadowmap value for a world pos

This project also constains a CustomPBR shadergraph that uses thoses subgraph in the way Unity does it for the "Lit Shader". 
CustomPBR features are :
- Albedo, Normal, Metallic, Smoothness, Ambient Occlusion and Emission maps or direct value.
- A fake or real directionnal light.
- A fake point light.
- Global Illumination.

Be careful when using the CustomPBR shader for each map there is 3 options : UseTexture, Texture and Value if UseTexture is false the value drives directly, if UseTexture is true the value is a **multiplier** of the texture. 

![Exemple of customPBR use](https://i.imgur.com/kUUHSJw.jpeg)
(Left CustomPBR | Right Unity Lit shader)

Known Issues :
- Reflection probe not working correctly
- High metalness & smothness looks a bit off compared to Unity's lit.
- Lightmap are too bright
- Only MainLight shadows 

Feel free to use and modify it in your projects ! 
