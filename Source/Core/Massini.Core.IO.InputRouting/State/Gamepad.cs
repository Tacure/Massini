
using Massini.Core.IO.InputRouting.Enums;
using Massini.Core.Math.Primitives;

namespace Massini.Core.IO.InputRouting.State
{
    public abstract class Gamepad
    {
        /// <summary>
        /// Returns the left joystick position.
        /// </summary>
        /// <param name="i_gamepad"></param>
        /// <returns></returns>
        public Vec2<double> GetLeftJoystickPosition(GamepadId i_gamepad)
        {
            GamepadAxisState stateX = GetAxisState(i_gamepad, GamepadAxis.LeftStickX);
            GamepadAxisState stateY = GetAxisState(i_gamepad, GamepadAxis.LeftStickY);
            return new Vec2<double>(stateX.State, stateY.State);
        }

        /// <summary>
        /// Returns the right joystick position.
        /// </summary>
        /// <param name="i_gamepad"></param>
        /// <returns></returns>
        public Vec2<double> GetRightJoystickPosition(GamepadId i_gamepad)
        {
            GamepadAxisState stateX = GetAxisState(i_gamepad, GamepadAxis.RightStickX);
            GamepadAxisState stateY = GetAxisState(i_gamepad, GamepadAxis.RightStickY);
            return new Vec2<double>(stateX.State, stateY.State);
        }

        /// <summary>
        /// Sets the speed of the left (low frequency) and right (high frequency) motors.
        /// </summary>
        /// <param name="i_gamepad"></param>
        /// <param name="i_left"></param>
        /// <param name="i_right"></param>
        /// <returns>True if the vibration was set.</returns>
        public abstract bool SetVibration(GamepadId i_gamepad, double i_left, double i_right);

        public GamepadAxisState GetAxisState(GamepadId i_gamepad, GamepadAxis i_axis)
        {
            if (!GamepadAxisData.TryGetValue((i_gamepad, i_axis), out var state))
            {
                state = new GamepadAxisState();
                GamepadAxisData.Add((i_gamepad, i_axis), state);
            }
            return state;
        }

        public GamepadButtonState GetButtonState(GamepadId i_gamepad, GamepadButton i_button)
        {
            if (!GamepadButtonsData.TryGetValue((i_gamepad, i_button), out var state))
            {
                state = new GamepadButtonState();
                GamepadButtonsData.Add((i_gamepad, i_button), state);
            }
            return state;
        }

        internal Dictionary<(GamepadId Gamepad, GamepadAxis Axis), GamepadAxisState> GamepadAxisData { get; private set; } = [];
        internal Dictionary<(GamepadId Gamepad, GamepadButton Button), GamepadButtonState> GamepadButtonsData { get; private set; } = [];
    }
}
