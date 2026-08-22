
using Massini.Core.Collections;
using Massini.Core.IO.InputRouting.Enums;
using Massini.Core.Math.Primitives;

namespace Massini.Core.IO.InputRouting.State
{
    /// <summary>
    /// Stores all the meaningful data related to an action event.
    /// </summary>
    public sealed class ActionEventInfo : IResettable
    {
        /// <summary>
        /// The name of the action event.
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// The tags of the action event.
        /// </summary>
        public List<string> Tags { get; internal set; } = [];
        /// <summary>
        /// Stores the action scalar value.
        /// </summary>
        public double Scalar { get; internal set; }
        /// <summary>
        /// Stores the action vector value.
        /// </summary>
        public Vec2<double> Vec2 { get; internal set; }
        /// <summary>
        /// Stores the action vector value.
        /// </summary>
        public Vec3<double> Vec3 { get; internal set; }
        /// <summary>
        /// Stores the action vector value.
        /// </summary>
        public Vec4<double> Vec4 { get; internal set; }
        /// <summary>
        /// Time at which the action event occurred.
        /// </summary>
        public TimeSpan Timestamp { get; internal set; }
        /// <summary>
        /// True if the action started.
        /// </summary>
        public bool Begin { get; internal set; }
        /// <summary>
        /// True if the action ended.
        /// </summary>
        public bool End { get; internal set; }
        /// <summary>
        /// The inputs that triggered the action event.
        /// </summary>
        public InputTrigger ActionTriggers { get; internal set; }

        /// <summary>
        /// Returns true if the action event has the specified tag.
        /// </summary>
        /// <param name="i_name"></param>
        /// <returns></returns>
        public bool Is(string i_name) => Name == i_name;

        public void TryReset()
        {
            Name = string.Empty;
            Tags.Clear();
            Scalar = 0.0;
            Vec2 = Vec2<double>.Zero;
            Vec3 = Vec3<double>.Zero;
            Vec4 = Vec4<double>.Zero;
            Timestamp = TimeSpan.Zero;
            Begin = false;
            End = false;
            ActionTriggers = InputTrigger.None;
        }
    }
}
