Shader "Custom/CubeShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DestinationTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Intensity ("Intensity", Range(0, 1)) = 0.5
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
 
        CGPROGRAM
        #pragma surface surf Lambert
 
sampler2D _MainTex;
sampler2D _DestinationTex;
fixed4 _Color;
float _Intensity;
 
struct Input
{
    float2 uv_MainTex;
};
 
void surf(Input IN, inout SurfaceOutput o)
{
    fixed4 texColor1 = tex2D(_MainTex, IN.uv_MainTex);
    fixed4 texColor2 = tex2D(_DestinationTex, IN.uv_MainTex);
    fixed4 blendedColor = lerp(texColor1, texColor2, _Intensity);
    o.Albedo = blendedColor.rgb;
}
        ENDCG
    }
 
FallBack"Diffuse"
}

