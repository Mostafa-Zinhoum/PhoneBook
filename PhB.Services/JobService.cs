using PhB.Data;
using PhB.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> repo;

        public JobService(IRepository<Job> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Job> GetJobs()
        {
            return repo.Get();
        }
    }
}
