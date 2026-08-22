
namespace Massini.IO.InputRouting.Enums
{
    [Flags]
    public enum InputTrigger
    {
        None = 0,
        KeyboardKey = 1 << 0,
        MouseButton = 1 << 1,
        MouseMotion = 1 << 2,
        GamepadButton = 1 << 3,
        GamepadAxis = 1 << 4,
    }
}
