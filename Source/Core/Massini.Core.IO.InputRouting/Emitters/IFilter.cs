
namespace Massini.Core.IO.InputRouting.Emitters
{
    /// <summary>
    /// An <see cref="IFilter"/> can be used to filter a raw input data from a device. For example, it can be used to lower the sensitivity of a joystick.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Returns the filtered value.
        /// </summary>
        /// <param name="i_value"></param>
        /// <returns></returns>
        public double FilterValue(double i_value);
    }
}
