using Massini.Graphics.VkAL.Classes.Commands;

namespace Massini.Graphics.VkAL.Classes.Encoders
{
    public abstract class CommandEncoder
    {
        /// <summary>
        /// The command list that, currently, owns this encoder.
        /// </summary>
        public CommandList Owner => m_owner!;

        /// <summary>
        /// Resets the encoder. Releases all commands and encoders held by the instance, returning them to their respective pools and
        /// clearing internal collections.
        /// </summary>
        /// <remarks>Call this method to reset the state of the instance and prepare it for reuse. After
        /// calling Reset, all previously held commands and encoders are no longer accessible from this
        /// instance.</remarks>
        public void Reset() 
        {
            foreach (var command in m_commands) 
            {
                m_commandPool.Return(command);
            }
            m_commands.Clear();
            foreach (var encoder in m_encoders) 
            {
                m_encoderPool.Return(encoder);
            }
            m_encoders.Clear();
        }

        /// <summary>
        /// Returns all recorded commands. Commands should not be modified, doing that results in undefined behavior.
        /// </summary>
        internal IReadOnlyList<Command> Commands => m_commands;

        internal void SetOwner(CommandList i_cmdList)
        {
            m_owner = i_cmdList;
        }

        /// <summary>
        /// Creates a command and stores it in the encoder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i_init"></param>
        internal void Push<T>(Action<T> i_init) 
            where T : Command, new()
        {
            var command = m_commandPool.Borrow<T>();
            i_init(command);
            m_commands.Add(command);
        }

        /// <summary>
        /// Creates a command and a encoder. Both are stored in the encoder while in use.
        /// </summary>
        /// <typeparam name="TEncoder"></typeparam>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="i_init"></param>
        /// <returns></returns>
        internal TEncoder PushWithEncoder<TEncoder, TCommand>(Action<TEncoder, TCommand> i_init) 
            where TCommand : Command, new() 
            where TEncoder : CommandEncoder, new()
        {
            var encoder = m_encoderPool.Borrow<TEncoder>();
            var command = m_commandPool.Borrow<TCommand>();
            i_init(encoder, command);
            m_commands.Add(command);
            m_encoders.Add(encoder);

            if (m_owner == null)
            {
                throw new InvalidOperationException("The encoder is not owned by a command list.");
            }
            
            encoder.SetOwner(m_owner);

            return encoder;
        }

        private CommandList? m_owner;
        private readonly List<Command> m_commands = [];
        private readonly List<CommandEncoder> m_encoders = [];
        private readonly CommandPool m_commandPool = new();
        private readonly EncoderPool m_encoderPool = new();
    }
}
