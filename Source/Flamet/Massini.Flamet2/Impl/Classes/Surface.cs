
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;
using Massini.Flamet2.Api.Level1.Extensions;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Surface : ISurface1
    {
        public Surface(Device i_device, in SurfaceCreateParams i_createParams)
        {
            Instance instance = i_device.Instance;
            
            VkSurfaceKHR_T* surfacePtr = null;
            if (i_createParams.TryGetNext(out SurfaceWindowsCreateParams renderSurfaceWindowsCreateParams))
            {
                VkWin32SurfaceCreateInfoKHR surfaceCreateInfoKhr = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR,
                    pNext = null,
                    hinstance = (HINSTANCE__*)renderSurfaceWindowsCreateParams.p_ptr_hinstance,
                    hwnd = (HWND__*)renderSurfaceWindowsCreateParams.p_ptr_hwnd,
                };

                Vk.vkCreateWin32SurfaceKHR(instance.VkInstancePtr, &surfaceCreateInfoKhr, null, &surfacePtr);
            }
            else if (i_createParams.TryGetNext(out SurfaceWaylandCreateParams renderSurfaceWaylandCreateParams))
            {
                VkWaylandSurfaceCreateInfoKHR surfaceCreateInfoKhr = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR,
                    pNext = null,
                    display = (VkWaylandSurfaceCreateInfoKHR.wl_display*)renderSurfaceWaylandCreateParams.p_ptr_display,
                    surface = (VkWaylandSurfaceCreateInfoKHR.wl_surface*)renderSurfaceWaylandCreateParams.p_ptr_surface,
                };

                Vk.vkCreateWaylandSurfaceKHR(instance.VkInstancePtr, &surfaceCreateInfoKhr, null, &surfacePtr);
            }
            else if (i_createParams.TryGetNext(out SurfaceXlibCreateParams renderSurfaceXlibCreateParams))
            {
                VkXlibSurfaceCreateInfoKHR surfaceCreateInfoKhr = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR,
                    pNext = null,
                    dpy = (_XDisplay*)renderSurfaceXlibCreateParams.p_ptr_display,
                    window = (UIntPtr)renderSurfaceXlibCreateParams.p_window,
                };

                Vk.vkCreateXlibSurfaceKHR(instance.VkInstancePtr, &surfaceCreateInfoKhr, null, &surfacePtr);
            }
            else
            {
                throw new Exception("Unable to create surface with given parameters.");
            }
            
            m_ptr_surface = surfacePtr;
            m_surfaceInfo = new SurfaceInfo()
            {
                Id = Rid.NewId(),
                Device = i_device,
            };
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_surfaceInfo.Device;
                
                m_isDisposed = true;
                Vk.vkDestroySurfaceKHR(device.Instance.VkInstancePtr, m_ptr_surface, null);
            }
        }

        public SurfaceInfo GetInfo()
        {
            return m_surfaceInfo;
        }

        public void a()
        {
            Device device = (Device)m_surfaceInfo.Device;
            VkSurfaceCapabilitiesKHR caps = new VkSurfaceCapabilitiesKHR();
            Vk.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(device.Adapter.VkPhysicalDevicePtr, m_ptr_surface, &caps);
            
        }
        
        internal VkSurfaceKHR_T* VkSurfacePtr => m_ptr_surface;
        
        private bool m_isDisposed = false;
        private readonly SurfaceInfo m_surfaceInfo;
        private readonly VkSurfaceKHR_T* m_ptr_surface;
    }   
}