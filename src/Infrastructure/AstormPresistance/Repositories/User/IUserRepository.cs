using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.User
{
    public interface IUserRepository
    {
        Task ChangeStatus(int status, Guid userId);
    }
}
