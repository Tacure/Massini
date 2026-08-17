

using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Structs;

namespace Massini.Graphics.VkAL.Interfaces
{
    public interface IResource
    {
        /// <summary>
        /// The unique identifier of the resource for the current execution.
        /// </summary>
        public ResId Id { get; }

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