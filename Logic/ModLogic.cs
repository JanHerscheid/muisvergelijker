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

        public ModLogic(IModHandler modHandler)
        {
            _modHandler = modHandler;
        }

        public List<MouseMod> GetAll()
        {
            return _modHandler.GetAll();
        }

        public void AddMod(int basemouse, int weight, string comments)
        {
            //get mouse from basemouse (dit is de id van de muis)

            _modHandler.AddMod(new MouseMod
            {
                //Base = basemouse,
                Weight = weight,
                Comments = comments
            });
        }
    }
}
