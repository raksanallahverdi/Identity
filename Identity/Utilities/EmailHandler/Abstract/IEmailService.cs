using Identity.Utilities.EmailHandler.Models;

namespace Identity.Utilities.EmailHandler.Abstract
{
    public interface IEmailService
    {
        public void SendMessage(Message message);
    }
}
