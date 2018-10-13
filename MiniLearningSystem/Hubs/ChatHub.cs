using Microsoft.AspNet.SignalR;

namespace MiniLearningSystem.Web.Hubs
{
    public class ChatHub : Hub
    {
        public void GetMessage(string name, string message)
        {
            string identiy = Context.User.Identity.Name;

            Clients.All.recieveMessage(identiy, message);
        }
    }
}