using System.Threading.Tasks;

namespace DieteticSNS.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendMessage(int userId, string message);
    }
}
