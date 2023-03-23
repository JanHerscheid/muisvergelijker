using DTO;

namespace Logic.Interfaces
{
    public interface IMouseLogic
    {
        List<Mouse> GetAll();
        void AddMouse(Mouse mouse);
    }
}