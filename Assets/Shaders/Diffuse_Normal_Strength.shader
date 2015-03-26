Shader "Caveman/Adjustable Bumped Diffuse" {
 Properties {
     _Color ("Color Tint", Color) = (1,1,1,1)
     _MainTex ("Base (RGB)", 2D) = "white" {}
     _BumpMap ("Normalmap", 2D) = "bump" {}
     
     // Slider to control fading between normalmaps
     _BumpMapSlider ("Normalmap Strength", Range (3, 0)) = 0
     
}
 
 SubShader {
     Tags { "RenderType"="Opaque" }
     LOD 300
 
 CGPROGRAM
 #pragma surface surf Lambert
 
 sampler2D _MainTex;
 sampler2D _BumpMap;
 fixed4 _Color;
  float _BumpMapSlider;
 
 struct Input {
     float2 uv_MainTex;
     float2 uv_BumpMap;
 };
 
 void surf (Input IN, inout SurfaceOutput o) {
     fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
     o.Albedo = c.rgb;
     o.Alpha = c.a;
 
     // Read values from _BumpMap and _BumpMap2
     fixed3 normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
     normal.z = _BumpMapSlider;     
     // Interpolater between them and set the result to the o.Normal
     o.Normal = normalize(normal);
 }
 ENDCG  
 }
 
 FallBack "Bumped Diffuse"
 }
 