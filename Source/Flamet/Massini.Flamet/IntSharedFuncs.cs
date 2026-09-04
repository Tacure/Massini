using Massini.Bindings.Vulkan;
using Massini.Core.Interop;
using Massini.Flamet.Classes;

namespace Massini.Flamet
{
    internal static class IntSharedFuncs
    {
        public static unsafe void SetObjectLabel(Device i_device, void* i_ptr_object, VkObjectType i_objectType, string i_label)
        {
            var setObjectName = i_device.Adapter.Instance.GetFunctionTable().PfnVkSetDebugUtilsObjectNameExt;
            
            if (setObjectName == null) return;

            using HeapString label = HeapString.CreateUTF8(i_label);
            
            VkDebugUtilsObjectNameInfoEXT debugUtilsObjectNameInfo = new VkDebugUtilsObjectNameInfoEXT
            {
                pNext = null,
                sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_OBJECT_NAME_INFO_EXT,
                pObjectName = (sbyte*)label.RawPtr(),
                objectType = i_objectType,
                objectHandle = (ulong)i_ptr_object,
            };
            
            setObjectName(i_device.VkDevicePtr, &debugUtilsObjectNameInfo);
        }
    }
}