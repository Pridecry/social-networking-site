using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Users.Queries.GetSuggestedUserList
{
    public class SuggestedUserListVm
    {
        public IList<SuggestedUserDto> Users { get; set; } = new List<SuggestedUserDto>();
    }
}
