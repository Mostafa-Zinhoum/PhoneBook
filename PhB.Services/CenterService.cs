using PhB.Data;
using PhB.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Services
{
    public class CenterService : ICenterService
    {
        private readonly IRepository<Center> repo;

        public CenterService(IRepository<Center> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Center> GetCenters(long governorateId)
        {
            return repo.Get(x=>x.GovernorateId == governorateId);
        }
    }
}
