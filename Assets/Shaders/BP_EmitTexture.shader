Shader "BP/Basic/EmitTexture" {
	Properties {
		_MainTex("Texture", 2D) = "white"{}
		_BumpMap("BumpMap", 2D) = "bump"{}
		_SpecMap("Specular Map", 2D) = "black"{}
		_SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1.0)
		_SpecPow("Specular Strength", Range(0,1)) = 0.5
		_EmitMap("Emissive Map", 2D) = "black"{}
		_EmitPow("Emissive Power", Range(0, 2)) = 1.0
	}
	
	SubShader {
		Tags {"RenderType" = "Opaque"}
		CGPROGRAM
		#pragma surface surf BlinnPhong
		#pragma exclude_renderers flash
		
		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _SpecMap;
		float _SpecPow;
		sampler2D _EmitMap;
		float _EmitPow;
		
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_SpecMap;
			float2 uv_EmitMap;
		};
		
		
		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 diffTex = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 normMap = tex2D(_BumpMap, IN.uv_BumpMap);
			fixed4 specMap = tex2D(_SpecMap, IN.uv_SpecMap);
			fixed4 emitMap = tex2D(_EmitMap, IN.uv_EmitMap);
			
			o.Albedo = diffTex.rgb;
			o.Normal = UnpackNormal(normMap);
			o.Specular = _SpecPow;
			o.Gloss = specMap.rgb;
			o.Emission = emitMap.rgb * _EmitPow;
		}
		ENDCG
	}
	Fallback "Specular"
}