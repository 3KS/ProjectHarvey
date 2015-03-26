Shader "Caveman/Adjustable Bumped Diffuse, Adjustable Glow" {
 Properties {
     _Color ("Color Tint", Color) = (1,1,1,1)
     _MainTex ("Base (RGB)", 2D) = "white" {}
     _BumpMap ("Normalmap", 2D) = "bump" {}
     _RimColor ("RimColor", Color) = (1, 1, 1, 1)
	 _RimPower ("Rim Power", Range(40.0, 1.0)) = 5.0
     
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
 float4 _RimColor;
 float _RimPower;
 
 struct Input {
     float2 uv_MainTex;
     float2 uv_BumpMap;
     float3 viewDir;
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
     
     half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
	 o.Emission = _RimColor.rgb * pow(rim, _RimPower);
 }
 ENDCG  
 }
 
 FallBack "Bumped Diffuse"
 }
 