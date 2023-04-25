using DTO;

namespace DAL.Interfaces
{
    public interface IMouseHandler
    {
        List<Mouse> GetAll();
        void AddMouse(Mouse mouse);
        Mouse getById(int id);
    }
}