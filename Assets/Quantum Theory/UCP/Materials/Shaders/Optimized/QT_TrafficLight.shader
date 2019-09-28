// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "QuantumTheory/UCP Traffic Light"
{
	Properties
	{
		_BaseColor("Base Color", 2D) = "white" {}
		_Material("Material", 2D) = "white" {}
		_Normal("Normal", 2D) = "bump" {}
		_Emissive("Emissive", 2D) = "white" {}
		_RedLight("RedLight", Range( 0 , 1)) = 0
		_YellowLight("YellowLight", Range( 0 , 1)) = 0
		_GreenLight("GreenLight", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform sampler2D _BaseColor;
		uniform float4 _BaseColor_ST;
		uniform sampler2D _Emissive;
		uniform float4 _Emissive_ST;
		uniform float _RedLight;
		uniform float _YellowLight;
		uniform float _GreenLight;
		uniform sampler2D _Material;
		uniform float4 _Material_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _Normal, uv_Normal ) );
			float2 uv_BaseColor = i.uv_texcoord * _BaseColor_ST.xy + _BaseColor_ST.zw;
			o.Albedo = tex2D( _BaseColor, uv_BaseColor ).rgb;
			float2 uv_Emissive = i.uv_texcoord * _Emissive_ST.xy + _Emissive_ST.zw;
			float4 tex2DNode4 = tex2D( _Emissive, uv_Emissive );
			o.Emission = ( ( ( ( tex2DNode4.r * _RedLight ) * float4(1,0,0,0) ) + ( ( tex2DNode4.g * _YellowLight ) * float4(1,1,0,0) ) ) + ( ( tex2DNode4.b * _GreenLight ) * float4(0,1,0,0) ) ).xyz;
			float2 uv_Material = i.uv_texcoord * _Material_ST.xy + _Material_ST.zw;
			float4 tex2DNode2 = tex2D( _Material, uv_Material );
			o.Metallic = tex2DNode2.r;
			o.Smoothness = tex2DNode2.a;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15301
2132;217;1503;936;2080.491;98.54295;1.152081;True;True
Node;AmplifyShaderEditor.RangedFloatNode;16;-1620.814,209.0627;Float;False;Property;_RedLight;RedLight;4;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;17;-1739.477,851.9238;Float;False;Property;_YellowLight;YellowLight;5;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;4;-1711.733,579.5847;Float;True;Property;_Emissive;Emissive;3;0;Create;True;0;0;False;0;857e6867dd745124d9340b68ad03acbb;857e6867dd745124d9340b68ad03acbb;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-1283.485,289.5607;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-1693.394,1092.709;Float;False;Property;_GreenLight;GreenLight;6;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-1269.735,642.7283;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;9;-1290.949,758.225;Float;False;Constant;_Vector1;Vector 1;4;0;Create;True;0;0;False;0;1,1,0,0;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector4Node;7;-1304.699,405.0574;Float;False;Constant;_Vector0;Vector 0;4;0;Create;True;0;0;False;0;1,0,0,0;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-1105.919,708.7266;Float;False;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.Vector4Node;11;-1286.234,1049.323;Float;False;Constant;_Vector2;Vector 2;4;0;Create;True;0;0;False;0;0,1,0,0;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-1265.02,933.8268;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-1119.669,355.5589;Float;False;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-902.8177,572.4094;Float;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-1101.204,999.8251;Float;False;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SamplerNode;3;-407.5,359;Float;True;Property;_Normal;Normal;2;0;Create;True;0;0;False;0;46b802214650afc49b634486d887279d;46b802214650afc49b634486d887279d;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-412.5,-191;Float;True;Property;_BaseColor;Base Color;0;0;Create;True;0;0;False;0;f9823d115e9e37f4288e19d3b0dde984;f9823d115e9e37f4288e19d3b0dde984;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;2;-429.5,109;Float;True;Property;_Material;Material;1;0;Create;True;0;0;False;0;f082090624bbb434f98ec1f8b041f539;f082090624bbb434f98ec1f8b041f539;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-762.5717,862.3289;Float;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;QuantumTheory/UCP Traffic Light;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;4;1
WireConnection;5;1;16;0
WireConnection;8;0;4;2
WireConnection;8;1;17;0
WireConnection;10;0;8;0
WireConnection;10;1;9;0
WireConnection;13;0;4;3
WireConnection;13;1;18;0
WireConnection;6;0;5;0
WireConnection;6;1;7;0
WireConnection;14;0;6;0
WireConnection;14;1;10;0
WireConnection;12;0;13;0
WireConnection;12;1;11;0
WireConnection;15;0;14;0
WireConnection;15;1;12;0
WireConnection;0;0;1;0
WireConnection;0;1;3;0
WireConnection;0;2;15;0
WireConnection;0;3;2;1
WireConnection;0;4;2;4
ASEEND*/
//CHKSM=9207D97606CE40668903D32F4F89B71C1F226E91