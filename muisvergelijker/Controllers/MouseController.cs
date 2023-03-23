using DTO;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace muisvergelijker.Controllers
{
    [ApiController]
    [Route("/mouse")]
    public class MouseController : Controller
    {
        private IMouseLogic _mouseLogic;
        public MouseController(IMouseLogic mouseLogic)
        {
            _mouseLogic = mouseLogic;
        }

        [HttpGet]
        public IEnumerable<Mouse> GetAll()
        {
            return _mouseLogic.GetAll();
        }

        [HttpPost]
        public void AddMouse(Mouse mouse) { 
            _mouseLogic.AddMouse(mouse);
        }
    }
}
