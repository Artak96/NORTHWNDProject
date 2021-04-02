using Core.Abstractions.Repositories;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(NORTHWNDContext context) : base(context)
        {
                
        }
    }
}
