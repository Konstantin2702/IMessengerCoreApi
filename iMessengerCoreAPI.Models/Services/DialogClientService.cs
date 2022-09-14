using iMessengerCoreAPI.Models.Data;
using iMessengerCoreAPI.Models.Models;

namespace iMessengerCoreAPI.Models.Services
{
    public class DialogClientService: IDialogClientService
    {

        public Guid GetDialogs(List<Guid> IDClients, RGDialogDbContext db)
        {
            var res = db.RGDialogsClients.Select(
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
            return res;
          
        }
    }
}
