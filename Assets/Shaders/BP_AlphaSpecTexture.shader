Shader "BP/Basic/AlphaSpecTexture" {
	Properties {
		_MainTex("Texture", 2D) = "white"{}
		_BumpMap("BumpMap", 2D) = "bump"{}
		_SpecMap("Specular Map", 2D) = "black"{}
		_SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1.0)
		_SpecPow("Specular Strength", Range(0,1)) = 0.5
		_Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
	}
	
	SubShader {
		Tags {"RenderType" = "Opaque" "Queue" = "AlphaTest"}
		CGPROGRAM
		#pragma surface surf BlinnPhong alphatest:_Cutoff
		#pragma exclude_renderers flash
		
		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _SpecMap;
		float _SpecPow;
		
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_SpecMap;
		};
		
		
		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 diffTex = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 normMap = tex2D(_BumpMap, IN.uv_BumpMap);
			fixed4 specMap = tex2D(_SpecMap, IN.uv_SpecMap);
			
			o.Albedo = diffTex.rgb;
			o.Normal = UnpackNormal(normMap);
			o.Specular = _SpecPow;
			o.Gloss = specMap.rgb;
			o.Alpha = diffTex.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}