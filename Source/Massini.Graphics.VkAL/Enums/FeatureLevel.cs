
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum FeatureLevel
    {
        /// <summary>
        /// Indicates that the adapter can't be used by the drawing API.
        /// </summary>
        None = 0,
        /// <summary>
        /// Devices that support:
        /// <list type="bullet">
        /// <item><term>VK_KHR_DYNAMIC_RENDERING:</term><description>Used as a replacement for Render Passes.</description></item>
        /// <item><term>VK_KHR_PUSH_DESCRIPTOR:</term><description>Provides easier manipulation of descriptor sets on basic applications.</description></item>
        /// <item><term>VK_KHR_SWAPCHAIN:</term><description>Required for window presentation.</description></item>
        /// <item><term>VK_KHR_DEPTH_STENCIL_RESOLVE:</term><description></description></item>
        /// <item><term>VK_KHR_CREATE_RENDERPASS2:</term><description></description></item>
        /// <item><term>VK_KHR_TIMELINE_SEMAPHORE:</term><description>Used for easier synchronization between the GPU and the CPU.</description></item>
        /// <item><term>VK_EXT_EXTENDED_DYNAMIC_STATE:</term><description>Simplifies the creation of pipelines.</description></item>
        /// <item><term>VK_EXT_DESCRIPTOR_BUFFER:</term><description>Simplifies the creation of pipelines.</description></item>
        /// <item><term>VK_KHR_BUFFER_DEVICE_ADDRESS:</term><description>Allows to get the device address of a buffer.</description></item>
        /// <item><term>VK_KHR_SYNCHRONIZATION_2:</term><description></description></item>
        /// </list>
        /// </summary>
        Level1 = 1 << 0,
        Level2 = 1 << 1 | Level1,
        Level3 = 1 << 2 | Level2,
    }
}
