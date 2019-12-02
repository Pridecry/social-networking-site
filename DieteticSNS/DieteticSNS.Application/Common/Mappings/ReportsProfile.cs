using AutoMapper;
using DieteticSNS.Application.Models.Reports.Commands.CreateCommentReport;
using DieteticSNS.Application.Models.Reports.Commands.CreatePostReport;
using DieteticSNS.Domain.Entities;

namespace DieteticSNS.Application.Common.Mappings
{
    public class ReportsProfile : Profile
    {
        public ReportsProfile()
        {
            CreateMap<CreatePostReportCommand, PostReport>();
            CreateMap<CreateCommentReportCommand, CommentReport>();
        }
    }
}
