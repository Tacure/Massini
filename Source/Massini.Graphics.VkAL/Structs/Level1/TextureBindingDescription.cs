
using Massini.Graphics.VkAL.Classes;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct TextureBindingDescription
    {
        public required TextureView? p_textureView;
        public required Sampler? p_sampler;
    }
}
