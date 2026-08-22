global using VkFlags = uint;

global using VkSampleMask = uint;

global using unsafe PfnVkAllocationFunction = delegate* unmanaged[Cdecl]<
    void*,
    nuint,
    nuint,
    Massini.Bindings.Vulkan.VkSystemAllocationScope,
    void*>;

global using unsafe PfnVkFreeFunction = delegate* unmanaged[Cdecl]<
    void*,
    void*,
    void>;

global using unsafe PfnVkInternalAllocationNotification = delegate* unmanaged[Cdecl]<
    void*,
    nuint,
    Massini.Bindings.Vulkan.VkInternalAllocationType,
    Massini.Bindings.Vulkan.VkSystemAllocationScope,
    void>;

global using unsafe PfnVkInternalFreeNotification = delegate* unmanaged[Cdecl]<
    void*,
    nuint,
    Massini.Bindings.Vulkan.VkInternalAllocationType,
    Massini.Bindings.Vulkan.VkSystemAllocationScope,
    void>;

global using unsafe PfnVkReallocationFunction = delegate* unmanaged[Cdecl]<
    void*,
    void*,
    nuint,
    nuint,
    Massini.Bindings.Vulkan.VkSystemAllocationScope,
    void*>;

global using unsafe PfnVkVoidFunction = delegate* unmanaged[Cdecl]<void>;

global using unsafe PfnVkCreateDebugUtilsMessengerExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkInstance_T*,
    Massini.Bindings.Vulkan.VkDebugUtilsMessengerCreateInfoEXT*,
    Massini.Bindings.Vulkan.VkAllocationCallbacks*,
    Massini.Bindings.Vulkan.VkDebugUtilsMessengerEXT_T**,
    Massini.Bindings.Vulkan.VkResult>;

global using unsafe PfnVkDestroyDebugUtilsMessengerExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkInstance_T*,
    Massini.Bindings.Vulkan.VkDebugUtilsMessengerEXT_T*,
    Massini.Bindings.Vulkan.VkAllocationCallbacks*,
    void>;

global using unsafe PfnVkDebugUtilsMessengerCallbackExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkDebugUtilsMessageSeverityFlagBitsEXT,
    Massini.Bindings.Vulkan.VkDebugUtilsMessageTypeFlagBitsEXT,
    Massini.Bindings.Vulkan.VkDebugUtilsMessengerCallbackDataEXT*,
    void*,
    uint>;

global using unsafe PfnVkCmdPushDescriptorSetKhr = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    Massini.Bindings.Vulkan.VkPipelineBindPoint,
    Massini.Bindings.Vulkan.VkPipelineLayout_T*,
    uint,
    uint,
    Massini.Bindings.Vulkan.VkWriteDescriptorSet*,
    void>;

global using unsafe PfnVkCmdBeginRenderingKhr = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    Massini.Bindings.Vulkan.VkRenderingInfo*,
    void>;

global using unsafe PfnVkCmdEndRenderingKhr = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    void>;

global using unsafe PfnVkSignalSemaphoreKhr = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkDevice_T*,
    Massini.Bindings.Vulkan.VkSemaphoreSignalInfo*,
    Massini.Bindings.Vulkan.VkResult>;

global using unsafe PfnVkWaitSemaphoresKhr = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkDevice_T*,
    Massini.Bindings.Vulkan.VkSemaphoreWaitInfo*,
    ulong,
    Massini.Bindings.Vulkan.VkResult>;

global using unsafe PfnVkGetSemaphoreCounterValueKhr = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkDevice_T*,
    Massini.Bindings.Vulkan.VkSemaphore_T*,
    ulong*,
    Massini.Bindings.Vulkan.VkResult>;

global using unsafe PfnVkSetDebugUtilsObjectNameExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkDevice_T*,
    Massini.Bindings.Vulkan.VkDebugUtilsObjectNameInfoEXT*,
    Massini.Bindings.Vulkan.VkResult>;

global using unsafe PfnVkCmdSetScissorWithCountExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    Massini.Bindings.Vulkan.VkRect2D*,
    void>;

global using unsafe PfnVkCmdSetViewportWithCountExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    Massini.Bindings.Vulkan.VkViewport*,
    void>;

global using unsafe PfnVkCmdBindVertexBuffers2Ext = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    uint,
    Massini.Bindings.Vulkan.VkBuffer_T**,
    ulong*,
    ulong*,
    ulong*,
    void>;

global using unsafe PfnVkCreateShadersExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkDevice_T*,
    uint,
    Massini.Bindings.Vulkan.VkShaderCreateInfoEXT*,
    Massini.Bindings.Vulkan.VkAllocationCallbacks*,
    Massini.Bindings.Vulkan.VkShaderEXT_T**,
    Massini.Bindings.Vulkan.VkResult>;

global using unsafe PfnVkDestroyShaderExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkDevice_T*,
    Massini.Bindings.Vulkan.VkShaderEXT_T*,
    Massini.Bindings.Vulkan.VkAllocationCallbacks*,
    void>;

global using unsafe PfnVkCmdBindShadersExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    Massini.Bindings.Vulkan.VkShaderStageFlagBits*,
    Massini.Bindings.Vulkan.VkShaderEXT_T**,
    void>;

global using unsafe PfnVkCmdSetPolygonModeExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    Massini.Bindings.Vulkan.VkPolygonMode,
    void>;

global using unsafe PfnVkCmdSetRasterizationSamplesExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    Massini.Bindings.Vulkan.VkSampleCountFlagBits,
    void>;

global using unsafe PfnVkCmdSetSampleMaskExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    Massini.Bindings.Vulkan.VkSampleCountFlagBits,
    uint*,
    void>;

global using unsafe PfnVkCmdSetDepthClampEnableExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    void>;

global using unsafe PfnVkCmdSetLogicOpExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    Massini.Bindings.Vulkan.VkLogicOp,
    void>;

global using unsafe PfnVkCmdSetLogicOpEnableExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    void>;

global using unsafe PfnVkCmdSetVertexInputExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    Massini.Bindings.Vulkan.VkVertexInputBindingDescription2EXT*,
    uint,
    Massini.Bindings.Vulkan.VkVertexInputAttributeDescription2EXT*,
    void>;

global using unsafe PfnVkCmdSetColorBlendEnableExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    uint,
    uint*,
    void>;

global using unsafe PfnVkCmdSetColorBlendEquationExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    uint,
    Massini.Bindings.Vulkan.VkColorBlendEquationEXT*,
    void>;

global using unsafe PfnVkCmdSetColorWriteMaskExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    uint,
    uint*,
    void>;

global using unsafe PfnVkCmdSetAlphaToCoverageEnableExt = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vulkan.VkCommandBuffer_T*,
    uint,
    void>;