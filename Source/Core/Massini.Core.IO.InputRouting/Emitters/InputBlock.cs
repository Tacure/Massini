
using Massini.IO.InputRouting.Enums;
using Massini.IO.InputRouting.State;
using Massini.Math;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Massini.IO.InputRouting.Emitters
{
    /// <summary>
    /// Provides input.
    /// </summary>
    public class InputBlock : IEvalBlock
    {
        public required InputTrigger Trigger { get; set; } = InputTrigger.None;
        public (KeyboardId Keyboard, KeyboardKey Key) KeyboardKey { get; set; } = (-1, Enums.KeyboardKey.Default);
        public (GamepadId Gamepad, GamepadButton Button) GamepadButton { get; set; } = (-1, Enums.GamepadButton.Default);
        public (GamepadId Gamepad, GamepadAxis ButtonAxis) GamepadAxis { get; set; } = (-1, Enums.GamepadAxis.Default);
        public (MouseId Mouse, MouseButton Button) MouseButton { get; set; } = (-1, Enums.MouseButton.Default);
        public (MouseId Mouse, MouseMotion Motion) MouseMotion { get; set; } = (-1, Enums.MouseMotion.Default);
        public IFilter? InputFilter { get; set; } = null;
        /// <summary>
        /// If true, the input is inverted (multiplied by -1).
        /// </summary>
        public bool Invert { get; set; } = false;

        public BlockResult Evaluate((Mouse Mice, Keyboard Keyboards, Gamepad Gamepads) i_inputs)
        {
            double state = 0.0;
            InputTrigger triggers = InputTrigger.None;

            if (Trigger == InputTrigger.KeyboardKey)
            {
                if (i_inputs.Keyboards.KeysData.TryGetValue(KeyboardKey, out var keyState))
                {
                    state = keyState.State;

                    if (state != 0.0)
                    {
                        triggers = InputTrigger.KeyboardKey;
                    }
                }
            }
            else if (Trigger == InputTrigger.MouseButton)
            {
                if (i_inputs.Mice.MouseButtonsData.TryGetValue(MouseButton, out var mouseButtonState))
                {
                    state = mouseButtonState.State;

                    if (state != 0.0)
                    {
                        triggers = InputTrigger.MouseButton;
                    }
                }
            }
            else if (Trigger == InputTrigger.MouseMotion)
            {
                if (i_inputs.Mice.MouseMotionData.TryGetValue(MouseMotion, out var mouseMotionState))
                {
                    state = InputFilter == null ?
                            mouseMotionState.State : InputFilter.FilterValue(mouseMotionState.State);

                    if (state != 0.0)
                    {
                        triggers = InputTrigger.MouseMotion;
                    }
                }
            }
            else if (Trigger == InputTrigger.GamepadButton)
            {
                if (i_inputs.Gamepads.GamepadButtonsData.TryGetValue(GamepadButton, out var gamepadButtonState))
                {
                    state = gamepadButtonState.State;

                    if (state != 0.0)
                    {
                        triggers = InputTrigger.GamepadButton;
                    }
                }
            }
            else if (Trigger == InputTrigger.GamepadAxis)
            {
                if (i_inputs.Gamepads.GamepadAxisData.TryGetValue(GamepadAxis, out var gamepadAxisState))
                {
                    state = InputFilter == null ?
                            gamepadAxisState.State : InputFilter.FilterValue(gamepadAxisState.State);

                    if (state != 0.0)
                    {
                        triggers = InputTrigger.GamepadAxis;
                    }
                }
            }
            else
            {
                throw new Exception("Unknown input event type");
            }

            state = Invert ? -state : state;

            return new()
            {
                State = state,
                Triggers = triggers,
            };
        }
    }
}
