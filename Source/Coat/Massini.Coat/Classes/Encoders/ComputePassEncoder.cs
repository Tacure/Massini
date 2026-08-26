using Massini.Coat.Classes.Commands;
using Massini.Coat.Structs.Level1;

namespace Massini.Coat.Classes.Encoders
{
    public sealed class ComputePassEncoder : CommonEncoder
    {
        public void CmdDispatch(uint i_numGroupsX, uint i_numGroupsY, uint i_numGroupsZ)
        {
            Push<CmdDispatch>(cmd => { cmd.p_numGroupsX = i_numGroupsX; cmd.p_numGroupsY = i_numGroupsY; cmd.p_numGroupsZ = i_numGroupsZ; });
        }
    }
}
