// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Custom/ReduceResolution"
{
	//Properties
	Properties
	{
	//texture
	_MainTex ("Texture", 2D) = "white" {}
	//number of pixels on each collum
	_Colums ("Pixel Colums", float) = 64
	//number of pixel on each row
	_Rows ("Pixel Rows", float) = 64
	}
	//actuall shader
	SubShader
	{
		Cull Off Zwrite Off ZTest Always
		Pass
		{
			CGPROGRAM
			#pragma vertex vert;
			#pragma fragment frag;
			#include "UnityCG.cginc"
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXTCOORD0;
			};
			struct v2f
			{
				float2 uv : TEXTCOORD0;
				float4 vertex : SV_POSITION;
			};
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			float _Colums;
			float _Rows;
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = i.uv;

				uv.u *= _Colums;
				uv.v *= _Rows;

				uv.u = round(uv.u);
				uv.v = round(uv.v);

				uv.u /= _Colums;
				uv.v /= _Rows;

				fixed4 col = text2D(_MainTex, i.uv);

				return col;
			}
			ENDCG
		}
	}
}
