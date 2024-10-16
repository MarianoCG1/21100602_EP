using _21100602_EP.Entities;

namespace _21100602_EP.Interfaces
{
    public interface ICompentencyRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Competency>> GetAll();
        Task<int> Insert(Competency Competency);
        Task<bool> Update(Competency Competency);
    }
}