
using Massini.IO.InputRouting.Enums;
using Massini.IO.InputRouting.State;
using Massini.Math.Primitives;

namespace Massini.IO.InputRouting.Emitters
{
    /// <summary>
    /// A basic input emitter.
    /// Useful for most input needs.
    /// </summary>
    public sealed class InputEmitter
    {
        /// <summary>
        /// Additional tags used to identify the input emitter.
        /// </summary>
        public List<string> Tags { get; set; } = [];
        public List<InputBinding> Bindings { get; set; } = [];
        /// <summary>
        /// Enables or disables the input emitter.
        /// </summary>
        public bool Disable { get; set; } = false;
        /// <summary>
        /// Output target.
        /// </summary>
        public EmitterResult Result { get; set; } = EmitterResult.Scalar;
        /// <summary>
        /// Controls how two inputs are mixed.
        /// </summary>
        public Func<double, double, double>? MixFunction { get; set; } = null;
        public Func<double, double>? PostProcessFunctionScalar { get; set; } = null;
        public Func<Vec2<double>, Vec2<double>>? PostProcessFunctionVec2 { get; set; } = null;
        public Func<Vec3<double>, Vec3<double>>? PostProcessFunctionVec3 { get; set; } = null;
        public Func<Vec4<double>, Vec4<double>>? PostProcessFunctionVec4 { get; set; } = null;

        public bool Evaluate(TimeSpan i_totalTime, (Mouse Mice, Keyboard Keyboards, Gamepad Gamepads) i_inputs, ref ActionEventInfo i_ref_info)
        {
            bool begin = false, end = false;
            bool notZeroState = false;
            InputTrigger triggers = InputTrigger.None;

            foreach (var inputBinding in Bindings)
            {
                BlockResult blockResult = inputBinding.Block.Evaluate(i_inputs);

                double state = blockResult.State;
                triggers |= blockResult.Triggers;

                if (state != 0.0)
                {
                    notZeroState = true;
                }

                // Invert input.
                state = inputBinding.Invert ? -state : state;

                // Scalar target.
                if (Result is EmitterResult.Scalar)
                {
                    i_ref_info.Scalar = MixFunction?.Invoke(state, i_ref_info.Scalar) ?? state;
                }
                // Vector targets.
                else if (Result is EmitterResult.Vector2)
                {
                    Vec2<double> vec2 = i_ref_info.Vec2;
                    vec2[(int)inputBinding.Target] = MixFunction?.Invoke(state, i_ref_info.Vec2[(int)inputBinding.Target]) ?? state;
                    i_ref_info.Vec2 = vec2;
                }
                else if (Result is EmitterResult.Vector3)
                {
                    Vec3<double> vec3 = i_ref_info.Vec3;
                    vec3[(int)inputBinding.Target] = MixFunction?.Invoke(state, i_ref_info.Vec3[(int)inputBinding.Target]) ?? state;
                    i_ref_info.Vec3 = vec3;
                }
                else if (Result is EmitterResult.Vector4)
                {
                    Vec4<double> vec4 = i_ref_info.Vec4;
                    vec4[(int)inputBinding.Target] = MixFunction?.Invoke(state, i_ref_info.Vec4[(int)inputBinding.Target]) ?? state;
                    i_ref_info.Vec4 = vec4;
                }
            }

            // Post process function.
            switch (Result)
            {
                case EmitterResult.Scalar:
                    i_ref_info.Scalar = PostProcessFunctionScalar?.Invoke(i_ref_info.Scalar) ?? i_ref_info.Scalar;
                    break;
                case EmitterResult.Vector2:
                    i_ref_info.Vec2 = PostProcessFunctionVec2?.Invoke(i_ref_info.Vec2) ?? i_ref_info.Vec2;
                    break;
                case EmitterResult.Vector3:
                    i_ref_info.Vec3 = PostProcessFunctionVec3?.Invoke(i_ref_info.Vec3) ?? i_ref_info.Vec3;
                    break;
                case EmitterResult.Vector4:
                    i_ref_info.Vec4 = PostProcessFunctionVec4?.Invoke(i_ref_info.Vec4) ?? i_ref_info.Vec4;
                    break;
                default:
                    break;
            }

            if (m_oldNotZeroState && notZeroState is false)
            {
                end = true;
            }
            else if (m_oldNotZeroState is false && notZeroState)
            {
                begin = true;
            }
            else 
            {
                begin = false;
                end = false;
            }
            m_oldNotZeroState = notZeroState;

            if (begin && end)
            {
                begin = false;
                end = false;
            }

            i_ref_info.Begin = begin;
            i_ref_info.End = end;
            i_ref_info.Timestamp = i_totalTime;
            i_ref_info.ActionTriggers = triggers;

            return notZeroState || begin || end;
        }

        private bool m_oldNotZeroState = false;
    }
}
