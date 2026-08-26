

using Massini.Core;
using Massini.Coat.Classes;
using Massini.Coat.Structs;

namespace Massini.Coat.Interfaces
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