using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class MouseHandler : IMouseHandler
    {
        private readonly DataContext _context;
        public MouseHandler(DataContext dataContext)
        {
            _context = dataContext;
        }

        public List<Mouse> GetAll()
        {
            return _context.Mice.ToList();
        }

        public Mouse getById(int id) {
            return _context.Mice.First(x => x.Id == id);
        }

        public void AddMouse(Mouse mouse) {
            _context.Mice.Add(mouse);
            _context.SaveChanges();
        }
    }
}
