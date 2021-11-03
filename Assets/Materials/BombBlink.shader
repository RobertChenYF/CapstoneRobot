// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BombBlink"
{
	Properties
	{
		_Texture("Texture", 2D) = "white" {}
		_intensity("intensity", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Texture;
		uniform float4 _Texture_ST;
		uniform float _intensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Texture = i.uv_texcoord * _Texture_ST.xy + _Texture_ST.zw;
			float4 tex2DNode2 = tex2D( _Texture, uv_Texture );
			o.Albedo = tex2DNode2.rgb;
			float ifLocalVar17 = 0;
			if( _intensity <= 8.5 )
				ifLocalVar17 = 0.0;
			else
				ifLocalVar17 = _intensity;
			float mulTime10 = _Time.y * (1.0 + (ifLocalVar17 - 0.0) * (30.0 - 1.0) / (10.0 - 0.0));
			float4 color14 = IsGammaSpace() ? float4(4,1.392133,0,0) : float4(21.11213,2.070607,0,0);
			o.Emission = ( tex2DNode2 * ( ( cos( mulTime10 ) * color14 ) * _intensity ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18921
678;62;1156;1317;1787.277;463.6163;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;15;-1371.969,101.1843;Inherit;False;Property;_intensity;intensity;2;0;Create;True;0;0;0;False;0;False;0;9.25;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-1435.274,232.3327;Inherit;False;Constant;_0;0;3;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ConditionalIfNode;17;-1139.407,72.05542;Inherit;False;False;5;0;FLOAT;0;False;1;FLOAT;8.5;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;16;-941.9686,12.1843;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;1;False;4;FLOAT;30;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;10;-755.2635,267.3654;Inherit;False;1;0;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;14;-794.8229,444.6264;Inherit;False;Constant;_Color0;Color 0;2;1;[HDR];Create;True;0;0;0;False;0;False;4,1.392133,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CosOpNode;9;-549.1508,265.3976;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;1;-544.2916,-80.58429;Inherit;True;Property;_Texture;Texture;0;0;Create;True;0;0;0;False;0;False;None;79566289aa9b5754fa1707747c2cd3b1;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-446.4826,393.4182;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;2;-274.2916,-57.58429;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-218.8489,192.6297;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;5;-687.1916,124.3159;Inherit;False;Property;_emission;emission;1;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CosTime;8;-735.2005,-67.44531;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;50.05764,115.2063;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;260.2353,26.81469;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;BombBlink;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;17;0;15;0
WireConnection;17;2;15;0
WireConnection;17;3;18;0
WireConnection;17;4;18;0
WireConnection;16;0;17;0
WireConnection;10;0;16;0
WireConnection;9;0;10;0
WireConnection;7;0;9;0
WireConnection;7;1;14;0
WireConnection;2;0;1;0
WireConnection;11;0;7;0
WireConnection;11;1;15;0
WireConnection;4;0;2;0
WireConnection;4;1;11;0
WireConnection;0;0;2;0
WireConnection;0;2;4;0
ASEEND*/
//CHKSM=A8C7FBD0A667C104AD94781B96F4C8FB40320D13