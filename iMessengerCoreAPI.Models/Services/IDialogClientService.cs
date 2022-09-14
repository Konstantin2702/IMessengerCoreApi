using iMessengerCoreAPI.Models.Data;

namespace iMessengerCoreAPI.Models.Services
{
    public interface IDialogClientService
    {
        public Guid GetDialogs(List<Guid> IDClients, RGDialogDbContext db);
    }
}
