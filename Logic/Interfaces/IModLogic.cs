using DTO;

namespace Logic.Interfaces
{
    public interface IModLogic
    {
        void AddMod(int basemouse, int weight, string comments, string userid);
        List<MouseMod> GetAll();
        List<MouseMod> getModsByUser(string uid);
        void DeleteMod(int modId);
        MouseMod getModById(int id);
        void UpdateMod(MouseMod mod);
    }
}