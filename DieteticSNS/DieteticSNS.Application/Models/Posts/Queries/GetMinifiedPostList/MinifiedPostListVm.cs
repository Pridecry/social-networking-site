using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Posts.Queries.GetMinifiedPostList
{
    public class MinifiedPostListVm
    {
        public IList<MinifiedPostDto> Posts { get; set; } = new List<MinifiedPostDto>();
    }
}
