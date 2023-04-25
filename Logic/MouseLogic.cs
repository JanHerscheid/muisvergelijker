using DAL;
using DAL.Interfaces;
using DTO;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MouseLogic : IMouseLogic
    {
        private IMouseHandler _mouseHandler;
        public MouseLogic(IMouseHandler mouseHandler)
        {
            _mouseHandler = mouseHandler;
        }

        public List<Mouse> GetAll()
        {
            return _mouseHandler.GetAll();
        }

        public void AddMouse(Mouse mouse) { 
            _mouseHandler.AddMouse(mouse);
        }
    }
}
