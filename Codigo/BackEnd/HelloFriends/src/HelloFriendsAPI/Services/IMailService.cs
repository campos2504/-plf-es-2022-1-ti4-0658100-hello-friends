using System.Threading.Tasks;
using HelloFriendsAPI.Model;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
    

