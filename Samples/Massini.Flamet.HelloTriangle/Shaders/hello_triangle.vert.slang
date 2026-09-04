struct VertexInput
{
    float4 Position : POSITION;
    float3 Color    : COLOR;
};

struct VertexOutput
{
    float4 Position : SV_Position;
    float3 Color    : COLOR;
};

[shader("vertex")]
VertexOutput main(VertexInput input)
{
    VertexOutput output;

    output.Position = input.Position;
    output.Color = input.Color;

    return output;
}