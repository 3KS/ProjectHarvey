Shader "Caveman/Adjustable Bumped Specular" {
	Properties {
		_Color ("Color Tint", Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white"{}
		_BumpMap("Normalmap", 2D) = "bump"{}
		_BumpPow ("Normalmap Strength", Range (3, 0)) = 0
		_SpecMap("Specular Map", 2D) = "black"{}
		_SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1.0)
		_SpecPow("Specular Strength", Range(1,0.01)) = 0.5
	}
	
	SubShader {
		Tags { "SHADOWSUPPORT"="true" "QUEUE"="Transparent" "IgnoreProjector"="true" "RenderType"="Transparent" }
     	LOD 300
 	 	Pass {
        	ZWrite On
        	ColorMask 0
    	}
    	
		CGPROGRAM
		#pragma surface surf BlinnPhong alpha
		#pragma exclude_renderers flash
		
		fixed4 _Color;
		sampler2D _MainTex;
		sampler2D _BumpMap;
		float _BumpPow;
		sampler2D _SpecMap;
		float _SpecPow;
		
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_SpecMap;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 tempColor = tex2D(_MainTex, IN.uv_MainTex) * _Color;
     		o.Albedo = tempColor.rgb;
     		o.Alpha = tempColor.a;
     		
			fixed3 normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
     		normal.z = _BumpPow;
		    o.Normal = normalize(normal);
    		
    		fixed4 specMap = tex2D(_SpecMap, IN.uv_SpecMap) * _SpecColor;
    		o.Specular = _SpecPow;
			o.Gloss = specMap.rgb;
		}
		ENDCG
	}
	Fallback "Diffuse"
}