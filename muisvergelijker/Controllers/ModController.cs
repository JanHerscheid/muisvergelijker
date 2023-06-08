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
        public void AddMod(ModRequest mod)
        {
            _modLogic.AddMod(mod.Basemouse, mod.Weight, mod.Comments, mod.UserId);
        }

        [HttpGet]
        [Route("user/{id}")]
        public List<MouseMod> getModsByUser(string id)
        {
            return _modLogic.getModsByUser(id);
        }

        [HttpDelete]
        public void DeleteMod(int modId) { 
            _modLogic.DeleteMod(modId);
        }

        [HttpGet]
        [Route("{id}")]
        public MouseMod getModById(int id)
        {
            return _modLogic.getModById(id);
        }

        [HttpPut]
        public void UpdateMod(MouseMod mod) { 
            _modLogic.UpdateMod(mod); 
        }

    }
}
