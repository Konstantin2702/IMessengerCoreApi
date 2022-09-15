using iMessengerCoreAPI.Models.Data;
using iMessengerCoreAPI.Models.Models;

namespace iMessengerCoreAPI.Models.Services
{
    public class DialogClientService: IDialogClientService
    {

        public Guid GetDialogsFromDB(List<Guid> IDClients, RGDialogDbContext db)
        {
            return db.RGDialogsClients.Select(
                     _ => new
                     {
                         dialog = _.IDRGDialog,
                         clientsCount = db.RGDialogsClients
                         .Where(d => d.IDRGDialog == _.IDRGDialog && IDClients.Contains(d.IDClient))
                         .Select(_ => _.IDClient).Count()
                     })
                     .ToHashSet()
                     .Where(_ => _.clientsCount == IDClients.Count && IDClients.Count > 0)
                     .Select(_ => _.dialog)
                     .FirstOrDefault();
          
          
        }

        public Guid GetDialogsFromCollection(List<Guid> IDClients, RGDialogClientCollection dialogClients)
        {
            return dialogClients.RGDialogsClients.Select(
                    _ => new
                    {
                        dialog = _.IDRGDialog,
                        clientsCount = dialogClients.RGDialogsClients
                        .Where(d => d.IDRGDialog == _.IDRGDialog && IDClients.Contains(d.IDClient))
                        .Select(_ => _.IDClient).Count()
                    })
                    .ToHashSet()
                    .Where(_ => _.clientsCount == IDClients.Count && IDClients.Count > 0)
                    .Select(_ => _.dialog)
                    .FirstOrDefault();
        }
    }
}
