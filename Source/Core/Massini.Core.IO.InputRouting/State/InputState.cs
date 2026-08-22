
namespace Massini.Core.IO.InputRouting.State
{
    public class InputState
    {
        public TimeSpan Timestamp { get; private set; }
        public double State { get; private set; }

        protected void SetState(double i_state, TimeSpan i_timestamp)
        {
            State = i_state;
            Timestamp = i_timestamp;
        }
    }
}
