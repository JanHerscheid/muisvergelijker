using DAL.Interfaces;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace Logic
{
    public class ModLogic : IModLogic
    {
        private IModHandler _modHandler;
        private IMouseHandler _mouseHandler;

        public ModLogic(IModHandler modHandler, IMouseHandler mouseHandler)
        {
            _modHandler = modHandler;
            _mouseHandler = mouseHandler;
        }

        public List<MouseMod> GetAll()
        {
            List<MouseMod> mods = _modHandler.GetAll();
            return mods;
        }

        public void AddMod(int basemouse, int weight, string comments, string userid)
        {
            //get mouse from basemouse (dit is de id van de muis)
            Mouse Base = _mouseHandler.getById(basemouse);

            _modHandler.AddMod(new MouseMod
            {
                Base = Base,
                Weight = weight,
                Comments = comments,
                auth0Id = userid
            });
        }

        public List<MouseMod> getModsByUser(string uid) { 
            return _modHandler.getModsByUser(uid);
        }
        public void DeleteMod(int modId) { 
            _modHandler.DeleteMod(getModById(modId));
        }
        public MouseMod getModById(int id) { 
            return _modHandler.getModById(id);
        }
        public void UpdateMod(MouseMod mod)
        {
            _modHandler.UpdateMod(mod);
        }
    }
}
