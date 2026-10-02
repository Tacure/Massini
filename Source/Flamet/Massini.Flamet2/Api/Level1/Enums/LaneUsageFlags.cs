
namespace Massini.Flamet2.Api.Level1.Enums
{
    [Flags]
    public enum LaneUsageFlags
    {
        Unknown = 0,
        Graphics = 1 << 0,
        Compute = 1 << 1,
        Transfer = 1 << 2,
    }
}
