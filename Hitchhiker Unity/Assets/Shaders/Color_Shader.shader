Shader "Custom/Camera/Color_Shader" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_Columns("Pixel Column", float) = 160
		_Rows("Pixel Row", float) = 90
		_PaletteTex("Palette Texture", 2D) = "white" {}
	}

	SubShader {
		Cull Off ZWrite Off ZTest Always

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			float _Columns;
			float _Rows;

			sampler2D _MainTex;

			half4 _In0;
			half4 _Out0;
			half4 _In1;
			half4 _Out1;
			half4 _In2;
			half4 _Out2;
			half4 _In3;
			half4 _Out3;

			half _Precision;

			half4 frag (v2f i) : SV_Target
			{

				float2 uv = i.uv;
				uv.x *= _Columns;
				uv.y *= _Rows;
				uv.x = round(uv.x);
				uv.y = round(uv.y);
				uv.x /= _Columns;
				uv.y /= _Rows;

				half4 col = tex2D(_MainTex, uv);

				if (all(col.rgb >= _In0.rgb - _Precision && col.rgb <= _In0.rgb + _Precision))
					return _Out0;

				if (all(col.rgb >= _In1.rgb - _Precision && col.rgb <= _In1.rgb + _Precision))
					return _Out1;

				if (all(col.rgb >= _In2.rgb - _Precision && col.rgb <= _In2.rgb + _Precision))
					return _Out2;

				if (all(col.rgb >= _In3.rgb - _Precision && col.rgb <= _In3.rgb + _Precision))
					return _Out3;

				return col;
			}

			ENDCG
		}
	}
}