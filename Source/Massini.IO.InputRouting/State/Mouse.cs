
using Massini.IO.InputRouting.Enums;
using Massini.Math.Primitives;

namespace Massini.IO.InputRouting.State
{
    public abstract class Mouse
    {
        /// <summary>
        /// Returns true if the mouse button was pressed.
        /// </summary>
        /// <param name="i_mouse"></param>
        /// <param name="i_button"></param>
        /// <returns></returns>
        public bool IsButtonPressed(MouseId i_mouse, MouseButton i_button)
        {
            MouseButtonState state = GetButtonState(i_mouse, i_button);
            return state.Begin;
        }

        /// <summary>
        /// Returns true if the mouse button was released.
        /// </summary>
        /// <param name="i_mouse"></param>
        /// <param name="i_button"></param>
        /// <returns></returns>
        public bool IsButtonReleased(MouseId i_mouse, MouseButton i_button)
        {
            MouseButtonState state = GetButtonState(i_mouse, i_button);
            return state.End;
        }

        /// <summary>
        /// Returns true if the mouse button is held down.
        /// </summary>
        /// <param name="i_mouse"></param>
        /// <param name="i_button"></param>
        /// <returns></returns>
        public bool IsButtonDown(MouseId i_mouse, MouseButton i_button)
        {
            MouseButtonState state = GetButtonState(i_mouse, i_button);
            return state.State != 0.0;
        }

        /// <summary>
        /// Returns the mouse position delta since the last update.
        /// </summary>
        /// <param name="i_mouse"></param>
        /// <returns></returns>
        public Vec2<double> GetPositionDelta(MouseId i_mouse) 
        {
            MouseMotionState stateX = GetMotionState(i_mouse, MouseMotion.DeltaX);
            MouseMotionState stateY = GetMotionState(i_mouse, MouseMotion.DeltaY);
            return new Vec2<double>(stateX.State, stateY.State);
        }

        /// <summary>
        /// Returns the mouse position.
        /// </summary>
        /// <param name="i_mouse"></param>
        /// <returns></returns>
        public Vec2<double> GetPosition(MouseId i_mouse) 
        {
            MouseMotionState stateX = GetMotionState(i_mouse, MouseMotion.PositionX);
            MouseMotionState stateY = GetMotionState(i_mouse, MouseMotion.PositionY);
            return new Vec2<double>(stateX.State, stateY.State);
        }

        public MouseButtonState GetButtonState(MouseId i_mouse, MouseButton i_button)
        {
            if (!MouseButtonsData.TryGetValue((i_mouse, i_button), out var state))
            {
                state = new MouseButtonState();
                MouseButtonsData.Add((i_mouse, i_button), state);
            }
            return state;
        }

        public MouseMotionState GetMotionState(MouseId i_mouse, MouseMotion i_motion)
        {
            if (!MouseMotionData.TryGetValue((i_mouse, i_motion), out var state))
            {
                state = new MouseMotionState();
                MouseMotionData.Add((i_mouse, i_motion), state);
            }
            return state;
        }

        internal Dictionary<(MouseId Mouse, MouseButton Button), MouseButtonState> MouseButtonsData { get; private set; } = [];
        internal Dictionary<(MouseId Mouse, MouseMotion Motion), MouseMotionState> MouseMotionData { get; private set; } = [];
    }
}
