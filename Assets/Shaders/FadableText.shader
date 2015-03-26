Shader "Caveman/Fadable Text" {
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_TextColor("Text Color", Color) = (1, 1, 1, 1)
		_TextFade ("Text Opacity", Range(2.0, 0)) = 2.0
	}
	SubShader 
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
		
				

		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			Lighting On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			
			struct v2f {
				float4 pos : SV_POSITION;
				fixed4 color : COLOR;
				float2  uv : TEXCOORD3;
				float3 localPos : TEXCOORD2;
			};

            float4 _MainTex_ST;
			
			float4 _TextColor;
			float _TextFade;
			
			v2f vert (appdata_base v) {
				v2f o;
				o.localPos = v.vertex.xyz;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
      		fixed4 frag (v2f i) : COLOR0 { 
      			half4 texalpha = tex2D (_MainTex, i.uv);
      			half4 texcol = _TextColor;
      			texcol.a = texalpha.a / pow(i.localPos.x, _TextFade);
            	return texcol ;
      		}
			ENDCG
		}

	} 
	FallBack "Diffuse"
}
