
using Massini.Core.IO.InputRouting.Enums;

namespace Massini.Core.IO.InputRouting.State
{
    public abstract class Keyboard
    {
        /// <summary>
        /// Returns true if the key was pressed.
        /// </summary>
        /// <param name="i_keyboard"></param>
        /// <param name="i_key"></param>
        /// <returns></returns>
        public bool IsKeyPressed(KeyboardId i_keyboard, KeyboardKey i_key)
        {
            KeyboardKeyState state = GetKeyState(i_keyboard, i_key);
            return state.Begin;
        }

        /// <summary>
        /// Returns true if the key was released.
        /// </summary>
        /// <param name="i_keyboard"></param>
        /// <param name="i_key"></param>
        /// <returns></returns>
        public bool IsKeyReleased(KeyboardId i_keyboard, KeyboardKey i_key)
        {
            KeyboardKeyState state = GetKeyState(i_keyboard, i_key);
            return state.End;
        }

        /// <summary>
        /// Returns true if the key is held down.
        /// </summary>
        /// <param name="i_keyboard"></param>
        /// <param name="i_key"></param>
        /// <returns></returns>
        public bool IsKeyDown(KeyboardId i_keyboard, KeyboardKey i_key)
        {
            KeyboardKeyState state = GetKeyState(i_keyboard, i_key);
            return state.State != 0.0;
        }

        public KeyboardKeyState GetKeyState(KeyboardId i_keyboard, KeyboardKey i_key)
        {
            if (!KeysData.TryGetValue((i_keyboard, i_key), out var state))
            {
                state = new KeyboardKeyState();
                KeysData.Add((i_keyboard, i_key), state);
            }
            return state;
        }

        internal Dictionary<(KeyboardId Keyboard, KeyboardKey Key), KeyboardKeyState> KeysData { get; private set; } = [];
    }
}
