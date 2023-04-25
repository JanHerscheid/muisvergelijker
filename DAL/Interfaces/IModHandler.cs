using DTO;

namespace DAL.Interfaces
{
    public interface IModHandler
    {
        void AddMod(MouseMod mod);
        List<MouseMod> GetAll();
    }
}