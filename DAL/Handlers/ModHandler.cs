using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
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
            //Base moet erbij zodat die ook de data van de base meestuurt
            return _context.Mods.Include(m => m.Base).ToList();
        }

        public void AddMod(MouseMod mod)
        {
            _context.Mods.Add(mod);
            _context.SaveChanges();
        }

        public List<MouseMod> getModsByUser(string uid)
        {
            return _context.Mods.Where(x => x.auth0Id == uid).Include(m => m.Base).ToList();
        }

        public MouseMod getModById(int id)
        {
            return _context.Mods.First(x => x.Id == id);
        }

        public void DeleteMod(MouseMod mod) { 
            _context.Mods.Remove(mod);
            _context.SaveChanges();
        }

        public void UpdateMod(MouseMod mod)
        {
            MouseMod? toUpdate = getModById(mod.Id);
            if (toUpdate != null)
            {
                toUpdate.Comments = mod.Comments;
                toUpdate.Weight = mod.Weight;
                _context.SaveChanges();
            }
        }

    }
}
