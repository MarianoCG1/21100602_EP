using _21100602_EP.Entities;

namespace _21100602_EP.Interfaces
{
    public interface IJobOfferRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<JobOffer>> GetAll();
        Task<int> Insert(JobOffer jobOffer);
        Task<bool> Update(JobOffer jobOffer);
    }
}