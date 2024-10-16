using _21100602_EP.Data;
using _21100602_EP.Entities;
using _21100602_EP.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _21100602_EP.Repositories
{
    public class CompentencyRepository : ICompentencyRepository
    {
        private readonly Parcial2024221100602Context _dbcontext;

        public CompentencyRepository(Parcial2024221100602Context context)
        {
            _dbcontext = context;
        }
        public async Task<IEnumerable<Competency>> GetAll()
        {
            var Competency = await _dbcontext.Competency.Where(a => a.Id != 0).ToListAsync();
            return Competency;
        }

        public async Task<int> Insert(Competency Competency)
        {
            await _dbcontext.Competency.AddAsync(Competency);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0 ? Competency.Id : -1;
        }

        public async Task<bool> Update(Competency Competency)
        {
            _dbcontext.Competency.Update(Competency);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var Compentency = await _dbcontext.Competency.FirstOrDefaultAsync(a => a.Id == id);
            _dbcontext.Competency.Remove(Compentency);

            if (Compentency == null) return false;
            return true;

        }

    }
}
