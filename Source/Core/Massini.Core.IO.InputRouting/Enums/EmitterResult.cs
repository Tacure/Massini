
namespace Massini.Core.IO.InputRouting.Enums
{
    public enum EmitterResult
    {
        /// <summary>
        /// Target output will be the <see cref="States.ActionEventInfo.Scalar"/> field.
        /// </summary>
        Scalar,
        /// <summary>
        /// Target output will be the <see cref="States.ActionEventInfo.Vec2"/> field.
        /// </summary>
        Vector2,
        /// <summary>
        /// Target output will be the <see cref="States.ActionEventInfo.Vec3"/> field.
        /// </summary>
        Vector3,
        /// <summary>
        /// Target output will be the <see cref="States.ActionEventInfo.Vec4"/> field.
        /// </summary>
        Vector4,
    }
}
