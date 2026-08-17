
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Sugar.Classes.Reflection
{
    public class SetBindingReflection
    {
        /// <summary>
        /// Binding name.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Binding index.
        /// </summary>
        public required uint BindingNumber { get; init; }

        /// <summary>
        /// Array dimensions.
        /// </summary>
        public required uint[] Dimensions { get; init; }

        public required uint Count { get; init; }

        /// <summary>
        /// True if the binding is used in the shader.
        /// </summary>
        public required bool Accessed { get; init; }

        public required EntryType EntryType { get; init; }

        public required EntryMode EntryMode { get; init; }

        public required ShaderStageFlags ShaderStage { get; init; }

        /// <summary>
        /// The set this binding belongs to.
        /// </summary>
        public required uint SetNumber { get; init; }
    }
}