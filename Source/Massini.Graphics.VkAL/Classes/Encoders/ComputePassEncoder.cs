using Massini.Graphics.VkAL.Classes.Commands;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Encoders
{
    public sealed class ComputePassEncoder : CommonEncoder
    {
        public void CmdDispatch(uint i_numGroupsX, uint i_numGroupsY, uint i_numGroupsZ)
        {
            Push<CmdDispatch>(cmd => { cmd.p_numGroupsX = i_numGroupsX; cmd.p_numGroupsY = i_numGroupsY; cmd.p_numGroupsZ = i_numGroupsZ; });
        }
    }
}
