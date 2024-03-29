Shader "Custom/SemiTransparent"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Pass {
            ZWrite On
            ColorMask 0
        }

        UsePass "Transparent/Diffuse/FORWARD"
    }
    FallBack "Transparent/VertexLit"
}
