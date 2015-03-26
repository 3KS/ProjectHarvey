Shader "Caveman/Adjustable Bumped Diffuse, Crossfade Textures" {
 Properties {
     _Color ("Color Tint", Color) = (1,1,1,1)
     _MainTex1 ("Diffuse 1 (RGB)", 2D) = "white" {}
     _MainTex2 ("Diffuse 2 (RGB)", 2D) = "white" {}
     _BumpMap ("Normalmap", 2D) = "bump" {}
     
     //_Cutoff("Alpha cutoff",Range(0,1))=0.5
     
     _TexSlider ("Diffuse Fade", Range (0, 1)) = 0
     _BumpMapSlider ("Normalmap Strength", Range (3, 0)) = 0
     
}
 
 SubShader {
 Tags { "SHADOWSUPPORT"="true" "QUEUE"="Transparent" "RenderType"="Transparent" }
     LOD 300
 	 Pass {
        ZWrite On
        ColorMask 0
    }
 CGPROGRAM
 #pragma surface surf Lambert alpha
 
 sampler2D _MainTex1;
 sampler2D _MainTex2;
 sampler2D _BumpMap;
 fixed4 _Color;
 //float _Cutoff;
 
 // Remember to add your properties in here also. Check ShaderLab References from manual for more info
 float _TexSlider;
 float _BumpMapSlider;
 
 struct Input {
     float2 uv_MainTex1;
     float2 uv_MainTex2;
     float2 uv_BumpMap;
     
    
 };
 
 void surf (Input IN, inout SurfaceOutput o) {
     fixed4 tex1 = tex2D(_MainTex1, IN.uv_MainTex1) * _Color;
     fixed4 tex2 = tex2D(_MainTex2, IN.uv_MainTex2) * _Color;
    // float ca = tex2D(_MainTex1, IN.uv_MainTex1).a;

     o.Albedo = lerp(tex1.rgb, tex2.rgb, _TexSlider);
     //if (ca > _Cutoff)
   	o.Alpha = lerp(tex1.a, tex2.a, _TexSlider);
	// else
   		//o.Alpha = 0;

 
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
 