using DTO;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using muisvergelijker.Models;

namespace muisvergelijker.Controllers
{
    [ApiController]
    [Route("/mod")]
    public class ModController : Controller
    {
        private IModLogic _modLogic;
        public ModController(IModLogic modLogic)
        {
            _modLogic = modLogic;
        }

        [HttpGet]
        public IEnumerable<MouseMod> GetAll()
        {
            return _modLogic.GetAll();
        }

        [HttpPost]
        public void AddMouse(ModRequest mod)
        {
            _modLogic.AddMod(mod.Basemouse, mod.Weight, mod.Comments);
        }


    }
}
