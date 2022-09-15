using iMessengerCoreAPI.Models.Data;
using iMessengerCoreAPI.Models.Models;
using iMessengerCoreAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace iMessengerCoreAPI.Models.Controllers
{
   
    public class RGDialogController : ControllerBase
    {
        private readonly IDialogClientService _service;
        private readonly RGDialogDbContext _db;

        public RGDialogController( IDialogClientService service, RGDialogDbContext db)        
        {
            _service = service;
            _db = db;
        }
        [HttpGet("/api/dialogsDb")]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult GetFromDB(List<Guid> IDClients)
        {
            RGDialogClientCollection rGDialogClientCollection = new();
            rGDialogClientCollection.RGDialogsClients = RGDialogsClients.Init();
            return Ok(_service.GetDialogsFromDB(IDClients, _db));
        }
        [HttpGet("/api/dialogsCollection")]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult GetFromCollection(List<Guid> IDClients)
        {
            RGDialogClientCollection rGDialogClientCollection = new();
            rGDialogClientCollection.RGDialogsClients = RGDialogsClients.Init();           
            return Ok(_service.GetDialogsFromCollection(IDClients, rGDialogClientCollection));
        }
    }
}
