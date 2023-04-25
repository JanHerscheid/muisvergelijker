using DTO;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public void AddMouse(int basemouse, int weight, string comments)
        {
            _modLogic.AddMod(basemouse, weight, comments);
        }


    }
}
