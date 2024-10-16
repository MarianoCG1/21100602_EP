using _21100602_EP.Data;
using _21100602_EP.Entities;
using _21100602_EP.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _21100602_EP.Repositories
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private readonly Parcial2024221100602Context _dbcontext;

        public JobOfferRepository(Parcial2024221100602Context context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<JobOffer>> GetAll()
        {
            var attendees = await _dbcontext.JobOffer.Where(a => a.Id != 0).ToListAsync();
            return attendees;
        }

        public async Task<int> Insert(JobOffer jobOffer)
        {
            await _dbcontext.JobOffer.AddAsync(jobOffer);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0 ? jobOffer.Id : -1;
        }

        public async Task<bool> Update(JobOffer jobOffer)
        {
            _dbcontext.JobOffer.Update(jobOffer);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var jobOffer = await _dbcontext.JobOffer.FirstOrDefaultAsync(a => a.Id == id);
            _dbcontext.JobOffer.Remove(jobOffer);

            if (jobOffer == null) return false;
            return true;
        }


    }
}
