

using Massini.Core;
using Massini.Flamet.Structs;
using Massini.Flamet.Classes;

namespace Massini.Flamet.Interfaces
{
    public interface IResource
    {
        /// <summary>
        /// The unique identifier of the resource for the current execution.
        /// </summary>
        public Rid Id { get; }

        /// <summary>
        /// The device that created the resource.
        /// </summary>
        public Device Device { get; }

        /// <summary>
        /// Indicates whether the resource has been disposed.
        /// </summary>
        public bool IsDisposed { get; }
    }
}