using System;
using System.Runtime.InteropServices;
using static Massini.Bindings.Wgpu.WGPUAddressMode;
using static Massini.Bindings.Wgpu.WGPUBackendType;
using static Massini.Bindings.Wgpu.WGPUBlendFactor;
using static Massini.Bindings.Wgpu.WGPUBlendOperation;
using static Massini.Bindings.Wgpu.WGPUBufferBindingType;
using static Massini.Bindings.Wgpu.WGPUCompareFunction;
using static Massini.Bindings.Wgpu.WGPUComponentSwizzle;
using static Massini.Bindings.Wgpu.WGPUCompositeAlphaMode;
using static Massini.Bindings.Wgpu.WGPUCullMode;
using static Massini.Bindings.Wgpu.WGPUFeatureLevel;
using static Massini.Bindings.Wgpu.WGPUFilterMode;
using static Massini.Bindings.Wgpu.WGPUFrontFace;
using static Massini.Bindings.Wgpu.WGPUIndexFormat;
using static Massini.Bindings.Wgpu.WGPULoadOp;
using static Massini.Bindings.Wgpu.WGPUMipmapFilterMode;
using static Massini.Bindings.Wgpu.WGPUOptionalBool;
using static Massini.Bindings.Wgpu.WGPUPowerPreference;
using static Massini.Bindings.Wgpu.WGPUPresentMode;
using static Massini.Bindings.Wgpu.WGPUPrimitiveTopology;
using static Massini.Bindings.Wgpu.WGPUSType;
using static Massini.Bindings.Wgpu.WGPUSamplerBindingType;
using static Massini.Bindings.Wgpu.WGPUStencilOperation;
using static Massini.Bindings.Wgpu.WGPUStorageTextureAccess;
using static Massini.Bindings.Wgpu.WGPUStoreOp;
using static Massini.Bindings.Wgpu.WGPUTextureAspect;
using static Massini.Bindings.Wgpu.WGPUTextureDimension;
using static Massini.Bindings.Wgpu.WGPUTextureFormat;
using static Massini.Bindings.Wgpu.WGPUTextureSampleType;
using static Massini.Bindings.Wgpu.WGPUTextureViewDimension;
using static Massini.Bindings.Wgpu.WGPUVertexStepMode;

namespace Massini.Bindings.Wgpu
{
    public static unsafe partial class Wgpu
    {
        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_None = 0x0000000000000000;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_MapRead = 0x0000000000000001;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_MapWrite = 0x0000000000000002;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_CopySrc = 0x0000000000000004;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_CopyDst = 0x0000000000000008;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_Index = 0x0000000000000010;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_Vertex = 0x0000000000000020;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_Uniform = 0x0000000000000040;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_Storage = 0x0000000000000080;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_Indirect = 0x0000000000000100;

        [NativeTypeName("const WGPUBufferUsage")]
        public const ulong WGPUBufferUsage_QueryResolve = 0x0000000000000200;

        [NativeTypeName("const WGPUColorWriteMask")]
        public const ulong WGPUColorWriteMask_None = 0x0000000000000000;

        [NativeTypeName("const WGPUColorWriteMask")]
        public const ulong WGPUColorWriteMask_Red = 0x0000000000000001;

        [NativeTypeName("const WGPUColorWriteMask")]
        public const ulong WGPUColorWriteMask_Green = 0x0000000000000002;

        [NativeTypeName("const WGPUColorWriteMask")]
        public const ulong WGPUColorWriteMask_Blue = 0x0000000000000004;

        [NativeTypeName("const WGPUColorWriteMask")]
        public const ulong WGPUColorWriteMask_Alpha = 0x0000000000000008;

        [NativeTypeName("const WGPUColorWriteMask")]
        public const ulong WGPUColorWriteMask_All = 0x000000000000000F;

        [NativeTypeName("const WGPUMapMode")]
        public const ulong WGPUMapMode_None = 0x0000000000000000;

        [NativeTypeName("const WGPUMapMode")]
        public const ulong WGPUMapMode_Read = 0x0000000000000001;

        [NativeTypeName("const WGPUMapMode")]
        public const ulong WGPUMapMode_Write = 0x0000000000000002;

        [NativeTypeName("const WGPUShaderStage")]
        public const ulong WGPUShaderStage_None = 0x0000000000000000;

        [NativeTypeName("const WGPUShaderStage")]
        public const ulong WGPUShaderStage_Vertex = 0x0000000000000001;

        [NativeTypeName("const WGPUShaderStage")]
        public const ulong WGPUShaderStage_Fragment = 0x0000000000000002;

        [NativeTypeName("const WGPUShaderStage")]
        public const ulong WGPUShaderStage_Compute = 0x0000000000000004;

        [NativeTypeName("const WGPUTextureUsage")]
        public const ulong WGPUTextureUsage_None = 0x0000000000000000;

        [NativeTypeName("const WGPUTextureUsage")]
        public const ulong WGPUTextureUsage_CopySrc = 0x0000000000000001;

        [NativeTypeName("const WGPUTextureUsage")]
        public const ulong WGPUTextureUsage_CopyDst = 0x0000000000000002;

        [NativeTypeName("const WGPUTextureUsage")]
        public const ulong WGPUTextureUsage_TextureBinding = 0x0000000000000004;

        [NativeTypeName("const WGPUTextureUsage")]
        public const ulong WGPUTextureUsage_StorageBinding = 0x0000000000000008;

        [NativeTypeName("const WGPUTextureUsage")]
        public const ulong WGPUTextureUsage_RenderAttachment = 0x0000000000000010;

        [NativeTypeName("const WGPUTextureUsage")]
        public const ulong WGPUTextureUsage_TransientAttachment = 0x0000000000000020;

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUInstance")]
        public static extern WGPUInstanceImpl* wgpuCreateInstance([NativeTypeName("const WGPUInstanceDescriptor *")] WGPUInstanceDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuGetInstanceFeatures(WGPUSupportedInstanceFeatures* features);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuGetInstanceLimits(WGPUInstanceLimits* limits);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBool")]
        public static extern uint wgpuHasInstanceFeature(WGPUInstanceFeatureName feature);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUProc")]
        public static extern delegate* unmanaged[Cdecl]<void> wgpuGetProcAddress(WGPUStringView procName);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuAdapterGetFeatures([NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter, WGPUSupportedFeatures* features);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuAdapterGetInfo([NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter, WGPUAdapterInfo* info);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuAdapterGetLimits([NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter, WGPULimits* limits);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBool")]
        public static extern uint wgpuAdapterHasFeature([NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter, WGPUFeatureName feature);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuAdapterRequestDevice([NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter, [NativeTypeName("const WGPUDeviceDescriptor *")] WGPUDeviceDescriptor* descriptor, WGPURequestDeviceCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuAdapterAddRef([NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuAdapterRelease([NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuAdapterInfoFreeMembers(WGPUAdapterInfo adapterInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBindGroupSetLabel([NativeTypeName("WGPUBindGroup")] WGPUBindGroupImpl* bindGroup, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBindGroupAddRef([NativeTypeName("WGPUBindGroup")] WGPUBindGroupImpl* bindGroup);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBindGroupRelease([NativeTypeName("WGPUBindGroup")] WGPUBindGroupImpl* bindGroup);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBindGroupLayoutSetLabel([NativeTypeName("WGPUBindGroupLayout")] WGPUBindGroupLayoutImpl* bindGroupLayout, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBindGroupLayoutAddRef([NativeTypeName("WGPUBindGroupLayout")] WGPUBindGroupLayoutImpl* bindGroupLayout);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBindGroupLayoutRelease([NativeTypeName("WGPUBindGroupLayout")] WGPUBindGroupLayoutImpl* bindGroupLayout);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBufferDestroy([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* wgpuBufferGetConstMappedRange([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("size_t")] nuint offset, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* wgpuBufferGetMappedRange([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("size_t")] nuint offset, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUBufferMapState wgpuBufferGetMapState([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong wgpuBufferGetSize([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBufferUsage")]
        public static extern ulong wgpuBufferGetUsage([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuBufferMapAsync([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("WGPUMapMode")] ulong mode, [NativeTypeName("size_t")] nuint offset, [NativeTypeName("size_t")] nuint size, WGPUBufferMapCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuBufferReadMappedRange([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("size_t")] nuint offset, void* data, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBufferSetLabel([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBufferUnmap([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuBufferWriteMappedRange([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("size_t")] nuint offset, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBufferAddRef([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuBufferRelease([NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandBufferSetLabel([NativeTypeName("WGPUCommandBuffer")] WGPUCommandBufferImpl* commandBuffer, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandBufferAddRef([NativeTypeName("WGPUCommandBuffer")] WGPUCommandBufferImpl* commandBuffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandBufferRelease([NativeTypeName("WGPUCommandBuffer")] WGPUCommandBufferImpl* commandBuffer);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUComputePassEncoder")]
        public static extern WGPUComputePassEncoderImpl* wgpuCommandEncoderBeginComputePass([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("const WGPUComputePassDescriptor *")] WGPUComputePassDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPURenderPassEncoder")]
        public static extern WGPURenderPassEncoderImpl* wgpuCommandEncoderBeginRenderPass([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("const WGPURenderPassDescriptor *")] WGPURenderPassDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderClearBuffer([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("uint64_t")] ulong offset, [NativeTypeName("uint64_t")] ulong size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderCopyBufferToBuffer([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* source, [NativeTypeName("uint64_t")] ulong sourceOffset, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* destination, [NativeTypeName("uint64_t")] ulong destinationOffset, [NativeTypeName("uint64_t")] ulong size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderCopyBufferToTexture([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("const WGPUTexelCopyBufferInfo *")] WGPUTexelCopyBufferInfo* source, [NativeTypeName("const WGPUTexelCopyTextureInfo *")] WGPUTexelCopyTextureInfo* destination, [NativeTypeName("const WGPUExtent3D *")] WGPUExtent3D* copySize);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderCopyTextureToBuffer([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("const WGPUTexelCopyTextureInfo *")] WGPUTexelCopyTextureInfo* source, [NativeTypeName("const WGPUTexelCopyBufferInfo *")] WGPUTexelCopyBufferInfo* destination, [NativeTypeName("const WGPUExtent3D *")] WGPUExtent3D* copySize);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderCopyTextureToTexture([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("const WGPUTexelCopyTextureInfo *")] WGPUTexelCopyTextureInfo* source, [NativeTypeName("const WGPUTexelCopyTextureInfo *")] WGPUTexelCopyTextureInfo* destination, [NativeTypeName("const WGPUExtent3D *")] WGPUExtent3D* copySize);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUCommandBuffer")]
        public static extern WGPUCommandBufferImpl* wgpuCommandEncoderFinish([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("const WGPUCommandBufferDescriptor *")] WGPUCommandBufferDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderInsertDebugMarker([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, WGPUStringView markerLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderPopDebugGroup([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderPushDebugGroup([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, WGPUStringView groupLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderResolveQuerySet([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet, [NativeTypeName("uint32_t")] uint firstQuery, [NativeTypeName("uint32_t")] uint queryCount, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* destination, [NativeTypeName("uint64_t")] ulong destinationOffset);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderSetLabel([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderWriteTimestamp([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder, [NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet, [NativeTypeName("uint32_t")] uint queryIndex);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderAddRef([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuCommandEncoderRelease([NativeTypeName("WGPUCommandEncoder")] WGPUCommandEncoderImpl* commandEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderDispatchWorkgroups([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, [NativeTypeName("uint32_t")] uint workgroupCountX, [NativeTypeName("uint32_t")] uint workgroupCountY, [NativeTypeName("uint32_t")] uint workgroupCountZ);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderDispatchWorkgroupsIndirect([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* indirectBuffer, [NativeTypeName("uint64_t")] ulong indirectOffset);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderEnd([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderInsertDebugMarker([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, WGPUStringView markerLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderPopDebugGroup([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderPushDebugGroup([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, WGPUStringView groupLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderSetBindGroup([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, [NativeTypeName("uint32_t")] uint groupIndex, [NativeTypeName("WGPUBindGroup")] WGPUBindGroupImpl* group, [NativeTypeName("size_t")] nuint dynamicOffsetCount, [NativeTypeName("const uint32_t *")] uint* dynamicOffsets);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderSetImmediates([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, [NativeTypeName("uint32_t")] uint offset, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderSetLabel([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderSetPipeline([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder, [NativeTypeName("WGPUComputePipeline")] WGPUComputePipelineImpl* pipeline);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderAddRef([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePassEncoderRelease([NativeTypeName("WGPUComputePassEncoder")] WGPUComputePassEncoderImpl* computePassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBindGroupLayout")]
        public static extern WGPUBindGroupLayoutImpl* wgpuComputePipelineGetBindGroupLayout([NativeTypeName("WGPUComputePipeline")] WGPUComputePipelineImpl* computePipeline, [NativeTypeName("uint32_t")] uint groupIndex);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePipelineSetLabel([NativeTypeName("WGPUComputePipeline")] WGPUComputePipelineImpl* computePipeline, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePipelineAddRef([NativeTypeName("WGPUComputePipeline")] WGPUComputePipelineImpl* computePipeline);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuComputePipelineRelease([NativeTypeName("WGPUComputePipeline")] WGPUComputePipelineImpl* computePipeline);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBindGroup")]
        public static extern WGPUBindGroupImpl* wgpuDeviceCreateBindGroup([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUBindGroupDescriptor *")] WGPUBindGroupDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBindGroupLayout")]
        public static extern WGPUBindGroupLayoutImpl* wgpuDeviceCreateBindGroupLayout([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUBindGroupLayoutDescriptor *")] WGPUBindGroupLayoutDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBuffer")]
        public static extern WGPUBufferImpl* wgpuDeviceCreateBuffer([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUBufferDescriptor *")] WGPUBufferDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUCommandEncoder")]
        public static extern WGPUCommandEncoderImpl* wgpuDeviceCreateCommandEncoder([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUCommandEncoderDescriptor *")] WGPUCommandEncoderDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUComputePipeline")]
        public static extern WGPUComputePipelineImpl* wgpuDeviceCreateComputePipeline([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUComputePipelineDescriptor *")] WGPUComputePipelineDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuDeviceCreateComputePipelineAsync([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUComputePipelineDescriptor *")] WGPUComputePipelineDescriptor* descriptor, WGPUCreateComputePipelineAsyncCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUPipelineLayout")]
        public static extern WGPUPipelineLayoutImpl* wgpuDeviceCreatePipelineLayout([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUPipelineLayoutDescriptor *")] WGPUPipelineLayoutDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUQuerySet")]
        public static extern WGPUQuerySetImpl* wgpuDeviceCreateQuerySet([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUQuerySetDescriptor *")] WGPUQuerySetDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPURenderBundleEncoder")]
        public static extern WGPURenderBundleEncoderImpl* wgpuDeviceCreateRenderBundleEncoder([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPURenderBundleEncoderDescriptor *")] WGPURenderBundleEncoderDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPURenderPipeline")]
        public static extern WGPURenderPipelineImpl* wgpuDeviceCreateRenderPipeline([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPURenderPipelineDescriptor *")] WGPURenderPipelineDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuDeviceCreateRenderPipelineAsync([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPURenderPipelineDescriptor *")] WGPURenderPipelineDescriptor* descriptor, WGPUCreateRenderPipelineAsyncCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUSampler")]
        public static extern WGPUSamplerImpl* wgpuDeviceCreateSampler([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUSamplerDescriptor *")] WGPUSamplerDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUShaderModule")]
        public static extern WGPUShaderModuleImpl* wgpuDeviceCreateShaderModule([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUShaderModuleDescriptor *")] WGPUShaderModuleDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUTexture")]
        public static extern WGPUTextureImpl* wgpuDeviceCreateTexture([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, [NativeTypeName("const WGPUTextureDescriptor *")] WGPUTextureDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuDeviceDestroy([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuDeviceGetAdapterInfo([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, WGPUAdapterInfo* adapterInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuDeviceGetFeatures([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, WGPUSupportedFeatures* features);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuDeviceGetLimits([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, WGPULimits* limits);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuDeviceGetLostFuture([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUQueue")]
        public static extern WGPUQueueImpl* wgpuDeviceGetQueue([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBool")]
        public static extern uint wgpuDeviceHasFeature([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, WGPUFeatureName feature);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuDevicePopErrorScope([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, WGPUPopErrorScopeCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuDevicePushErrorScope([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, WGPUErrorFilter filter);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuDeviceSetLabel([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuDeviceAddRef([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuDeviceRelease([NativeTypeName("WGPUDevice")] WGPUDeviceImpl* device);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuExternalTextureSetLabel([NativeTypeName("WGPUExternalTexture")] WGPUExternalTextureImpl* externalTexture, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuExternalTextureAddRef([NativeTypeName("WGPUExternalTexture")] WGPUExternalTextureImpl* externalTexture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuExternalTextureRelease([NativeTypeName("WGPUExternalTexture")] WGPUExternalTextureImpl* externalTexture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUSurface")]
        public static extern WGPUSurfaceImpl* wgpuInstanceCreateSurface([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance, [NativeTypeName("const WGPUSurfaceDescriptor *")] WGPUSurfaceDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuInstanceGetWGSLLanguageFeatures([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance, WGPUSupportedWGSLLanguageFeatures* features);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBool")]
        public static extern uint wgpuInstanceHasWGSLLanguageFeature([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance, WGPUWGSLLanguageFeatureName feature);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuInstanceProcessEvents([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuInstanceRequestAdapter([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance, [NativeTypeName("const WGPURequestAdapterOptions *")] WGPURequestAdapterOptions* options, WGPURequestAdapterCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUWaitStatus wgpuInstanceWaitAny([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance, [NativeTypeName("size_t")] nuint futureCount, WGPUFutureWaitInfo* futures, [NativeTypeName("uint64_t")] ulong timeoutNS);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuInstanceAddRef([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuInstanceRelease([NativeTypeName("WGPUInstance")] WGPUInstanceImpl* instance);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuPipelineLayoutSetLabel([NativeTypeName("WGPUPipelineLayout")] WGPUPipelineLayoutImpl* pipelineLayout, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuPipelineLayoutAddRef([NativeTypeName("WGPUPipelineLayout")] WGPUPipelineLayoutImpl* pipelineLayout);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuPipelineLayoutRelease([NativeTypeName("WGPUPipelineLayout")] WGPUPipelineLayoutImpl* pipelineLayout);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQuerySetDestroy([NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint wgpuQuerySetGetCount([NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUQueryType wgpuQuerySetGetType([NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQuerySetSetLabel([NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQuerySetAddRef([NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQuerySetRelease([NativeTypeName("WGPUQuerySet")] WGPUQuerySetImpl* querySet);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuQueueOnSubmittedWorkDone([NativeTypeName("WGPUQueue")] WGPUQueueImpl* queue, WGPUQueueWorkDoneCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQueueSetLabel([NativeTypeName("WGPUQueue")] WGPUQueueImpl* queue, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQueueSubmit([NativeTypeName("WGPUQueue")] WGPUQueueImpl* queue, [NativeTypeName("size_t")] nuint commandCount, [NativeTypeName("const WGPUCommandBuffer *")] WGPUCommandBufferImpl** commands);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQueueWriteBuffer([NativeTypeName("WGPUQueue")] WGPUQueueImpl* queue, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("uint64_t")] ulong bufferOffset, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQueueWriteTexture([NativeTypeName("WGPUQueue")] WGPUQueueImpl* queue, [NativeTypeName("const WGPUTexelCopyTextureInfo *")] WGPUTexelCopyTextureInfo* destination, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint dataSize, [NativeTypeName("const WGPUTexelCopyBufferLayout *")] WGPUTexelCopyBufferLayout* dataLayout, [NativeTypeName("const WGPUExtent3D *")] WGPUExtent3D* writeSize);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQueueAddRef([NativeTypeName("WGPUQueue")] WGPUQueueImpl* queue);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuQueueRelease([NativeTypeName("WGPUQueue")] WGPUQueueImpl* queue);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleSetLabel([NativeTypeName("WGPURenderBundle")] WGPURenderBundleImpl* renderBundle, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleAddRef([NativeTypeName("WGPURenderBundle")] WGPURenderBundleImpl* renderBundle);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleRelease([NativeTypeName("WGPURenderBundle")] WGPURenderBundleImpl* renderBundle);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderDraw([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("uint32_t")] uint vertexCount, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstVertex, [NativeTypeName("uint32_t")] uint firstInstance);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderDrawIndexed([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("uint32_t")] uint indexCount, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstIndex, [NativeTypeName("int32_t")] int baseVertex, [NativeTypeName("uint32_t")] uint firstInstance);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderDrawIndexedIndirect([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* indirectBuffer, [NativeTypeName("uint64_t")] ulong indirectOffset);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderDrawIndirect([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* indirectBuffer, [NativeTypeName("uint64_t")] ulong indirectOffset);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPURenderBundle")]
        public static extern WGPURenderBundleImpl* wgpuRenderBundleEncoderFinish([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("const WGPURenderBundleDescriptor *")] WGPURenderBundleDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderInsertDebugMarker([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, WGPUStringView markerLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderPopDebugGroup([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderPushDebugGroup([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, WGPUStringView groupLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderSetBindGroup([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("uint32_t")] uint groupIndex, [NativeTypeName("WGPUBindGroup")] WGPUBindGroupImpl* group, [NativeTypeName("size_t")] nuint dynamicOffsetCount, [NativeTypeName("const uint32_t *")] uint* dynamicOffsets);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderSetImmediates([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("uint32_t")] uint offset, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderSetIndexBuffer([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, WGPUIndexFormat format, [NativeTypeName("uint64_t")] ulong offset, [NativeTypeName("uint64_t")] ulong size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderSetLabel([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderSetPipeline([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("WGPURenderPipeline")] WGPURenderPipelineImpl* pipeline);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderSetVertexBuffer([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder, [NativeTypeName("uint32_t")] uint slot, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("uint64_t")] ulong offset, [NativeTypeName("uint64_t")] ulong size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderAddRef([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderBundleEncoderRelease([NativeTypeName("WGPURenderBundleEncoder")] WGPURenderBundleEncoderImpl* renderBundleEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderBeginOcclusionQuery([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint queryIndex);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderDraw([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint vertexCount, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstVertex, [NativeTypeName("uint32_t")] uint firstInstance);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderDrawIndexed([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint indexCount, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstIndex, [NativeTypeName("int32_t")] int baseVertex, [NativeTypeName("uint32_t")] uint firstInstance);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderDrawIndexedIndirect([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* indirectBuffer, [NativeTypeName("uint64_t")] ulong indirectOffset);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderDrawIndirect([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* indirectBuffer, [NativeTypeName("uint64_t")] ulong indirectOffset);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderEnd([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderEndOcclusionQuery([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderExecuteBundles([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("size_t")] nuint bundleCount, [NativeTypeName("const WGPURenderBundle *")] WGPURenderBundleImpl** bundles);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderInsertDebugMarker([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, WGPUStringView markerLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderPopDebugGroup([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderPushDebugGroup([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, WGPUStringView groupLabel);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetBindGroup([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint groupIndex, [NativeTypeName("WGPUBindGroup")] WGPUBindGroupImpl* group, [NativeTypeName("size_t")] nuint dynamicOffsetCount, [NativeTypeName("const uint32_t *")] uint* dynamicOffsets);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetBlendConstant([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("const WGPUColor *")] WGPUColor* color);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetImmediates([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint offset, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetIndexBuffer([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, WGPUIndexFormat format, [NativeTypeName("uint64_t")] ulong offset, [NativeTypeName("uint64_t")] ulong size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetLabel([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetPipeline([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("WGPURenderPipeline")] WGPURenderPipelineImpl* pipeline);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetScissorRect([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint x, [NativeTypeName("uint32_t")] uint y, [NativeTypeName("uint32_t")] uint width, [NativeTypeName("uint32_t")] uint height);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetStencilReference([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint reference);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetVertexBuffer([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, [NativeTypeName("uint32_t")] uint slot, [NativeTypeName("WGPUBuffer")] WGPUBufferImpl* buffer, [NativeTypeName("uint64_t")] ulong offset, [NativeTypeName("uint64_t")] ulong size);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderSetViewport([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderAddRef([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPassEncoderRelease([NativeTypeName("WGPURenderPassEncoder")] WGPURenderPassEncoderImpl* renderPassEncoder);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUBindGroupLayout")]
        public static extern WGPUBindGroupLayoutImpl* wgpuRenderPipelineGetBindGroupLayout([NativeTypeName("WGPURenderPipeline")] WGPURenderPipelineImpl* renderPipeline, [NativeTypeName("uint32_t")] uint groupIndex);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPipelineSetLabel([NativeTypeName("WGPURenderPipeline")] WGPURenderPipelineImpl* renderPipeline, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPipelineAddRef([NativeTypeName("WGPURenderPipeline")] WGPURenderPipelineImpl* renderPipeline);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuRenderPipelineRelease([NativeTypeName("WGPURenderPipeline")] WGPURenderPipelineImpl* renderPipeline);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSamplerSetLabel([NativeTypeName("WGPUSampler")] WGPUSamplerImpl* sampler, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSamplerAddRef([NativeTypeName("WGPUSampler")] WGPUSamplerImpl* sampler);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSamplerRelease([NativeTypeName("WGPUSampler")] WGPUSamplerImpl* sampler);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUFuture wgpuShaderModuleGetCompilationInfo([NativeTypeName("WGPUShaderModule")] WGPUShaderModuleImpl* shaderModule, WGPUCompilationInfoCallbackInfo callbackInfo);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuShaderModuleSetLabel([NativeTypeName("WGPUShaderModule")] WGPUShaderModuleImpl* shaderModule, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuShaderModuleAddRef([NativeTypeName("WGPUShaderModule")] WGPUShaderModuleImpl* shaderModule);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuShaderModuleRelease([NativeTypeName("WGPUShaderModule")] WGPUShaderModuleImpl* shaderModule);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSupportedFeaturesFreeMembers(WGPUSupportedFeatures supportedFeatures);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSupportedInstanceFeaturesFreeMembers(WGPUSupportedInstanceFeatures supportedInstanceFeatures);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSupportedWGSLLanguageFeaturesFreeMembers(WGPUSupportedWGSLLanguageFeatures supportedWGSLLanguageFeatures);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSurfaceConfigure([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface, [NativeTypeName("const WGPUSurfaceConfiguration *")] WGPUSurfaceConfiguration* config);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuSurfaceGetCapabilities([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface, [NativeTypeName("WGPUAdapter")] WGPUAdapterImpl* adapter, WGPUSurfaceCapabilities* capabilities);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSurfaceGetCurrentTexture([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface, WGPUSurfaceTexture* surfaceTexture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUStatus wgpuSurfacePresent([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSurfaceSetLabel([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSurfaceUnconfigure([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSurfaceAddRef([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSurfaceRelease([NativeTypeName("WGPUSurface")] WGPUSurfaceImpl* surface);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuSurfaceCapabilitiesFreeMembers(WGPUSurfaceCapabilities surfaceCapabilities);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUTextureView")]
        public static extern WGPUTextureViewImpl* wgpuTextureCreateView([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture, [NativeTypeName("const WGPUTextureViewDescriptor *")] WGPUTextureViewDescriptor* descriptor);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuTextureDestroy([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint wgpuTextureGetDepthOrArrayLayers([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUTextureDimension wgpuTextureGetDimension([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUTextureFormat wgpuTextureGetFormat([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint wgpuTextureGetHeight([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint wgpuTextureGetMipLevelCount([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint wgpuTextureGetSampleCount([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern WGPUTextureViewDimension wgpuTextureGetTextureBindingViewDimension([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("WGPUTextureUsage")]
        public static extern ulong wgpuTextureGetUsage([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint wgpuTextureGetWidth([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuTextureSetLabel([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuTextureAddRef([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuTextureRelease([NativeTypeName("WGPUTexture")] WGPUTextureImpl* texture);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuTextureViewSetLabel([NativeTypeName("WGPUTextureView")] WGPUTextureViewImpl* textureView, WGPUStringView label);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuTextureViewAddRef([NativeTypeName("WGPUTextureView")] WGPUTextureViewImpl* textureView);

        [DllImport("wgpu", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void wgpuTextureViewRelease([NativeTypeName("WGPUTextureView")] WGPUTextureViewImpl* textureView);

        [NativeTypeName("#define WGPU_TRUE (UINT32_C(1))")]
        public const uint WGPU_TRUE = ((1U));

        [NativeTypeName("#define WGPU_FALSE (UINT32_C(0))")]
        public const uint WGPU_FALSE = ((0U));

        [NativeTypeName("#define WGPU_ARRAY_LAYER_COUNT_UNDEFINED (UINT32_MAX)")]
        public const uint WGPU_ARRAY_LAYER_COUNT_UNDEFINED = (0xffffffffU);

        [NativeTypeName("#define WGPU_COPY_STRIDE_UNDEFINED (UINT32_MAX)")]
        public const uint WGPU_COPY_STRIDE_UNDEFINED = (0xffffffffU);

        [NativeTypeName("#define WGPU_DEPTH_CLEAR_VALUE_UNDEFINED (NAN)")]
        public static readonly float WGPU_DEPTH_CLEAR_VALUE_UNDEFINED = float.NaN;

        [NativeTypeName("#define WGPU_DEPTH_SLICE_UNDEFINED (UINT32_MAX)")]
        public const uint WGPU_DEPTH_SLICE_UNDEFINED = (0xffffffffU);

        [NativeTypeName("#define WGPU_LIMIT_U32_UNDEFINED (UINT32_MAX)")]
        public const uint WGPU_LIMIT_U32_UNDEFINED = (0xffffffffU);

        [NativeTypeName("#define WGPU_LIMIT_U64_UNDEFINED (UINT64_MAX)")]
        public const ulong WGPU_LIMIT_U64_UNDEFINED = (0xffffffffffffffffUL);

        [NativeTypeName("#define WGPU_MIP_LEVEL_COUNT_UNDEFINED (UINT32_MAX)")]
        public const uint WGPU_MIP_LEVEL_COUNT_UNDEFINED = (0xffffffffU);

        [NativeTypeName("#define WGPU_QUERY_SET_INDEX_UNDEFINED (UINT32_MAX)")]
        public const uint WGPU_QUERY_SET_INDEX_UNDEFINED = (0xffffffffU);

        [NativeTypeName("#define WGPU_STRLEN (SIZE_MAX)")]
        public const ulong WGPU_STRLEN = (0xffffffffffffffffUL);

        [NativeTypeName("#define WGPU_WHOLE_MAP_SIZE (SIZE_MAX)")]
        public const ulong WGPU_WHOLE_MAP_SIZE = (0xffffffffffffffffUL);

        [NativeTypeName("#define WGPU_WHOLE_SIZE (UINT64_MAX)")]
        public const ulong WGPU_WHOLE_SIZE = (0xffffffffffffffffUL);

        [NativeTypeName("#define WGPU_STRING_VIEW_INIT _wgpu_MAKE_INIT_STRUCT(WGPUStringView, { \\\r\n    /*.data=*/NULL _wgpu_COMMA \\\r\n    /*.length=*/WGPU_STRLEN _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUStringView WGPU_STRING_VIEW_INIT = (new WGPUStringView
        {
            data = null,
            length = (UIntPtr)(0xffffffffffffffffUL),
        });

        [NativeTypeName("#define WGPU_BUFFER_MAP_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBufferMapCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBufferMapCallbackInfo WGPU_BUFFER_MAP_CALLBACK_INFO_INIT = (new WGPUBufferMapCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_COMPILATION_INFO_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCompilationInfoCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCompilationInfoCallbackInfo WGPU_COMPILATION_INFO_CALLBACK_INFO_INIT = (new WGPUCompilationInfoCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_CREATE_COMPUTE_PIPELINE_ASYNC_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCreateComputePipelineAsyncCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCreateComputePipelineAsyncCallbackInfo WGPU_CREATE_COMPUTE_PIPELINE_ASYNC_CALLBACK_INFO_INIT = (new WGPUCreateComputePipelineAsyncCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_CREATE_RENDER_PIPELINE_ASYNC_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCreateRenderPipelineAsyncCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCreateRenderPipelineAsyncCallbackInfo WGPU_CREATE_RENDER_PIPELINE_ASYNC_CALLBACK_INFO_INIT = (new WGPUCreateRenderPipelineAsyncCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_DEVICE_LOST_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUDeviceLostCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUDeviceLostCallbackInfo WGPU_DEVICE_LOST_CALLBACK_INFO_INIT = (new WGPUDeviceLostCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_POP_ERROR_SCOPE_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUPopErrorScopeCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUPopErrorScopeCallbackInfo WGPU_POP_ERROR_SCOPE_CALLBACK_INFO_INIT = (new WGPUPopErrorScopeCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_QUEUE_WORK_DONE_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUQueueWorkDoneCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUQueueWorkDoneCallbackInfo WGPU_QUEUE_WORK_DONE_CALLBACK_INFO_INIT = (new WGPUQueueWorkDoneCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_REQUEST_ADAPTER_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPURequestAdapterCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURequestAdapterCallbackInfo WGPU_REQUEST_ADAPTER_CALLBACK_INFO_INIT = (new WGPURequestAdapterCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_REQUEST_DEVICE_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPURequestDeviceCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.mode=*/_wgpu_ENUM_ZERO_INIT(WGPUCallbackMode) _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURequestDeviceCallbackInfo WGPU_REQUEST_DEVICE_CALLBACK_INFO_INIT = (new WGPURequestDeviceCallbackInfo
        {
            nextInChain = null,
            mode = (WGPUCallbackMode)(0),
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_UNCAPTURED_ERROR_CALLBACK_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUUncapturedErrorCallbackInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.callback=*/NULL _wgpu_COMMA \\\r\n    /*.userdata1=*/NULL _wgpu_COMMA \\\r\n    /*.userdata2=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUUncapturedErrorCallbackInfo WGPU_UNCAPTURED_ERROR_CALLBACK_INFO_INIT = (new WGPUUncapturedErrorCallbackInfo
        {
            nextInChain = null,
            callback = null,
            userdata1 = unchecked((void*)(0)),
            userdata2 = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_ADAPTER_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUAdapterInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.vendor=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.architecture=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.device=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.description=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.backendType=*/WGPUBackendType_Undefined _wgpu_COMMA \\\r\n    /*.adapterType=*/_wgpu_ENUM_ZERO_INIT(WGPUAdapterType) _wgpu_COMMA \\\r\n    /*.vendorID=*/0 _wgpu_COMMA \\\r\n    /*.deviceID=*/0 _wgpu_COMMA \\\r\n    /*.subgroupMinSize=*/0 _wgpu_COMMA \\\r\n    /*.subgroupMaxSize=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUAdapterInfo WGPU_ADAPTER_INFO_INIT = (new WGPUAdapterInfo
        {
            nextInChain = null,
            vendor = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(UIntPtr)(0xffffffffffffffffUL),
            }),
            architecture = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(UIntPtr)(0xffffffffffffffffUL),
            }),
            device = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(UIntPtr)(0xffffffffffffffffUL),
            }),
            description = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(UIntPtr)(0xffffffffffffffffUL),
            }),
            backendType = (WGPUBackendType)(WGPUBackendType_Undefined),
            adapterType = (WGPUAdapterType)(0),
            vendorID = 0,
            deviceID = 0,
            subgroupMinSize = 0,
            subgroupMaxSize = 0,
        });

        [NativeTypeName("#define WGPU_BLEND_COMPONENT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBlendComponent, { \\\r\n    /*.operation=*/WGPUBlendOperation_Undefined _wgpu_COMMA \\\r\n    /*.srcFactor=*/WGPUBlendFactor_Undefined _wgpu_COMMA \\\r\n    /*.dstFactor=*/WGPUBlendFactor_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBlendComponent WGPU_BLEND_COMPONENT_INIT = (new WGPUBlendComponent
        {
            operation = (WGPUBlendOperation)(WGPUBlendOperation_Undefined),
            srcFactor = (WGPUBlendFactor)(WGPUBlendFactor_Undefined),
            dstFactor = (WGPUBlendFactor)(WGPUBlendFactor_Undefined),
        });

        [NativeTypeName("#define WGPU_BUFFER_BINDING_LAYOUT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBufferBindingLayout, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.type=*/WGPUBufferBindingType_Undefined _wgpu_COMMA \\\r\n    /*.hasDynamicOffset=*/WGPU_FALSE _wgpu_COMMA \\\r\n    /*.minBindingSize=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBufferBindingLayout WGPU_BUFFER_BINDING_LAYOUT_INIT = (new WGPUBufferBindingLayout
        {
            nextInChain = null,
            type = (WGPUBufferBindingType)(WGPUBufferBindingType_Undefined),
            hasDynamicOffset = ((0U)),
            minBindingSize = 0,
        });

        [NativeTypeName("#define WGPU_BUFFER_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBufferDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.usage=*/WGPUBufferUsage_None _wgpu_COMMA \\\r\n    /*.size=*/0 _wgpu_COMMA \\\r\n    /*.mappedAtCreation=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBufferDescriptor WGPU_BUFFER_DESCRIPTOR_INIT = (new WGPUBufferDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            usage = WGPUBufferUsage_None,
            size = 0,
            mappedAtCreation = ((0U)),
        });

        [NativeTypeName("#define WGPU_COLOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUColor, { \\\r\n    /*.r=*/0. _wgpu_COMMA \\\r\n    /*.g=*/0. _wgpu_COMMA \\\r\n    /*.b=*/0. _wgpu_COMMA \\\r\n    /*.a=*/0. _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUColor WGPU_COLOR_INIT = (new WGPUColor
        {
            r = 0.0,
            g = 0.0,
            b = 0.0,
            a = 0.0,
        });

        [NativeTypeName("#define WGPU_COMMAND_BUFFER_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCommandBufferDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCommandBufferDescriptor WGPU_COMMAND_BUFFER_DESCRIPTOR_INIT = (new WGPUCommandBufferDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
        });

        [NativeTypeName("#define WGPU_COMMAND_ENCODER_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCommandEncoderDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCommandEncoderDescriptor WGPU_COMMAND_ENCODER_DESCRIPTOR_INIT = (new WGPUCommandEncoderDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
        });

        [NativeTypeName("#define WGPU_COMPATIBILITY_MODE_LIMITS_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCompatibilityModeLimits, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_CompatibilityModeLimits _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.maxStorageBuffersInVertexStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxStorageTexturesInVertexStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxStorageBuffersInFragmentStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxStorageTexturesInFragmentStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCompatibilityModeLimits WGPU_COMPATIBILITY_MODE_LIMITS_INIT = (new WGPUCompatibilityModeLimits
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_CompatibilityModeLimits),
            }),
            maxStorageBuffersInVertexStage = (0xffffffffU),
            maxStorageTexturesInVertexStage = (0xffffffffU),
            maxStorageBuffersInFragmentStage = (0xffffffffU),
            maxStorageTexturesInFragmentStage = (0xffffffffU),
        });

        [NativeTypeName("#define WGPU_COMPILATION_MESSAGE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCompilationMessage, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.message=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.type=*/_wgpu_ENUM_ZERO_INIT(WGPUCompilationMessageType) _wgpu_COMMA \\\r\n    /*.lineNum=*/0 _wgpu_COMMA \\\r\n    /*.linePos=*/0 _wgpu_COMMA \\\r\n    /*.offset=*/0 _wgpu_COMMA \\\r\n    /*.length=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCompilationMessage WGPU_COMPILATION_MESSAGE_INIT = (new WGPUCompilationMessage
        {
            nextInChain = null,
            message = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            type = (WGPUCompilationMessageType)(0),
            lineNum = 0,
            linePos = 0,
            offset = 0,
            length = 0,
        });

        [NativeTypeName("#define WGPU_CONSTANT_ENTRY_INIT _wgpu_MAKE_INIT_STRUCT(WGPUConstantEntry, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.key=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.value=*/0. _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUConstantEntry WGPU_CONSTANT_ENTRY_INIT = (new WGPUConstantEntry
        {
            nextInChain = null,
            key = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            value = 0.0,
        });

        [NativeTypeName("#define WGPU_EXTENT_3D_INIT _wgpu_MAKE_INIT_STRUCT(WGPUExtent3D, { \\\r\n    /*.width=*/0 _wgpu_COMMA \\\r\n    /*.height=*/1 _wgpu_COMMA \\\r\n    /*.depthOrArrayLayers=*/1 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUExtent3D WGPU_EXTENT_3D_INIT = (new WGPUExtent3D
        {
            width = 0,
            height = 1,
            depthOrArrayLayers = 1,
        });

        [NativeTypeName("#define WGPU_EXTERNAL_TEXTURE_BINDING_ENTRY_INIT _wgpu_MAKE_INIT_STRUCT(WGPUExternalTextureBindingEntry, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_ExternalTextureBindingEntry _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.externalTexture=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUExternalTextureBindingEntry WGPU_EXTERNAL_TEXTURE_BINDING_ENTRY_INIT = (new WGPUExternalTextureBindingEntry
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_ExternalTextureBindingEntry),
            }),
            externalTexture = null,
        });

        [NativeTypeName("#define WGPU_EXTERNAL_TEXTURE_BINDING_LAYOUT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUExternalTextureBindingLayout, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_ExternalTextureBindingLayout _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUExternalTextureBindingLayout WGPU_EXTERNAL_TEXTURE_BINDING_LAYOUT_INIT = (new WGPUExternalTextureBindingLayout
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_ExternalTextureBindingLayout),
            }),
        });

        [NativeTypeName("#define WGPU_FUTURE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUFuture, { \\\r\n    /*.id=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUFuture WGPU_FUTURE_INIT = (new WGPUFuture
        {
            id = 0,
        });

        [NativeTypeName("#define WGPU_INSTANCE_LIMITS_INIT _wgpu_MAKE_INIT_STRUCT(WGPUInstanceLimits, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.timedWaitAnyMaxCount=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUInstanceLimits WGPU_INSTANCE_LIMITS_INIT = (new WGPUInstanceLimits
        {
            nextInChain = null,
            timedWaitAnyMaxCount = 0,
        });

        [NativeTypeName("#define WGPU_MULTISAMPLE_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUMultisampleState, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.count=*/1 _wgpu_COMMA \\\r\n    /*.mask=*/0xFFFFFFFF _wgpu_COMMA \\\r\n    /*.alphaToCoverageEnabled=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUMultisampleState WGPU_MULTISAMPLE_STATE_INIT = (new WGPUMultisampleState
        {
            nextInChain = null,
            count = 1,
            mask = 0xFFFFFFFF,
            alphaToCoverageEnabled = ((0U)),
        });

        [NativeTypeName("#define WGPU_ORIGIN_3D_INIT _wgpu_MAKE_INIT_STRUCT(WGPUOrigin3D, { \\\r\n    /*.x=*/0 _wgpu_COMMA \\\r\n    /*.y=*/0 _wgpu_COMMA \\\r\n    /*.z=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUOrigin3D WGPU_ORIGIN_3D_INIT = (new WGPUOrigin3D
        {
            x = 0,
            y = 0,
            z = 0,
        });

        [NativeTypeName("#define WGPU_PASS_TIMESTAMP_WRITES_INIT _wgpu_MAKE_INIT_STRUCT(WGPUPassTimestampWrites, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.querySet=*/NULL _wgpu_COMMA \\\r\n    /*.beginningOfPassWriteIndex=*/WGPU_QUERY_SET_INDEX_UNDEFINED _wgpu_COMMA \\\r\n    /*.endOfPassWriteIndex=*/WGPU_QUERY_SET_INDEX_UNDEFINED _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUPassTimestampWrites WGPU_PASS_TIMESTAMP_WRITES_INIT = (new WGPUPassTimestampWrites
        {
            nextInChain = null,
            querySet = null,
            beginningOfPassWriteIndex = (0xffffffffU),
            endOfPassWriteIndex = (0xffffffffU),
        });

        [NativeTypeName("#define WGPU_PIPELINE_LAYOUT_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUPipelineLayoutDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.bindGroupLayoutCount=*/0 _wgpu_COMMA \\\r\n    /*.bindGroupLayouts=*/NULL _wgpu_COMMA \\\r\n    /*.immediateSize=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUPipelineLayoutDescriptor WGPU_PIPELINE_LAYOUT_DESCRIPTOR_INIT = (new WGPUPipelineLayoutDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            bindGroupLayoutCount = 0,
            bindGroupLayouts = null,
            immediateSize = 0,
        });

        [NativeTypeName("#define WGPU_PRIMITIVE_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUPrimitiveState, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.topology=*/WGPUPrimitiveTopology_Undefined _wgpu_COMMA \\\r\n    /*.stripIndexFormat=*/WGPUIndexFormat_Undefined _wgpu_COMMA \\\r\n    /*.frontFace=*/WGPUFrontFace_Undefined _wgpu_COMMA \\\r\n    /*.cullMode=*/WGPUCullMode_Undefined _wgpu_COMMA \\\r\n    /*.unclippedDepth=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUPrimitiveState WGPU_PRIMITIVE_STATE_INIT = (new WGPUPrimitiveState
        {
            nextInChain = null,
            topology = (WGPUPrimitiveTopology)(WGPUPrimitiveTopology_Undefined),
            stripIndexFormat = (WGPUIndexFormat)(WGPUIndexFormat_Undefined),
            frontFace = (WGPUFrontFace)(WGPUFrontFace_Undefined),
            cullMode = (WGPUCullMode)(WGPUCullMode_Undefined),
            unclippedDepth = ((0U)),
        });

        [NativeTypeName("#define WGPU_QUERY_SET_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUQuerySetDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.type=*/_wgpu_ENUM_ZERO_INIT(WGPUQueryType) _wgpu_COMMA \\\r\n    /*.count=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUQuerySetDescriptor WGPU_QUERY_SET_DESCRIPTOR_INIT = (new WGPUQuerySetDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            type = (WGPUQueryType)(0),
            count = 0,
        });

        [NativeTypeName("#define WGPU_QUEUE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUQueueDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUQueueDescriptor WGPU_QUEUE_DESCRIPTOR_INIT = (new WGPUQueueDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
        });

        [NativeTypeName("#define WGPU_RENDER_BUNDLE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPURenderBundleDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURenderBundleDescriptor WGPU_RENDER_BUNDLE_DESCRIPTOR_INIT = (new WGPURenderBundleDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(UIntPtr)(0xffffffffffffffffUL),
            }),
        });

        [NativeTypeName("#define WGPU_RENDER_BUNDLE_ENCODER_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPURenderBundleEncoderDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.colorFormatCount=*/0 _wgpu_COMMA \\\r\n    /*.colorFormats=*/NULL _wgpu_COMMA \\\r\n    /*.depthStencilFormat=*/WGPUTextureFormat_Undefined _wgpu_COMMA \\\r\n    /*.sampleCount=*/1 _wgpu_COMMA \\\r\n    /*.depthReadOnly=*/WGPU_FALSE _wgpu_COMMA \\\r\n    /*.stencilReadOnly=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURenderBundleEncoderDescriptor WGPU_RENDER_BUNDLE_ENCODER_DESCRIPTOR_INIT = (new WGPURenderBundleEncoderDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(UIntPtr)(0xffffffffffffffffUL),
            }),
            colorFormatCount = 0,
            colorFormats = null,
            depthStencilFormat = (WGPUTextureFormat)(WGPUTextureFormat_Undefined),
            sampleCount = 1,
            depthReadOnly = ((0U)),
            stencilReadOnly = ((0U)),
        });

        [NativeTypeName("#define WGPU_RENDER_PASS_DEPTH_STENCIL_ATTACHMENT_INIT _wgpu_MAKE_INIT_STRUCT(WGPURenderPassDepthStencilAttachment, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.view=*/NULL _wgpu_COMMA \\\r\n    /*.depthLoadOp=*/WGPULoadOp_Undefined _wgpu_COMMA \\\r\n    /*.depthStoreOp=*/WGPUStoreOp_Undefined _wgpu_COMMA \\\r\n    /*.depthClearValue=*/WGPU_DEPTH_CLEAR_VALUE_UNDEFINED _wgpu_COMMA \\\r\n    /*.depthReadOnly=*/WGPU_FALSE _wgpu_COMMA \\\r\n    /*.stencilLoadOp=*/WGPULoadOp_Undefined _wgpu_COMMA \\\r\n    /*.stencilStoreOp=*/WGPUStoreOp_Undefined _wgpu_COMMA \\\r\n    /*.stencilClearValue=*/0 _wgpu_COMMA \\\r\n    /*.stencilReadOnly=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURenderPassDepthStencilAttachment WGPU_RENDER_PASS_DEPTH_STENCIL_ATTACHMENT_INIT = (new WGPURenderPassDepthStencilAttachment
        {
            nextInChain = null,
            view = null,
            depthLoadOp = (WGPULoadOp)(WGPULoadOp_Undefined),
            depthStoreOp = (WGPUStoreOp)(WGPUStoreOp_Undefined),
            depthClearValue =  float.NaN,
            depthReadOnly = ((0U)),
            stencilLoadOp = (WGPULoadOp)(WGPULoadOp_Undefined),
            stencilStoreOp = (WGPUStoreOp)(WGPUStoreOp_Undefined),
            stencilClearValue = 0,
            stencilReadOnly = ((0U)),
        });

        [NativeTypeName("#define WGPU_RENDER_PASS_MAX_DRAW_COUNT_INIT _wgpu_MAKE_INIT_STRUCT(WGPURenderPassMaxDrawCount, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_RenderPassMaxDrawCount _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.maxDrawCount=*/50000000 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURenderPassMaxDrawCount WGPU_RENDER_PASS_MAX_DRAW_COUNT_INIT = (new WGPURenderPassMaxDrawCount
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_RenderPassMaxDrawCount),
            }),
            maxDrawCount = 50000000,
        });

        [NativeTypeName("#define WGPU_REQUEST_ADAPTER_WEBXR_OPTIONS_INIT _wgpu_MAKE_INIT_STRUCT(WGPURequestAdapterWebXROptions, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_RequestAdapterWebXROptions _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.xrCompatible=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURequestAdapterWebXROptions WGPU_REQUEST_ADAPTER_WEBXR_OPTIONS_INIT = (new WGPURequestAdapterWebXROptions
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_RequestAdapterWebXROptions),
            }),
            xrCompatible = ((0U)),
        });

        [NativeTypeName("#define WGPU_SAMPLER_BINDING_LAYOUT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSamplerBindingLayout, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.type=*/WGPUSamplerBindingType_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSamplerBindingLayout WGPU_SAMPLER_BINDING_LAYOUT_INIT = (new WGPUSamplerBindingLayout
        {
            nextInChain = null,
            type = (WGPUSamplerBindingType)(WGPUSamplerBindingType_Undefined),
        });

        [NativeTypeName("#define WGPU_SAMPLER_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSamplerDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.addressModeU=*/WGPUAddressMode_Undefined _wgpu_COMMA \\\r\n    /*.addressModeV=*/WGPUAddressMode_Undefined _wgpu_COMMA \\\r\n    /*.addressModeW=*/WGPUAddressMode_Undefined _wgpu_COMMA \\\r\n    /*.magFilter=*/WGPUFilterMode_Undefined _wgpu_COMMA \\\r\n    /*.minFilter=*/WGPUFilterMode_Undefined _wgpu_COMMA \\\r\n    /*.mipmapFilter=*/WGPUMipmapFilterMode_Undefined _wgpu_COMMA \\\r\n    /*.lodMinClamp=*/0.f _wgpu_COMMA \\\r\n    /*.lodMaxClamp=*/32.f _wgpu_COMMA \\\r\n    /*.compare=*/WGPUCompareFunction_Undefined _wgpu_COMMA \\\r\n    /*.maxAnisotropy=*/1 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSamplerDescriptor WGPU_SAMPLER_DESCRIPTOR_INIT = (new WGPUSamplerDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            addressModeU = (WGPUAddressMode)(WGPUAddressMode_Undefined),
            addressModeV = (WGPUAddressMode)(WGPUAddressMode_Undefined),
            addressModeW = (WGPUAddressMode)(WGPUAddressMode_Undefined),
            magFilter = (WGPUFilterMode)(WGPUFilterMode_Undefined),
            minFilter = (WGPUFilterMode)(WGPUFilterMode_Undefined),
            mipmapFilter = (WGPUMipmapFilterMode)(WGPUMipmapFilterMode_Undefined),
            lodMinClamp = 0.0f,
            lodMaxClamp = 32.0f,
            compare = (WGPUCompareFunction)(WGPUCompareFunction_Undefined),
            maxAnisotropy = 1,
        });

        [NativeTypeName("#define WGPU_SHADER_SOURCE_SPIRV_INIT _wgpu_MAKE_INIT_STRUCT(WGPUShaderSourceSPIRV, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_ShaderSourceSPIRV _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.codeSize=*/0 _wgpu_COMMA \\\r\n    /*.code=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUShaderSourceSPIRV WGPU_SHADER_SOURCE_SPIRV_INIT = (new WGPUShaderSourceSPIRV
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_ShaderSourceSPIRV),
            }),
            codeSize = 0,
            code = null,
        });

        [NativeTypeName("#define WGPU_SHADER_SOURCE_WGSL_INIT _wgpu_MAKE_INIT_STRUCT(WGPUShaderSourceWGSL, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_ShaderSourceWGSL _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.code=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUShaderSourceWGSL WGPU_SHADER_SOURCE_WGSL_INIT = (new WGPUShaderSourceWGSL
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_ShaderSourceWGSL),
            }),
            code = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
        });

        [NativeTypeName("#define WGPU_STENCIL_FACE_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUStencilFaceState, { \\\r\n    /*.compare=*/WGPUCompareFunction_Undefined _wgpu_COMMA \\\r\n    /*.failOp=*/WGPUStencilOperation_Undefined _wgpu_COMMA \\\r\n    /*.depthFailOp=*/WGPUStencilOperation_Undefined _wgpu_COMMA \\\r\n    /*.passOp=*/WGPUStencilOperation_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUStencilFaceState WGPU_STENCIL_FACE_STATE_INIT = (new WGPUStencilFaceState
        {
            compare = (WGPUCompareFunction)(WGPUCompareFunction_Undefined),
            failOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
            depthFailOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
            passOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
        });

        [NativeTypeName("#define WGPU_STORAGE_TEXTURE_BINDING_LAYOUT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUStorageTextureBindingLayout, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.access=*/WGPUStorageTextureAccess_Undefined _wgpu_COMMA \\\r\n    /*.format=*/WGPUTextureFormat_Undefined _wgpu_COMMA \\\r\n    /*.viewDimension=*/WGPUTextureViewDimension_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUStorageTextureBindingLayout WGPU_STORAGE_TEXTURE_BINDING_LAYOUT_INIT = (new WGPUStorageTextureBindingLayout
        {
            nextInChain = null,
            access = (WGPUStorageTextureAccess)(WGPUStorageTextureAccess_Undefined),
            format = (WGPUTextureFormat)(WGPUTextureFormat_Undefined),
            viewDimension = (WGPUTextureViewDimension)(WGPUTextureViewDimension_Undefined),
        });

        [NativeTypeName("#define WGPU_SUPPORTED_FEATURES_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSupportedFeatures, { \\\r\n    /*.featureCount=*/0 _wgpu_COMMA \\\r\n    /*.features=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSupportedFeatures WGPU_SUPPORTED_FEATURES_INIT = (new WGPUSupportedFeatures
        {
            featureCount = 0,
            features = null,
        });

        [NativeTypeName("#define WGPU_SUPPORTED_INSTANCE_FEATURES_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSupportedInstanceFeatures, { \\\r\n    /*.featureCount=*/0 _wgpu_COMMA \\\r\n    /*.features=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSupportedInstanceFeatures WGPU_SUPPORTED_INSTANCE_FEATURES_INIT = (new WGPUSupportedInstanceFeatures
        {
            featureCount = 0,
            features = null,
        });

        [NativeTypeName("#define WGPU_SUPPORTED_WGSL_LANGUAGE_FEATURES_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSupportedWGSLLanguageFeatures, { \\\r\n    /*.featureCount=*/0 _wgpu_COMMA \\\r\n    /*.features=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSupportedWGSLLanguageFeatures WGPU_SUPPORTED_WGSL_LANGUAGE_FEATURES_INIT = (new WGPUSupportedWGSLLanguageFeatures
        {
            featureCount = 0,
            features = null,
        });

        [NativeTypeName("#define WGPU_SURFACE_CAPABILITIES_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceCapabilities, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.usages=*/WGPUTextureUsage_None _wgpu_COMMA \\\r\n    /*.formatCount=*/0 _wgpu_COMMA \\\r\n    /*.formats=*/NULL _wgpu_COMMA \\\r\n    /*.presentModeCount=*/0 _wgpu_COMMA \\\r\n    /*.presentModes=*/NULL _wgpu_COMMA \\\r\n    /*.alphaModeCount=*/0 _wgpu_COMMA \\\r\n    /*.alphaModes=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceCapabilities WGPU_SURFACE_CAPABILITIES_INIT = (new WGPUSurfaceCapabilities
        {
            nextInChain = null,
            usages = WGPUTextureUsage_None,
            formatCount = 0,
            formats = null,
            presentModeCount = 0,
            presentModes = null,
            alphaModeCount = 0,
            alphaModes = null,
        });

        [NativeTypeName("#define WGPU_SURFACE_COLOR_MANAGEMENT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceColorManagement, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_SurfaceColorManagement _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.colorSpace=*/_wgpu_ENUM_ZERO_INIT(WGPUPredefinedColorSpace) _wgpu_COMMA \\\r\n    /*.toneMappingMode=*/_wgpu_ENUM_ZERO_INIT(WGPUToneMappingMode) _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceColorManagement WGPU_SURFACE_COLOR_MANAGEMENT_INIT = (new WGPUSurfaceColorManagement
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_SurfaceColorManagement),
            }),
            colorSpace = (WGPUPredefinedColorSpace)(0),
            toneMappingMode = (WGPUToneMappingMode)(0),
        });

        [NativeTypeName("#define WGPU_SURFACE_CONFIGURATION_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceConfiguration, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.device=*/NULL _wgpu_COMMA \\\r\n    /*.format=*/WGPUTextureFormat_Undefined _wgpu_COMMA \\\r\n    /*.usage=*/WGPUTextureUsage_RenderAttachment _wgpu_COMMA \\\r\n    /*.width=*/0 _wgpu_COMMA \\\r\n    /*.height=*/0 _wgpu_COMMA \\\r\n    /*.viewFormatCount=*/0 _wgpu_COMMA \\\r\n    /*.viewFormats=*/NULL _wgpu_COMMA \\\r\n    /*.alphaMode=*/WGPUCompositeAlphaMode_Auto _wgpu_COMMA \\\r\n    /*.presentMode=*/WGPUPresentMode_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceConfiguration WGPU_SURFACE_CONFIGURATION_INIT = (new WGPUSurfaceConfiguration
        {
            nextInChain = null,
            device = null,
            format = (WGPUTextureFormat)(WGPUTextureFormat_Undefined),
            usage = WGPUTextureUsage_RenderAttachment,
            width = 0,
            height = 0,
            viewFormatCount = 0,
            viewFormats = null,
            alphaMode = (WGPUCompositeAlphaMode)(WGPUCompositeAlphaMode_Auto),
            presentMode = (WGPUPresentMode)(WGPUPresentMode_Undefined),
        });

        [NativeTypeName("#define WGPU_SURFACE_SOURCE_ANDROID_NATIVE_WINDOW_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceSourceAndroidNativeWindow, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_SurfaceSourceAndroidNativeWindow _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.window=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceSourceAndroidNativeWindow WGPU_SURFACE_SOURCE_ANDROID_NATIVE_WINDOW_INIT = (new WGPUSurfaceSourceAndroidNativeWindow
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_SurfaceSourceAndroidNativeWindow),
            }),
            window = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_SURFACE_SOURCE_METAL_LAYER_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceSourceMetalLayer, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_SurfaceSourceMetalLayer _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.layer=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceSourceMetalLayer WGPU_SURFACE_SOURCE_METAL_LAYER_INIT = (new WGPUSurfaceSourceMetalLayer
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_SurfaceSourceMetalLayer),
            }),
            layer = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_SURFACE_SOURCE_WAYLAND_SURFACE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceSourceWaylandSurface, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_SurfaceSourceWaylandSurface _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.display=*/NULL _wgpu_COMMA \\\r\n    /*.surface=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceSourceWaylandSurface WGPU_SURFACE_SOURCE_WAYLAND_SURFACE_INIT = (new WGPUSurfaceSourceWaylandSurface
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_SurfaceSourceWaylandSurface),
            }),
            display = unchecked((void*)(0)),
            surface = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_SURFACE_SOURCE_WINDOWS_HWND_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceSourceWindowsHWND, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_SurfaceSourceWindowsHWND _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.hinstance=*/NULL _wgpu_COMMA \\\r\n    /*.hwnd=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceSourceWindowsHWND WGPU_SURFACE_SOURCE_WINDOWS_HWND_INIT = (new WGPUSurfaceSourceWindowsHWND
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_SurfaceSourceWindowsHWND),
            }),
            hinstance = unchecked((void*)(0)),
            hwnd = unchecked((void*)(0)),
        });

        [NativeTypeName("#define WGPU_SURFACE_SOURCE_XCB_WINDOW_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceSourceXCBWindow, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_SurfaceSourceXCBWindow _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.connection=*/NULL _wgpu_COMMA \\\r\n    /*.window=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceSourceXCBWindow WGPU_SURFACE_SOURCE_XCB_WINDOW_INIT = (new WGPUSurfaceSourceXCBWindow
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_SurfaceSourceXCBWindow),
            }),
            connection = unchecked((void*)(0)),
            window = 0,
        });

        [NativeTypeName("#define WGPU_SURFACE_SOURCE_XLIB_WINDOW_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceSourceXlibWindow, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_SurfaceSourceXlibWindow _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.display=*/NULL _wgpu_COMMA \\\r\n    /*.window=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceSourceXlibWindow WGPU_SURFACE_SOURCE_XLIB_WINDOW_INIT = (new WGPUSurfaceSourceXlibWindow
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_SurfaceSourceXlibWindow),
            }),
            display = unchecked((void*)(0)),
            window = 0,
        });

        [NativeTypeName("#define WGPU_SURFACE_TEXTURE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceTexture, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.texture=*/NULL _wgpu_COMMA \\\r\n    /*.status=*/_wgpu_ENUM_ZERO_INIT(WGPUSurfaceGetCurrentTextureStatus) _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceTexture WGPU_SURFACE_TEXTURE_INIT = (new WGPUSurfaceTexture
        {
            nextInChain = null,
            texture = null,
            status = (WGPUSurfaceGetCurrentTextureStatus)(0),
        });

        [NativeTypeName("#define WGPU_TEXEL_COPY_BUFFER_LAYOUT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTexelCopyBufferLayout, { \\\r\n    /*.offset=*/0 _wgpu_COMMA \\\r\n    /*.bytesPerRow=*/WGPU_COPY_STRIDE_UNDEFINED _wgpu_COMMA \\\r\n    /*.rowsPerImage=*/WGPU_COPY_STRIDE_UNDEFINED _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTexelCopyBufferLayout WGPU_TEXEL_COPY_BUFFER_LAYOUT_INIT = (new WGPUTexelCopyBufferLayout
        {
            offset = 0,
            bytesPerRow = (0xffffffffU),
            rowsPerImage = (0xffffffffU),
        });

        [NativeTypeName("#define WGPU_TEXTURE_BINDING_LAYOUT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTextureBindingLayout, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.sampleType=*/WGPUTextureSampleType_Undefined _wgpu_COMMA \\\r\n    /*.viewDimension=*/WGPUTextureViewDimension_Undefined _wgpu_COMMA \\\r\n    /*.multisampled=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTextureBindingLayout WGPU_TEXTURE_BINDING_LAYOUT_INIT = (new WGPUTextureBindingLayout
        {
            nextInChain = null,
            sampleType = (WGPUTextureSampleType)(WGPUTextureSampleType_Undefined),
            viewDimension = (WGPUTextureViewDimension)(WGPUTextureViewDimension_Undefined),
            multisampled = ((0U)),
        });

        [NativeTypeName("#define WGPU_TEXTURE_BINDING_VIEW_DIMENSION_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTextureBindingViewDimension, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_TextureBindingViewDimension _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.textureBindingViewDimension=*/WGPUTextureViewDimension_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTextureBindingViewDimension WGPU_TEXTURE_BINDING_VIEW_DIMENSION_INIT = (new WGPUTextureBindingViewDimension
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_TextureBindingViewDimension),
            }),
            textureBindingViewDimension = (WGPUTextureViewDimension)(WGPUTextureViewDimension_Undefined),
        });

        [NativeTypeName("#define WGPU_TEXTURE_COMPONENT_SWIZZLE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTextureComponentSwizzle, { \\\r\n    /*.r=*/WGPUComponentSwizzle_Undefined _wgpu_COMMA \\\r\n    /*.g=*/WGPUComponentSwizzle_Undefined _wgpu_COMMA \\\r\n    /*.b=*/WGPUComponentSwizzle_Undefined _wgpu_COMMA \\\r\n    /*.a=*/WGPUComponentSwizzle_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTextureComponentSwizzle WGPU_TEXTURE_COMPONENT_SWIZZLE_INIT = (new WGPUTextureComponentSwizzle
        {
            r = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
            g = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
            b = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
            a = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
        });

        [NativeTypeName("#define WGPU_VERTEX_ATTRIBUTE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUVertexAttribute, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.format=*/_wgpu_ENUM_ZERO_INIT(WGPUVertexFormat) _wgpu_COMMA \\\r\n    /*.offset=*/0 _wgpu_COMMA \\\r\n    /*.shaderLocation=*/0 _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUVertexAttribute WGPU_VERTEX_ATTRIBUTE_INIT = (new WGPUVertexAttribute
        {
            nextInChain = null,
            format = (WGPUVertexFormat)(0),
            offset = 0,
            shaderLocation = 0,
        });

        [NativeTypeName("#define WGPU_BIND_GROUP_ENTRY_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBindGroupEntry, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.binding=*/0 _wgpu_COMMA \\\r\n    /*.buffer=*/NULL _wgpu_COMMA \\\r\n    /*.offset=*/0 _wgpu_COMMA \\\r\n    /*.size=*/WGPU_WHOLE_SIZE _wgpu_COMMA \\\r\n    /*.sampler=*/NULL _wgpu_COMMA \\\r\n    /*.textureView=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBindGroupEntry WGPU_BIND_GROUP_ENTRY_INIT = (new WGPUBindGroupEntry
        {
            nextInChain = null,
            binding = 0,
            buffer = null,
            offset = 0,
            size = (UIntPtr)(0xffffffffffffffffUL),
            sampler = null,
            textureView = null,
        });

        [NativeTypeName("#define WGPU_BIND_GROUP_LAYOUT_ENTRY_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBindGroupLayoutEntry, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.binding=*/0 _wgpu_COMMA \\\r\n    /*.visibility=*/WGPUShaderStage_None _wgpu_COMMA \\\r\n    /*.bindingArraySize=*/0 _wgpu_COMMA \\\r\n    /*.buffer=*/_wgpu_STRUCT_ZERO_INIT _wgpu_COMMA \\\r\n    /*.sampler=*/_wgpu_STRUCT_ZERO_INIT _wgpu_COMMA \\\r\n    /*.texture=*/_wgpu_STRUCT_ZERO_INIT _wgpu_COMMA \\\r\n    /*.storageTexture=*/_wgpu_STRUCT_ZERO_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBindGroupLayoutEntry WGPU_BIND_GROUP_LAYOUT_ENTRY_INIT = (new WGPUBindGroupLayoutEntry
        {
            nextInChain = null,
            binding = 0,
            visibility = WGPUShaderStage_None,
            bindingArraySize = 0,
            buffer = new WGPUBufferBindingLayout
            {
                nextInChain = null,
            },
            sampler = new WGPUSamplerBindingLayout
            {
                nextInChain = null,
            },
            texture = new WGPUTextureBindingLayout
            {
                nextInChain = null,
            },
            storageTexture = new WGPUStorageTextureBindingLayout
            {
                nextInChain = null,
            },
        });

        [NativeTypeName("#define WGPU_BLEND_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBlendState, { \\\r\n    /*.color=*/WGPU_BLEND_COMPONENT_INIT _wgpu_COMMA \\\r\n    /*.alpha=*/WGPU_BLEND_COMPONENT_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBlendState WGPU_BLEND_STATE_INIT = (new WGPUBlendState
        {
            color = (new WGPUBlendComponent
            {
                operation = (WGPUBlendOperation)(WGPUBlendOperation_Undefined),
                srcFactor = (WGPUBlendFactor)(WGPUBlendFactor_Undefined),
                dstFactor = (WGPUBlendFactor)(WGPUBlendFactor_Undefined),
            }),
            alpha = (new WGPUBlendComponent
            {
                operation = (WGPUBlendOperation)(WGPUBlendOperation_Undefined),
                srcFactor = (WGPUBlendFactor)(WGPUBlendFactor_Undefined),
                dstFactor = (WGPUBlendFactor)(WGPUBlendFactor_Undefined),
            }),
        });

        [NativeTypeName("#define WGPU_COMPILATION_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUCompilationInfo, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.messageCount=*/0 _wgpu_COMMA \\\r\n    /*.messages=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUCompilationInfo WGPU_COMPILATION_INFO_INIT = (new WGPUCompilationInfo
        {
            nextInChain = null,
            messageCount = 0,
            messages = null,
        });

        [NativeTypeName("#define WGPU_COMPUTE_PASS_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUComputePassDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.timestampWrites=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUComputePassDescriptor WGPU_COMPUTE_PASS_DESCRIPTOR_INIT = (new WGPUComputePassDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            timestampWrites = null,
        });

        [NativeTypeName("#define WGPU_COMPUTE_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUComputeState, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.module=*/NULL _wgpu_COMMA \\\r\n    /*.entryPoint=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.constantCount=*/0 _wgpu_COMMA \\\r\n    /*.constants=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUComputeState WGPU_COMPUTE_STATE_INIT = (new WGPUComputeState
        {
            nextInChain = null,
            module = null,
            entryPoint = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            constantCount = 0,
            constants = null,
        });

        [NativeTypeName("#define WGPU_DEPTH_STENCIL_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUDepthStencilState, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.format=*/WGPUTextureFormat_Undefined _wgpu_COMMA \\\r\n    /*.depthWriteEnabled=*/WGPUOptionalBool_Undefined _wgpu_COMMA \\\r\n    /*.depthCompare=*/WGPUCompareFunction_Undefined _wgpu_COMMA \\\r\n    /*.stencilFront=*/WGPU_STENCIL_FACE_STATE_INIT _wgpu_COMMA \\\r\n    /*.stencilBack=*/WGPU_STENCIL_FACE_STATE_INIT _wgpu_COMMA \\\r\n    /*.stencilReadMask=*/0xFFFFFFFF _wgpu_COMMA \\\r\n    /*.stencilWriteMask=*/0xFFFFFFFF _wgpu_COMMA \\\r\n    /*.depthBias=*/0 _wgpu_COMMA \\\r\n    /*.depthBiasSlopeScale=*/0.f _wgpu_COMMA \\\r\n    /*.depthBiasClamp=*/0.f _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUDepthStencilState WGPU_DEPTH_STENCIL_STATE_INIT = (new WGPUDepthStencilState
        {
            nextInChain = null,
            format = (WGPUTextureFormat)(WGPUTextureFormat_Undefined),
            depthWriteEnabled = (WGPUOptionalBool)(WGPUOptionalBool_Undefined),
            depthCompare = (WGPUCompareFunction)(WGPUCompareFunction_Undefined),
            stencilFront = (new WGPUStencilFaceState
            {
                compare = (WGPUCompareFunction)(WGPUCompareFunction_Undefined),
                failOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
                depthFailOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
                passOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
            }),
            stencilBack = (new WGPUStencilFaceState
            {
                compare = (WGPUCompareFunction)(WGPUCompareFunction_Undefined),
                failOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
                depthFailOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
                passOp = (WGPUStencilOperation)(WGPUStencilOperation_Undefined),
            }),
            stencilReadMask = 0xFFFFFFFF,
            stencilWriteMask = 0xFFFFFFFF,
            depthBias = 0,
            depthBiasSlopeScale = 0.0f,
            depthBiasClamp = 0.0f,
        });

        [NativeTypeName("#define WGPU_FUTURE_WAIT_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUFutureWaitInfo, { \\\r\n    /*.future=*/WGPU_FUTURE_INIT _wgpu_COMMA \\\r\n    /*.completed=*/WGPU_FALSE _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUFutureWaitInfo WGPU_FUTURE_WAIT_INFO_INIT = (new WGPUFutureWaitInfo
        {
            future = (new WGPUFuture
            {
                id = 0,
            }),
            completed = ((0U)),
        });

        [NativeTypeName("#define WGPU_INSTANCE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUInstanceDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.requiredFeatureCount=*/0 _wgpu_COMMA \\\r\n    /*.requiredFeatures=*/NULL _wgpu_COMMA \\\r\n    /*.requiredLimits=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUInstanceDescriptor WGPU_INSTANCE_DESCRIPTOR_INIT = (new WGPUInstanceDescriptor
        {
            nextInChain = null,
            requiredFeatureCount = 0,
            requiredFeatures = null,
            requiredLimits = null,
        });

        [NativeTypeName("#define WGPU_LIMITS_INIT _wgpu_MAKE_INIT_STRUCT(WGPULimits, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.maxTextureDimension1D=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxTextureDimension2D=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxTextureDimension3D=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxTextureArrayLayers=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxBindGroups=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxBindGroupsPlusVertexBuffers=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxBindingsPerBindGroup=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxDynamicUniformBuffersPerPipelineLayout=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxDynamicStorageBuffersPerPipelineLayout=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxSampledTexturesPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxSamplersPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxStorageBuffersPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxStorageTexturesPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxUniformBuffersPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxUniformBufferBindingSize=*/WGPU_LIMIT_U64_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxStorageBufferBindingSize=*/WGPU_LIMIT_U64_UNDEFINED _wgpu_COMMA \\\r\n    /*.minUniformBufferOffsetAlignment=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.minStorageBufferOffsetAlignment=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxVertexBuffers=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxBufferSize=*/WGPU_LIMIT_U64_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxVertexAttributes=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxVertexBufferArrayStride=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxInterStageShaderVariables=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxColorAttachments=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxColorAttachmentBytesPerSample=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxComputeWorkgroupStorageSize=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxComputeInvocationsPerWorkgroup=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxComputeWorkgroupSizeX=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxComputeWorkgroupSizeY=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxComputeWorkgroupSizeZ=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxComputeWorkgroupsPerDimension=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n    /*.maxImmediateSize=*/WGPU_LIMIT_U32_UNDEFINED _wgpu_COMMA \\\r\n})")]
        public static readonly WGPULimits WGPU_LIMITS_INIT = (new WGPULimits
        {
            nextInChain = null,
            maxTextureDimension1D = (0xffffffffU),
            maxTextureDimension2D = (0xffffffffU),
            maxTextureDimension3D = (0xffffffffU),
            maxTextureArrayLayers = (0xffffffffU),
            maxBindGroups = (0xffffffffU),
            maxBindGroupsPlusVertexBuffers = (0xffffffffU),
            maxBindingsPerBindGroup = (0xffffffffU),
            maxDynamicUniformBuffersPerPipelineLayout = (0xffffffffU),
            maxDynamicStorageBuffersPerPipelineLayout = (0xffffffffU),
            maxSampledTexturesPerShaderStage = (0xffffffffU),
            maxSamplersPerShaderStage = (0xffffffffU),
            maxStorageBuffersPerShaderStage = (0xffffffffU),
            maxStorageTexturesPerShaderStage = (0xffffffffU),
            maxUniformBuffersPerShaderStage = (0xffffffffU),
            maxUniformBufferBindingSize = (UIntPtr)(0xffffffffffffffffUL),
            maxStorageBufferBindingSize = (UIntPtr)(0xffffffffffffffffUL),
            minUniformBufferOffsetAlignment = (0xffffffffU),
            minStorageBufferOffsetAlignment = (0xffffffffU),
            maxVertexBuffers = (0xffffffffU),
            maxBufferSize = (UIntPtr)(0xffffffffffffffffUL),
            maxVertexAttributes = (0xffffffffU),
            maxVertexBufferArrayStride = (0xffffffffU),
            maxInterStageShaderVariables = (0xffffffffU),
            maxColorAttachments = (0xffffffffU),
            maxColorAttachmentBytesPerSample = (0xffffffffU),
            maxComputeWorkgroupStorageSize = (0xffffffffU),
            maxComputeInvocationsPerWorkgroup = (0xffffffffU),
            maxComputeWorkgroupSizeX = (0xffffffffU),
            maxComputeWorkgroupSizeY = (0xffffffffU),
            maxComputeWorkgroupSizeZ = (0xffffffffU),
            maxComputeWorkgroupsPerDimension = (0xffffffffU),
            maxImmediateSize = (0xffffffffU),
        });

        [NativeTypeName("#define WGPU_RENDER_PASS_COLOR_ATTACHMENT_INIT _wgpu_MAKE_INIT_STRUCT(WGPURenderPassColorAttachment, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.view=*/NULL _wgpu_COMMA \\\r\n    /*.depthSlice=*/WGPU_DEPTH_SLICE_UNDEFINED _wgpu_COMMA \\\r\n    /*.resolveTarget=*/NULL _wgpu_COMMA \\\r\n    /*.loadOp=*/WGPULoadOp_Undefined _wgpu_COMMA \\\r\n    /*.storeOp=*/WGPUStoreOp_Undefined _wgpu_COMMA \\\r\n    /*.clearValue=*/WGPU_COLOR_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURenderPassColorAttachment WGPU_RENDER_PASS_COLOR_ATTACHMENT_INIT = (new WGPURenderPassColorAttachment
        {
            nextInChain = null,
            view = null,
            depthSlice = (0xffffffffU),
            resolveTarget = null,
            loadOp = (WGPULoadOp)(WGPULoadOp_Undefined),
            storeOp = (WGPUStoreOp)(WGPUStoreOp_Undefined),
            clearValue = (new WGPUColor
            {
                r = 0.0,
                g = 0.0,
                b = 0.0,
                a = 0.0,
            }),
        });

        [NativeTypeName("#define WGPU_REQUEST_ADAPTER_OPTIONS_INIT _wgpu_MAKE_INIT_STRUCT(WGPURequestAdapterOptions, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.featureLevel=*/WGPUFeatureLevel_Undefined _wgpu_COMMA \\\r\n    /*.powerPreference=*/WGPUPowerPreference_Undefined _wgpu_COMMA \\\r\n    /*.forceFallbackAdapter=*/WGPU_FALSE _wgpu_COMMA \\\r\n    /*.backendType=*/WGPUBackendType_Undefined _wgpu_COMMA \\\r\n    /*.compatibleSurface=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURequestAdapterOptions WGPU_REQUEST_ADAPTER_OPTIONS_INIT = (new WGPURequestAdapterOptions
        {
            nextInChain = null,
            featureLevel = (WGPUFeatureLevel)(WGPUFeatureLevel_Undefined),
            powerPreference = (WGPUPowerPreference)(WGPUPowerPreference_Undefined),
            forceFallbackAdapter = ((0U)),
            backendType = (WGPUBackendType)(WGPUBackendType_Undefined),
            compatibleSurface = null,
        });

        [NativeTypeName("#define WGPU_SHADER_MODULE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUShaderModuleDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUShaderModuleDescriptor WGPU_SHADER_MODULE_DESCRIPTOR_INIT = (new WGPUShaderModuleDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
        });

        [NativeTypeName("#define WGPU_SURFACE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUSurfaceDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUSurfaceDescriptor WGPU_SURFACE_DESCRIPTOR_INIT = (new WGPUSurfaceDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
        });

        [NativeTypeName("#define WGPU_TEXEL_COPY_BUFFER_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTexelCopyBufferInfo, { \\\r\n    /*.layout=*/WGPU_TEXEL_COPY_BUFFER_LAYOUT_INIT _wgpu_COMMA \\\r\n    /*.buffer=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTexelCopyBufferInfo WGPU_TEXEL_COPY_BUFFER_INFO_INIT = (new WGPUTexelCopyBufferInfo
        {
            layout = (new WGPUTexelCopyBufferLayout
            {
                offset = 0,
                bytesPerRow = (0xffffffffU),
                rowsPerImage = (0xffffffffU),
            }),
            buffer = null,
        });

        [NativeTypeName("#define WGPU_TEXEL_COPY_TEXTURE_INFO_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTexelCopyTextureInfo, { \\\r\n    /*.texture=*/NULL _wgpu_COMMA \\\r\n    /*.mipLevel=*/0 _wgpu_COMMA \\\r\n    /*.origin=*/WGPU_ORIGIN_3D_INIT _wgpu_COMMA \\\r\n    /*.aspect=*/WGPUTextureAspect_Undefined _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTexelCopyTextureInfo WGPU_TEXEL_COPY_TEXTURE_INFO_INIT = (new WGPUTexelCopyTextureInfo
        {
            texture = null,
            mipLevel = 0,
            origin = (new WGPUOrigin3D
            {
                x = 0,
                y = 0,
                z = 0,
            }),
            aspect = (WGPUTextureAspect)(WGPUTextureAspect_Undefined),
        });

        [NativeTypeName("#define WGPU_TEXTURE_COMPONENT_SWIZZLE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTextureComponentSwizzleDescriptor, { \\\r\n    /*.chain=*/_wgpu_MAKE_INIT_STRUCT(WGPUChainedStruct, { \\\r\n        /*.next=*/NULL _wgpu_COMMA \\\r\n        /*.sType=*/WGPUSType_TextureComponentSwizzleDescriptor _wgpu_COMMA \\\r\n    }) _wgpu_COMMA \\\r\n    /*.swizzle=*/WGPU_TEXTURE_COMPONENT_SWIZZLE_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTextureComponentSwizzleDescriptor WGPU_TEXTURE_COMPONENT_SWIZZLE_DESCRIPTOR_INIT = (new WGPUTextureComponentSwizzleDescriptor
        {
            chain = (new WGPUChainedStruct
            {
                next = null,
                sType = (WGPUSType)(WGPUSType_TextureComponentSwizzleDescriptor),
            }),
            swizzle = (new WGPUTextureComponentSwizzle
            {
                r = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
                g = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
                b = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
                a = (WGPUComponentSwizzle)(WGPUComponentSwizzle_Undefined),
            }),
        });

        [NativeTypeName("#define WGPU_TEXTURE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTextureDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.usage=*/WGPUTextureUsage_None _wgpu_COMMA \\\r\n    /*.dimension=*/WGPUTextureDimension_Undefined _wgpu_COMMA \\\r\n    /*.size=*/WGPU_EXTENT_3D_INIT _wgpu_COMMA \\\r\n    /*.format=*/WGPUTextureFormat_Undefined _wgpu_COMMA \\\r\n    /*.mipLevelCount=*/1 _wgpu_COMMA \\\r\n    /*.sampleCount=*/1 _wgpu_COMMA \\\r\n    /*.viewFormatCount=*/0 _wgpu_COMMA \\\r\n    /*.viewFormats=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTextureDescriptor WGPU_TEXTURE_DESCRIPTOR_INIT = (new WGPUTextureDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            usage = WGPUTextureUsage_None,
            dimension = (WGPUTextureDimension)(WGPUTextureDimension_Undefined),
            size = (new WGPUExtent3D
            {
                width = 0,
                height = 1,
                depthOrArrayLayers = 1,
            }),
            format = (WGPUTextureFormat)(WGPUTextureFormat_Undefined),
            mipLevelCount = 1,
            sampleCount = 1,
            viewFormatCount = 0,
            viewFormats = null,
        });

        [NativeTypeName("#define WGPU_VERTEX_BUFFER_LAYOUT_INIT _wgpu_MAKE_INIT_STRUCT(WGPUVertexBufferLayout, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.stepMode=*/WGPUVertexStepMode_Undefined _wgpu_COMMA \\\r\n    /*.arrayStride=*/0 _wgpu_COMMA \\\r\n    /*.attributeCount=*/0 _wgpu_COMMA \\\r\n    /*.attributes=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUVertexBufferLayout WGPU_VERTEX_BUFFER_LAYOUT_INIT = (new WGPUVertexBufferLayout
        {
            nextInChain = null,
            stepMode = (WGPUVertexStepMode)(WGPUVertexStepMode_Undefined),
            arrayStride = 0,
            attributeCount = 0,
            attributes = null,
        });

        [NativeTypeName("#define WGPU_BIND_GROUP_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBindGroupDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.layout=*/NULL _wgpu_COMMA \\\r\n    /*.entryCount=*/0 _wgpu_COMMA \\\r\n    /*.entries=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBindGroupDescriptor WGPU_BIND_GROUP_DESCRIPTOR_INIT = (new WGPUBindGroupDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            layout = null,
            entryCount = 0,
            entries = null,
        });

        [NativeTypeName("#define WGPU_BIND_GROUP_LAYOUT_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUBindGroupLayoutDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.entryCount=*/0 _wgpu_COMMA \\\r\n    /*.entries=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUBindGroupLayoutDescriptor WGPU_BIND_GROUP_LAYOUT_DESCRIPTOR_INIT = (new WGPUBindGroupLayoutDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            entryCount = 0,
            entries = null,
        });

        [NativeTypeName("#define WGPU_COLOR_TARGET_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUColorTargetState, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.format=*/WGPUTextureFormat_Undefined _wgpu_COMMA \\\r\n    /*.blend=*/NULL _wgpu_COMMA \\\r\n    /*.writeMask=*/WGPUColorWriteMask_All _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUColorTargetState WGPU_COLOR_TARGET_STATE_INIT = (new WGPUColorTargetState
        {
            nextInChain = null,
            format = (WGPUTextureFormat)(WGPUTextureFormat_Undefined),
            blend = null,
            writeMask = WGPUColorWriteMask_All,
        });

        [NativeTypeName("#define WGPU_COMPUTE_PIPELINE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUComputePipelineDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.layout=*/NULL _wgpu_COMMA \\\r\n    /*.compute=*/WGPU_COMPUTE_STATE_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUComputePipelineDescriptor WGPU_COMPUTE_PIPELINE_DESCRIPTOR_INIT = (new WGPUComputePipelineDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            layout = null,
            compute = (new WGPUComputeState
            {
                nextInChain = null,
                module = null,
                entryPoint = (new WGPUStringView
                {
                    data = null,
                    length = (UIntPtr)(0xffffffffffffffffUL),
                }),
                constantCount = 0,
                constants = null,
            }),
        });

        [NativeTypeName("#define WGPU_DEVICE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUDeviceDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.requiredFeatureCount=*/0 _wgpu_COMMA \\\r\n    /*.requiredFeatures=*/NULL _wgpu_COMMA \\\r\n    /*.requiredLimits=*/NULL _wgpu_COMMA \\\r\n    /*.defaultQueue=*/WGPU_QUEUE_DESCRIPTOR_INIT _wgpu_COMMA \\\r\n    /*.deviceLostCallbackInfo=*/WGPU_DEVICE_LOST_CALLBACK_INFO_INIT _wgpu_COMMA \\\r\n    /*.uncapturedErrorCallbackInfo=*/WGPU_UNCAPTURED_ERROR_CALLBACK_INFO_INIT _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUDeviceDescriptor WGPU_DEVICE_DESCRIPTOR_INIT = (new WGPUDeviceDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            requiredFeatureCount = 0,
            requiredFeatures = null,
            requiredLimits = null,
            defaultQueue = (new WGPUQueueDescriptor
            {
                nextInChain = null,
                label = (new WGPUStringView
                {
                    data = null,
                    length = (UIntPtr)(0xffffffffffffffffUL),
                }),
            }),
            deviceLostCallbackInfo = (new WGPUDeviceLostCallbackInfo
            {
                nextInChain = null,
                mode = (WGPUCallbackMode)(0),
                callback = null,
                userdata1 = unchecked((void*)(0)),
                userdata2 = unchecked((void*)(0)),
            }),
            uncapturedErrorCallbackInfo = (new WGPUUncapturedErrorCallbackInfo
            {
                nextInChain = null,
                callback = null,
                userdata1 = unchecked((void*)(0)),
                userdata2 = unchecked((void*)(0)),
            }),
        });

        [NativeTypeName("#define WGPU_RENDER_PASS_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPURenderPassDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.colorAttachmentCount=*/0 _wgpu_COMMA \\\r\n    /*.colorAttachments=*/NULL _wgpu_COMMA \\\r\n    /*.depthStencilAttachment=*/NULL _wgpu_COMMA \\\r\n    /*.occlusionQuerySet=*/NULL _wgpu_COMMA \\\r\n    /*.timestampWrites=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURenderPassDescriptor WGPU_RENDER_PASS_DESCRIPTOR_INIT = (new WGPURenderPassDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            colorAttachmentCount = 0,
            colorAttachments = null,
            depthStencilAttachment = null,
            occlusionQuerySet = null,
            timestampWrites = null,
        });

        [NativeTypeName("#define WGPU_TEXTURE_VIEW_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPUTextureViewDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.format=*/WGPUTextureFormat_Undefined _wgpu_COMMA \\\r\n    /*.dimension=*/WGPUTextureViewDimension_Undefined _wgpu_COMMA \\\r\n    /*.baseMipLevel=*/0 _wgpu_COMMA \\\r\n    /*.mipLevelCount=*/WGPU_MIP_LEVEL_COUNT_UNDEFINED _wgpu_COMMA \\\r\n    /*.baseArrayLayer=*/0 _wgpu_COMMA \\\r\n    /*.arrayLayerCount=*/WGPU_ARRAY_LAYER_COUNT_UNDEFINED _wgpu_COMMA \\\r\n    /*.aspect=*/WGPUTextureAspect_Undefined _wgpu_COMMA \\\r\n    /*.usage=*/WGPUTextureUsage_None _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUTextureViewDescriptor WGPU_TEXTURE_VIEW_DESCRIPTOR_INIT = (new WGPUTextureViewDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            format = (WGPUTextureFormat)(WGPUTextureFormat_Undefined),
            dimension = (WGPUTextureViewDimension)(WGPUTextureViewDimension_Undefined),
            baseMipLevel = 0,
            mipLevelCount = (0xffffffffU),
            baseArrayLayer = 0,
            arrayLayerCount = (0xffffffffU),
            aspect = (WGPUTextureAspect)(WGPUTextureAspect_Undefined),
            usage = WGPUTextureUsage_None,
        });

        [NativeTypeName("#define WGPU_VERTEX_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUVertexState, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.module=*/NULL _wgpu_COMMA \\\r\n    /*.entryPoint=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.constantCount=*/0 _wgpu_COMMA \\\r\n    /*.constants=*/NULL _wgpu_COMMA \\\r\n    /*.bufferCount=*/0 _wgpu_COMMA \\\r\n    /*.buffers=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUVertexState WGPU_VERTEX_STATE_INIT = (new WGPUVertexState
        {
            nextInChain = null,
            module = null,
            entryPoint = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            constantCount = 0,
            constants = null,
            bufferCount = 0,
            buffers = null,
        });

        [NativeTypeName("#define WGPU_FRAGMENT_STATE_INIT _wgpu_MAKE_INIT_STRUCT(WGPUFragmentState, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.module=*/NULL _wgpu_COMMA \\\r\n    /*.entryPoint=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.constantCount=*/0 _wgpu_COMMA \\\r\n    /*.constants=*/NULL _wgpu_COMMA \\\r\n    /*.targetCount=*/0 _wgpu_COMMA \\\r\n    /*.targets=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPUFragmentState WGPU_FRAGMENT_STATE_INIT = (new WGPUFragmentState
        {
            nextInChain = null,
            module = null,
            entryPoint = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            constantCount = 0,
            constants = null,
            targetCount = 0,
            targets = null,
        });

        [NativeTypeName("#define WGPU_RENDER_PIPELINE_DESCRIPTOR_INIT _wgpu_MAKE_INIT_STRUCT(WGPURenderPipelineDescriptor, { \\\r\n    /*.nextInChain=*/NULL _wgpu_COMMA \\\r\n    /*.label=*/WGPU_STRING_VIEW_INIT _wgpu_COMMA \\\r\n    /*.layout=*/NULL _wgpu_COMMA \\\r\n    /*.vertex=*/WGPU_VERTEX_STATE_INIT _wgpu_COMMA \\\r\n    /*.primitive=*/WGPU_PRIMITIVE_STATE_INIT _wgpu_COMMA \\\r\n    /*.depthStencil=*/NULL _wgpu_COMMA \\\r\n    /*.multisample=*/WGPU_MULTISAMPLE_STATE_INIT _wgpu_COMMA \\\r\n    /*.fragment=*/NULL _wgpu_COMMA \\\r\n})")]
        public static readonly WGPURenderPipelineDescriptor WGPU_RENDER_PIPELINE_DESCRIPTOR_INIT = (new WGPURenderPipelineDescriptor
        {
            nextInChain = null,
            label = (new WGPUStringView
            {
                data = null,
                length = (UIntPtr)(0xffffffffffffffffUL),
            }),
            layout = null,
            vertex = (new WGPUVertexState
            {
                nextInChain = null,
                module = null,
                entryPoint = (new WGPUStringView
                {
                    data = null,
                    length = (UIntPtr)(0xffffffffffffffffUL),
                }),
                constantCount = 0,
                constants = null,
                bufferCount = 0,
                buffers = null,
            }),
            primitive = (new WGPUPrimitiveState
            {
                nextInChain = null,
                topology = (WGPUPrimitiveTopology)(WGPUPrimitiveTopology_Undefined),
                stripIndexFormat = (WGPUIndexFormat)(WGPUIndexFormat_Undefined),
                frontFace = (WGPUFrontFace)(WGPUFrontFace_Undefined),
                cullMode = (WGPUCullMode)(WGPUCullMode_Undefined),
                unclippedDepth = ((0U)),
            }),
            depthStencil = null,
            multisample = (new WGPUMultisampleState
            {
                nextInChain = null,
                count = 1,
                mask = 0xFFFFFFFF,
                alphaToCoverageEnabled = ((0U)),
            }),
            fragment = null,
        });
    }
}
