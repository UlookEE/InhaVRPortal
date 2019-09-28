Shader "QuantumTheory/UCP Road Lines Gamma" {
	Properties {
		
		_MainTex ("Albedo", 2D) = "white" {}
		_MetallicGlossMap("Material",2D) = "white" {}
		_BumpMap("Normal",2D) = "bump"{}
		_PaintCoverage("Paint Coverage", Range(2, 8)) = 4
		_LineColor("Line Color", Color) = (0.9,1,0,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MetallicGlossMap;
		sampler2D _BumpMap;
		float4 _LineColor;
		float _PaintCoverage;

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float4 vertColor : COLOR;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 m = tex2D(_MetallicGlossMap, IN.uv_MainTex);			
			
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
			o.Metallic = m.r;
			o.Smoothness = m.a;
			o.Occlusion = m.g;

			float a = ((c.rgb - 0.5) * _PaintCoverage) + 0.5;
			float b = saturate((a * -4))*0.6;
			o.Albedo = c.rgb+(((_LineColor * IN.vertColor.r))*b);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
