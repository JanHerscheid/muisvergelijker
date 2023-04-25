using DTO;

namespace Logic.Interfaces
{
    public interface IModLogic
    {
        void AddMod(int basemouse, int weight, string comments);
        List<MouseMod> GetAll();
    }
}