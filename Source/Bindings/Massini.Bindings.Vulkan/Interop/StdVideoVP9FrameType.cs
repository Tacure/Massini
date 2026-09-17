namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum StdVideoVP9FrameType : uint
    {
        STD_VIDEO_VP9_FRAME_TYPE_KEY = 0,
        STD_VIDEO_VP9_FRAME_TYPE_NON_KEY = 1,
        STD_VIDEO_VP9_FRAME_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_VP9_FRAME_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }
}
