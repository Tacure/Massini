namespace Massini.Collections
{
    public interface IResettable
    {
        /// <summary>
        /// Tries to reset the state of the object as if it was just created.
        /// </summary>
        public void TryReset();
    }
}
