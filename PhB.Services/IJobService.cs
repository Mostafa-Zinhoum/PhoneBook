﻿using PhB.Data;
using PhB.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Services
{
    public interface IJobService
    {
        public IEnumerable<Job> GetJobs();
    }
}
