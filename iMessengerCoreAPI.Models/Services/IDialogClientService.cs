using iMessengerCoreAPI.Models.Data;

namespace iMessengerCoreAPI.Models.Services
{
    public interface IDialogClientService
    {
        public Guid GetDialogsFromDB(List<Guid> IDClients, RGDialogDbContext db);
        public Guid GetDialogsFromCollection(List<Guid> IDClients, RGDialogClientCollection dialogClients);
    }
}
