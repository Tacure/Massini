
using System.Runtime.InteropServices;
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Classes.Encoders;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Sugar.Classes.Internal;
using Massini.Graphics.VkAL.Sugar.Classes.Reflection;
using Massini.Graphics.VkAL.Sugar.Structs;
using Massini.Graphics.VkAL.Sugar.Structs.Internal;
using Buffer = Massini.Graphics.VkAL.Classes.Buffer;

namespace Massini.Graphics.VkAL.Sugar.Classes
{
    public unsafe class SmartShaderLink : IResource, IDisposable
    {
        public ResId Id => m_id;

        public bool IsDisposed => m_isDisposed;

        public Device Device => m_shaderLink.Device;

        public SmartShaderLink(Device i_device, in SmartShaderLinkCreateParams i_createParams)
        {
            m_reflection = new ShadersReflection(new()
            {
                p_code = [.. i_createParams.p_stages.Select(s => s.p_code)],
            });

            PushConstantDescription? push = null;
            if (m_reflection.PushConstants != null)
            {
                push = new PushConstantDescription()
                {
                    p_stage = m_reflection.PushConstants.StageFlags,
                    p_size = m_reflection.PushConstants.Size,
                };
            }

            SetDeclaration[] sets = new SetDeclaration[m_reflection.Sets.Length];
            for (int i = 0; i < m_reflection.Sets.Length; i++)
            {
                SetEntryDeclaration[] entries = new SetEntryDeclaration[m_reflection.Sets[i].Bindings.Length];
                for (int j = 0; j < m_reflection.Sets[i].Bindings.Length; j++)
                {
                    entries[j] = new SetEntryDeclaration()
                    {
                        p_binding = m_reflection.Sets[i].Bindings[j].BindingNumber,
                        p_count = m_reflection.Sets[i].Bindings[j].Count,
                        p_type = m_reflection.Sets[i].Bindings[j].EntryType,
                        p_stages = m_reflection.Sets[i].Bindings[j].ShaderStage,
                        p_mode = m_reflection.Sets[i].Bindings[j].EntryMode,
                    };
                }

                sets[i] = new()
                {
                    p_pushSet = false, 
                    p_entries = entries,
                };
            }

            m_layout = i_device.CreateLayout(new()
            {
                p_next = null,
                p_label = i_createParams.p_label,
                p_pushConstant = push,
                p_sets = sets, 
            });

            m_shaderLink = i_device.CreateShaderLink(new()
            {
                p_next = null,
                p_label = i_createParams.p_label,
                p_layout = m_layout,
                p_stages = i_createParams.p_stages, 
            });

            m_id = ResId.GetNextId();
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);

                foreach (var state in m_sets.Values)
                {
                    state.Set?.Dispose();
                }

                m_layout.Dispose();
                m_shaderLink.Dispose();
            }
        }

        public void Bind(CommonEncoder i_encoder, SmartShaderLinkParams i_params)
        {
            // Bind shader link.
            i_encoder.CmdBindShaderLink(m_shaderLink);

            // Reset auxiliar arrays.
            m_resources.Clear();
            fixed (SetFingerprint* fingerprintsPtr = m_fingerprints)
            {
                NativeMemory.Clear(fingerprintsPtr, (nuint)(sizeof(SetFingerprint) * ApiGlobalLimits.MAX_SETS_PER_PIPELINE));
            }

            // Take fingerprints.
            TakeFingerprints(i_params, m_fingerprints, m_resources);

            for (int setNumber = 0; setNumber < ApiGlobalLimits.MAX_SETS_PER_PIPELINE; setNumber++)
            {
                ref SetFingerprint setFingerprint = ref m_fingerprints[setNumber];

                if (setFingerprint.p_used == 0) continue;

                // Get or create set state.
                if (!m_sets.TryGetValue(setFingerprint, out SetState? state))
                {
                    state = new();
                    m_sets.Add(setFingerprint, state);

                    Console.WriteLine($"Creating set with fingerprint: {setFingerprint.GetHashCode()}"); // DEBUG
                }

                state.DestructionDelay = SET_DESTROY_DELAY;

                // Create set.
                if (state.Set == null)
                {
                    SetReflection? setReflection = m_reflection.GetSet((uint)setNumber);
                    if (setReflection == null)
                    {
                        throw new Exception($"Set {setNumber} not found.");
                    }

                    int bindingArrayIdx = 0;
                    SetEntryBinding[] bindings = new SetEntryBinding[setFingerprint.p_bindingCount];

                    for (int bindingFingerprintIdx = 0; bindingFingerprintIdx < setFingerprint.p_bindingCount; bindingFingerprintIdx++)
                    {
                        // Get binding location.
                        int location = setFingerprint.p_bindingLocations[bindingFingerprintIdx];

                        // Get binding fingerprint.
                        // Location (actual location of the binding in the shader) == index in bindings array.
                        ref SetBindingFingerprint bindingFingerprint = ref setFingerprint.p_bindings[location];

                        SetBindingReflection? bindingReflection = setReflection.GetBinding((uint)location);
                        if (bindingReflection == null)
                        {
                            throw new Exception($"Binding {location} not found.");
                        }

                        BufferBindingDescription? bufferBinding = null;
                        TextureBindingDescription? textureBinding = null;
                        if (bindingReflection.EntryType == EntryType.UniformBuffer || 
                            bindingReflection.EntryType == EntryType.StorageBuffer)
                        {
                            bufferBinding = new()
                            {
                                p_buffer = (Buffer)m_resources[bindingFingerprint.p_resourceIndex],  
                                p_offset = bindingFingerprint.p_bufferOffset,
                                p_range = bindingFingerprint.p_bufferRange,
                            };
                        }
                        else if (bindingReflection.EntryType == EntryType.Texture)
                        {
                            textureBinding = new()
                            {
                                p_sampler = null,
                                p_textureView = (TextureView)m_resources[bindingFingerprint.p_resourceIndex],
                            };
                        }
                        else if (bindingReflection.EntryType == EntryType.Sampler)
                        {
                            textureBinding = new()
                            {
                                p_sampler = (Sampler)m_resources[bindingFingerprint.p_resourceIndex],
                                p_textureView = null,
                            };
                        }
                        else
                        {
                            throw new Exception($"Entry type {bindingReflection.EntryType} not supported.");
                        }

                        bindings[bindingArrayIdx] = new()
                        {
                            p_next = null,
                            p_binding = bindingReflection.BindingNumber,
                            p_type = bindingReflection.EntryType,
                            p_bufferBinding = bufferBinding,
                            p_textureBinding = textureBinding,
                        };

                        bindingArrayIdx++;
                    }

                    state.Set = m_layout.CreateSet(new()
                    {
                        p_next = null,
                        p_label = "SmartShaderLink Set", 
                        // TODO: Implement a more robust way of handling this. We assume all sets from 0 to N are used.
                        //       The main problem is how the Set handles finding its layout in the Layout class.
                        p_setLayoutIdx = (uint)setNumber, 
                        p_bindings = bindings,
                    });

                    Console.WriteLine($"Created set with fingerprint: {setFingerprint.GetHashCode()}"); // DEBUG
                }
            
                // Update set state to reflect set usage.
                // Add 1 (ONE) to the signal value to wait to the next CommandList iteration.
                ulong ONE = 1UL;
                if (state.TakenCommandLists.ContainsKey(i_encoder.Owner.Id))
                {
                    // Register the signal value to know when the set is no longer in use.
                    state.TakenTimestamps[i_encoder.Owner.Id] = i_encoder.Owner.SignalValue + ONE;
                }
                else
                {
                    state.TakenCommandLists.Add(i_encoder.Owner.Id, i_encoder.Owner);
                    state.TakenTimestamps.Add(i_encoder.Owner.Id, i_encoder.Owner.SignalValue + ONE);
                }

                i_encoder.CmdBindSets((uint)setNumber, [state.Set]);
            }

            // Check sets usage state.
            m_commandListsToRemove.Clear();
            foreach (var stateTuple in m_sets)
            {
                SetState state = stateTuple.Value;
                if (state.TakenCommandLists.Count > 0)
                {
                    m_commandListsToRemove.Clear();
                    foreach (var commandListTuple in state.TakenCommandLists)
                    {
                        if (commandListTuple.Value.IsDisposed ||
                            commandListTuple.Value.SignalValue > state.TakenTimestamps[commandListTuple.Key])
                        {
                            m_commandListsToRemove.Add(commandListTuple.Key);
                        }
                    }

                    foreach (ResId commandListId in m_commandListsToRemove)
                    {
                        state.TakenCommandLists.Remove(commandListId);
                        state.TakenTimestamps.Remove(commandListId);
                    }
                }
            }

            // Destroy sets that are no longer in use.
            m_setsToRemove.Clear();
            foreach (var stateTuple in m_sets)
            {
                SetState state = stateTuple.Value;
                
                if (state.TakenCommandLists.Count == 0)
                {
                    state.DestructionDelay--;

                    if (state.DestructionDelay == 0)
                    {
                        m_setsToRemove.Add(stateTuple.Key);
                    }
                }
            }

            foreach (SetFingerprint setFingerprint in m_setsToRemove)
            {
                if (m_sets.Remove(setFingerprint, out SetState? state))
                {
                    state.Set?.Dispose();
                    Console.WriteLine($"Destroyed set with fingerprint: {setFingerprint.GetHashCode()}"); // DEBUG
                }
            }
        }

        internal ShaderLink ShaderLink => m_shaderLink;

        private const int SET_DESTROY_DELAY = 512;

        private bool m_isDisposed = false;
        private readonly ResId m_id;
        private readonly ShadersReflection m_reflection;
        private readonly Layout m_layout;
        private readonly ShaderLink m_shaderLink;

        private readonly Dictionary<SetFingerprint, SetState> m_sets = [];

        // To reduce GC pressure we store the fingerprint array and reset it each time we use it.
        private readonly SetFingerprint[] m_fingerprints = new SetFingerprint[ApiGlobalLimits.MAX_SETS_PER_PIPELINE];
        // We do the same with other lists.
        private readonly List<object> m_resources = [];
        private readonly List<ResId> m_commandListsToRemove = [];
        private readonly List<SetFingerprint> m_setsToRemove = [];

        private void TakeFingerprints(SmartShaderLinkParams i_params, SetFingerprint[] i_fingerprints, List<object> i_resources)
        {
            for (int i = 0; i < i_params.p_params.Length; i++)
            {
                ref SmartShaderLinkParam param = ref i_params.p_params[i];
                SetBindingReflection? bindingReflection = m_reflection.GetBinding(param.p_name);

                if (bindingReflection == null)
                {
                    throw new Exception($"Binding '{param.p_name}' not found.");
                }

                if (param.p_textureBindingDescription != null && 
                    (bindingReflection.EntryType == EntryType.StorageBuffer ||
                     bindingReflection.EntryType == EntryType.UniformBuffer))
                {
                    throw new Exception($"Binding '{param.p_name}' is not a texture.");
                }

                if (param.p_bufferBindingDescription != null && 
                    (bindingReflection.EntryType == EntryType.Texture ||
                     bindingReflection.EntryType == EntryType.Sampler))
                {
                    throw new Exception($"Binding '{param.p_name}' is not a buffer.");
                }

                ref SetFingerprint setFingerprint = ref i_fingerprints[bindingReflection.SetNumber];
                setFingerprint.p_used = 1;

                setFingerprint.p_bindingLocations[setFingerprint.p_bindingCount] = (int)bindingReflection.BindingNumber;
                setFingerprint.p_bindingCount++;

                ref SetBindingFingerprint bindingFingerprint = ref setFingerprint.p_bindings[(int)bindingReflection.BindingNumber];

                if (bindingFingerprint.p_used == 1)
                {
                    throw new Exception($"Binding '{param.p_name}' was already assigned.");
                }

                bindingFingerprint.p_used = 1;
                bindingFingerprint.p_bindingNumber = (int)bindingReflection.BindingNumber;
                bindingFingerprint.p_resourceIndex = i_resources.Count;

                if (param.p_bufferBindingDescription.HasValue)
                {
                    if (param.p_bufferBindingDescription.Value.p_buffer == null)
                    {
                        throw new Exception($"Buffer cannot be null.");
                    }
                    
                    bindingFingerprint.p_resourceHash = param.p_bufferBindingDescription.Value.p_buffer.GetHashCode();
                    bindingFingerprint.p_bufferOffset = param.p_bufferBindingDescription.Value.p_offset;
                    bindingFingerprint.p_bufferRange = param.p_bufferBindingDescription.Value.p_range;

                    // Add resource to the list.
                    i_resources.Add(param.p_bufferBindingDescription.Value.p_buffer);
                }
                else if (param.p_textureBindingDescription.HasValue)
                {
                    if (param.p_textureBindingDescription.Value.p_textureView != null)
                    {
                        bindingFingerprint.p_resourceHash = param.p_textureBindingDescription.Value.p_textureView.GetHashCode();

                        // Add resource to the list.
                        i_resources.Add(param.p_textureBindingDescription.Value.p_textureView);
                    }
                    else if (param.p_textureBindingDescription.Value.p_sampler != null)
                    {
                        bindingFingerprint.p_resourceHash = param.p_textureBindingDescription.Value.p_sampler.GetHashCode();

                        // Add resource to the list.
                        i_resources.Add(param.p_textureBindingDescription.Value.p_sampler);
                    }
                    else
                    {
                        throw new Exception($"Texture view or sampler cannot be null.");
                    }
                }
            }
        }
    }
}
