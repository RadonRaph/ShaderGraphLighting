# ShaderGraphLighting
Recreating Unity's lighting shader inside shadergraph to make them more accessible and customizable. 


# Overview 

This project constains subgraphs needed to do Physically Based Rendering (PBR) :
- PointLightPBR : Calculate a point light radiance based on Light Info (direction, radius, color) and surface info (BRDF, normal vector)
- DirectionnalPBR :  Calculate a directionnal light radiance based on Light Info (direction, color) and surface info (BRDF, normal vector)
- BRDF : Gives the BRDF factors used for PBR lighting based on Albedo, Smoothness and Metallic
- GlobalIllumination :  Calculate the indirect lighting and reflection (Lightmap, Skybox, Reflection Probe) -> /!\ Still WIP /!\
- SimplePBRShadow : Return the mainlight shadowmap value for a world pos
- SampleLightmap : Use to get the baked lighting from lightmap. 

This project also constains a CustomPBR shadergraph that uses thoses subgraph in the way Unity does it for the "Lit Shader". 
CustomPBR features are :
- Albedo, Normal, Metallic, Smoothness, Ambient Occlusion and Emission maps or direct value.
- A fake or real directionnal light.
- A fake point light.
- Global Illumination.

Be careful when using the CustomPBR shader for each map there is 3 options : UseTexture, Texture and Value if UseTexture is false the value drives directly, if UseTexture is true the value is a **multiplier** of the texture. 

![Exemple of customPBR use](https://i.imgur.com/kUUHSJw.jpeg)
(Left CustomPBR | Right Unity Lit shader)

# Known Issues :
- Reflection probe not working correctly
- High metalness & smothness looks a bit off compared to Unity's lit.
- Lightmap are too bright : Fixed in V1.1
- Only MainLight shadows 

# How to use :
This repo provides Shadergraph Subgraph needed to do the PBR Lit shader of Unity. They are assembled in a CustomPBR to show to combine them to do PBR lighting.
You can use CustomPBR as a starting point and remove or add subgraphes depanding on your needs. 

/!\ Lightmap advices :
The CustomPBR shader as 2 options for lightmaps, use the BakedGI node that automatically gets the lightmaps and the coordinate for your object from the scene or use the custom lightmap option.

This options allow you to use lightmap baked in another scene in any scene but since it cannot get the lightmap data automatically you need to give it yourself.
So you need to specify wich lightmap texture and direction to use and the offset.

For the offset you can retrieve it from the scene (Could be useful if you want multiple lightmap for one scene) or you can provide it manually. 
Those informations can be found on your mesh renderer when light is baked :

![Lightmap offset illustration](https://i.imgur.com/Y4vWHOa.png)

- Tilling X -> LightmapOffset.X
- Tilling Y -> LightmapOffset.Y
- Offset X -> LightmapOffset.Z
- Offset Y -> LightmapOffset.W 

We made a custom script called LightmapParameter to help you, place it on your gameobject, bake you light and make or save a prefab of your object, then you can use it anywhere with baked lightmap !

Feel free to use and modify it in your projects ! 
