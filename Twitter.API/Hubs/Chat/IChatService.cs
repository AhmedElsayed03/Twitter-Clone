using Twitter.DAL.DomainModels;

namespace Twitter.API.Hubs.Chat
{
    public interface IChatService
    {
        Task Send(string message);
    }
}
