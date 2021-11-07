#pragma surface surf ToonRamp vertex:vert
// custom lighting function that uses a texture ramp based
// on angle between light direction and normal
#pragma lighting ToonRamp exclude_path:prepass

sampler2D _Ramp;

inline half4 LightingToonRamp(SurfaceOutput s, half3 lightDir, half atten)
{
#ifndef USING_DIRECTIONAL_LIGHT
	lightDir = normalize(lightDir);
#endif

	half d = dot(s.Normal, lightDir) * 0.5 + 0.5;
	half3 ramp = tex2D(_Ramp, float2(d, d)).rgb;

	half4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
	c.a = 0;
	return c;
}


sampler2D _MainTex;
float4 _Color;
float _CurveStrength;

struct Input {
	float2 uv_MainTex : TEXCOORD0;
};

void vert(inout appdata_full v) {
	float3 clipSpacePos = UnityObjectToClipPos(v.vertex);
	float dist = UNITY_Z_0_FAR_FROM_CLIPSPACE(clipSpacePos.z);
	//v.vertex.y += _CurveStrength * dist * dist * _ProjectionParams.x;
	//v.vertex.xyz += v.normal;
	//UNITY_TRANSFER_FOG(v, v.vertex);
}

void surf(Input IN, inout SurfaceOutput o) {
	half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}