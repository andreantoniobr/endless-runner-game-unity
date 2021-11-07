float4 ObjectToCurvedClipPos(float3 vertex, float curveStrength) 
{
	float4 clipPos = UnityObjectToClipPos(vertex);

	float dist = UNITY_Z_0_FAR_FROM_CLIPSPACE(clipPos.z);

	clipPos.y -= curveStrength * dist * dist * _ProjectionParams.x;

	return clipPos;
}