struct FragmentInput
{
    float3 Color : COLOR;
};

[shader("fragment")]
float4 main(FragmentInput input) : SV_Target
{
    return float4(input.Color, 1.0);
}