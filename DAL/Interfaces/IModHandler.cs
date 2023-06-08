using DTO;

namespace DAL.Interfaces
{
    public interface IModHandler
    {
        void AddMod(MouseMod mod);
        List<MouseMod> GetAll();
        List<MouseMod> getModsByUser(string uid);
        void DeleteMod(MouseMod mod);
        MouseMod getModById(int id);
        void UpdateMod(MouseMod mod);
    }
}