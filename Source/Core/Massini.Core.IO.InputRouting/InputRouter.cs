
using Massini.Core.Collections;
using Massini.Core.IO.InputRouting.Emitters;
using Massini.Core.IO.InputRouting.State;
using System.Diagnostics.CodeAnalysis;

namespace Massini.Core.IO.InputRouting
{
    public delegate void OnActionCallback(ActionEventInfo i_eventInfo);

    public abstract class InputRouter
    {
        /// <summary>
        /// Called when an action is triggered.
        /// </summary>
        public event OnActionCallback? OnAction = null;

        /// <summary>
        /// Get access to all the mouse related data.
        /// </summary>
        public abstract Mouse Mouse { get; }

        /// <summary>
        /// Get access to all the keyboard related data.
        /// </summary>
        public abstract Keyboard Keyboard { get; }

        /// <summary>
        /// Get access to all the gamepad related data.
        /// </summary>
        public abstract Gamepad Gamepad { get; }

        /// <summary>
        /// Add a new action.
        /// </summary>
        /// <param name="i_tag"></param>
        /// <param name="i_inputEmitter"></param>
        public void AddAction(string i_tag, InputEmitter i_inputEmitter)
        {
            m_inputEmitters.Add(i_tag, i_inputEmitter);
        }

        /// <summary>
        /// Remove an action.
        /// </summary>
        /// <param name="i_tag"></param>
        /// <returns></returns>
        public bool RemoveAction(string i_tag)
        {
            return m_inputEmitters.Remove(i_tag);
        }

        /// <summary>
        /// Get an action info.
        /// </summary>
        /// <param name="i_tag"></param>
        /// <param name="i_eventInfo"></param>
        /// <returns>True if the action was triggered.</returns>
        public bool GetAction(string i_tag, [NotNullWhen(true)] out ActionEventInfo? i_eventInfo)
        {
            return m_lastActionEvents.TryGetValue(i_tag, out i_eventInfo);
        }

        /// <summary>
        /// Returns the number of keyboards supported.
        /// </summary>
        /// <remarks>
        /// In some backends it means the number of connected keyboards. In other, the maximum number of supported keyboards.
        /// </remarks>
        /// <returns></returns>
        public abstract int GetKeyboardCount();

        /// <summary>
        /// Checks if a keyboard is available.
        /// </summary>
        /// <param name="i_keyboard"></param>
        /// <returns></returns>
        public abstract bool IsKeyboardAvailable(KeyboardId i_keyboard);

        /// <summary>
        /// Call this after all inputs have been updated.
        /// </summary>
        /// <param name="i_totalTime"></param>
        protected void ProcessActions(TimeSpan i_totalTime)
        {
            // Clear last action events and return them to the pool.
            foreach (ActionEventInfo actionEventInfo in m_lastActionEvents.Values)
            {
                m_eventInfoPool.Return(actionEventInfo);
            }
            m_lastActionEvents.Clear();

            foreach (var inputEmitter in m_inputEmitters)
            {
                if (inputEmitter.Value.Disable) continue;

                var eventInfo = m_eventInfoPool.Borrow();
                eventInfo.Name = inputEmitter.Key;
                eventInfo.Tags = inputEmitter.Value.Tags;

                if (inputEmitter.Value.Evaluate(i_totalTime, (Mouse, Keyboard, Gamepad), ref eventInfo))
                {
                    OnAction?.Invoke(eventInfo);
                    m_lastActionEvents[inputEmitter.Key] = eventInfo;
                }
            }
        }

        private readonly ObjectPool<ActionEventInfo> m_eventInfoPool = new(() => new ActionEventInfo());
        private readonly Dictionary<string, InputEmitter> m_inputEmitters = [];
        private readonly Dictionary<string, ActionEventInfo> m_lastActionEvents = [];
    }
}
