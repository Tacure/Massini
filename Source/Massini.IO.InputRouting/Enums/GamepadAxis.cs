namespace Massini.IO.InputRouting.Enums
{
    public enum GamepadAxis
    {
        Default,
        /// <summary>
        /// Gamepad left stick X axis.
        /// </summary>
        LeftStickX,
        /// <summary>
        /// Gamepad left stick Y axis.
        /// </summary>
        LeftStickY,
        /// <summary>
        /// Gamepad right stick X axis.
        /// </summary>
        RightStickX,
        /// <summary>
        /// Gamepad right stick Y axis.
        /// </summary>
        RightStickY,
        /// <summary>
        /// Gamepad back trigger left, pressure level: [1..-1].
        /// </summary>
        LeftTrigger,
        /// <summary>
        /// Gamepad back trigger right, pressure level: [1..-1].
        /// </summary>
        RightTrigger
    }
}
