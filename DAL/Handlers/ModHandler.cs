using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class ModHandler : IModHandler
    {
        private readonly DataContext _context;
        public ModHandler(DataContext dataContext)
        {
            _context = dataContext;
        }

        public List<MouseMod> GetAll()
        {
            return _context.Mods.ToList();
        }

        public void AddMod(MouseMod mod)
        {
            _context.Mods.Add(mod);
            _context.SaveChanges();
        }
    }
}
