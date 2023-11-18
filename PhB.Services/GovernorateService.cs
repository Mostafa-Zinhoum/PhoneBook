using PhB.Data;
using PhB.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Services
{
    public class GovernorateService : IGovernorateService
    {
        private readonly IRepository<Governorate> repo;

        public GovernorateService(IRepository<Governorate> repo)
        {
            this.repo = repo;
        }
        public IEnumerable<Governorate> GetGovernorates()
        {
            return repo.Get();
        }
    }
}
