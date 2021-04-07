using NorthWndCore.Abstractions.Repositories;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Repositories
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(NORTHWNDContext context) : base(context)
        {
                
        }
    }
}
