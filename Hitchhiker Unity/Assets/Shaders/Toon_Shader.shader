Shader "Custom/Lighting/Toon_Shader" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Levels ("Number of Cels", Range(1.0, 20.0)) = 1.0
		_Ambient("Ambient Intensity",  Range(0.0, 0.5)) = 0.1
		_AmbientHue("Ambient Hue", Color) = (0.0, 0.0, 0.0, 1.0)
	}

	SubShader {
		Tags { "RenderType"="Opaque" "LightMode"="ForwardBase"}

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
		
			#include "UnityCG.cginc"

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : NORMAL;
			};

			float _Levels;

			float CelShading(float3 normal, float3 lightDirection) {
				float illumination = max(0.0, dot(normalize(normal), normalize(lightDirection)));
				return floor(illumination * _Levels) / (_Levels - 0.5);
			}

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert (appdata_full v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.worldNormal = mul(v.normal.xyz, (float3x3) unity_WorldToObject);
				return o;
			}

			fixed4 _LightColor0;
			fixed4 _AmbientHue;
			half _Ambient;

			fixed4 frag (v2f i) : SV_TARGET {
				fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb *= saturate(CelShading(i.worldNormal, _WorldSpaceLightPos0.xyz) + _Ambient + _AmbientHue.rgb) * _LightColor0.rgb;
				return col;
			}

			ENDCG
		}
	}
}
