
namespace Massini.Flamet2.Api.Level1.Enums
{
    [Flags]
    public enum FeatureLevel
    {
        /// <summary>
        /// Indicates that the adapter can't be used by Flamet.
        /// </summary>
        None = 0,
        Level1 = 1 << 0,
        Level2 = 1 << 1 | Level1,
        Level3 = 1 << 2 | Level2,
    }
}
