
namespace Massini.Flamet2.Api.Level1.Interfaces
{
    /// <summary>
    /// Represents a chainable struct.
    /// </summary>
    public interface INext
    {
        /// <summary>
        /// The next struct in the chain.
        /// </summary>
        public INext? Next { get; }
    }
}