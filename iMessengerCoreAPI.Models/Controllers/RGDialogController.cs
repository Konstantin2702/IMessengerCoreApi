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
        [HttpGet("/api/dialogs")]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult GetDialog(List<Guid> IDClients)
        {
           // _db.AddRange(RGDialogsClients.Init());
           // _db.SaveChanges();
            return Ok(_service.GetDialogs(IDClients, _db));
        }
    }
}
