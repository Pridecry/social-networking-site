using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Users.Queries.GetMinifiedUserList
{
    public class MinifiedUserListVm
    {
        public IList<MinifiedUserDto> Users { get; set; } = new List<MinifiedUserDto>();
    }
}
