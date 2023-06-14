using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetByEmailAndPassword(string email, string password);
    }
}
