using Senai.WebApi.InLock.DatabaseFirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.InLock.DatabaseFirst.Models
{
    public class RepositoryBase
    {
        protected InLockContext dbo = new InLockContext(); 
    }
}
