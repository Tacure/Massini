
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Extensions;
using Massini.Graphics.VkAL.Structs;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe class Surface : IDisposable
    {
        public Instance Instance => throw new NotImplementedException();

        public VkSurfaceKHR_T* VkSurfacePtr => m_ptr_surface;

        public static Surface Create(Instance i_instance, in SurfaceCreateParams i_createParams)
        {
            VkSurfaceKHR_T* vkSurface = null;
            if (i_createParams.TryGetNext(out SurfaceWindowsCreateParams renderSurfaceWindowsCreateParams))
            {
                VkWin32SurfaceCreateInfoKHR surfaceCreateInfoKhr = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR,
                    pNext = null,
                    hinstance = (HINSTANCE__*)renderSurfaceWindowsCreateParams.p_ptr_hinstance,
                    hwnd = (HWND__*)renderSurfaceWindowsCreateParams.p_ptr_hwnd,
                };

                Vk.vkCreateWin32SurfaceKHR(i_instance.VkInstancePtr, &surfaceCreateInfoKhr, null, &vkSurface);
            }
            else if (i_createParams.TryGetNext(out SurfaceWaylandCreateParams renderSurfaceWaylandCreateParams))
            {
                VkWaylandSurfaceCreateInfoKHR surfaceCreateInfoKhr = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR,
                    pNext = null,
                    display = renderSurfaceWaylandCreateParams.p_ptr_display,
                    surface = renderSurfaceWaylandCreateParams.p_ptr_surface,
                };

                Vk.vkCreateWaylandSurfaceKHR(i_instance.VkInstancePtr, &surfaceCreateInfoKhr, null, &vkSurface);
            }
            else if (i_createParams.TryGetNext(out SurfaceXlibCreateParams renderSurfaceXlibCreateParams))
            {
                VkXlibSurfaceCreateInfoKHR surfaceCreateInfoKhr = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR,
                    pNext = null,
                    dpy = renderSurfaceXlibCreateParams.p_ptr_display,
                    window = renderSurfaceXlibCreateParams.p_window,
                };

                Vk.vkCreateXlibSurfaceKHR(i_instance.VkInstancePtr, &surfaceCreateInfoKhr, null, &vkSurface);
            }
            else
            {
                throw new Exception("Unable to create surface with given parameters.");
            }

            return new Surface(i_createParams.p_label, i_instance, vkSurface);
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                Vk.vkDestroySurfaceKHR(m_instance.VkInstancePtr, m_ptr_surface, null);
            }
        }

        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly Instance m_instance;
        private readonly VkSurfaceKHR_T* m_ptr_surface;

        private Surface(string i_label, Instance i_instance, VkSurfaceKHR_T* i_ptr_surface)
        {
            m_label = i_label;
            m_instance = i_instance;
            m_ptr_surface = i_ptr_surface;
        }
    }
}
