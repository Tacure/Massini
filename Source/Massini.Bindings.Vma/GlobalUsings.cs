global using VkFlags = uint;

// PfnVmaAllocateDeviceMemoryFunction unsafe delegate definition.
global using unsafe PfnVmaAllocateDeviceMemoryFunction = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vma.Handles.VmaAllocator*, 
    uint, 
    Massini.Bindings.Vulkan.VkDeviceMemory_T*, 
    ulong, 
    void*, 
    void>;

global using unsafe PfnVmaFreeDeviceMemoryFunction = delegate* unmanaged[Cdecl]<
    Massini.Bindings.Vma.Handles.VmaAllocator*, 
    uint, 
    Massini.Bindings.Vulkan.VkDeviceMemory_T*, 
    ulong, 
    void*, 
    void>;