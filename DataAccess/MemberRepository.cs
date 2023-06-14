using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberRepository : IMemberRepository
    {
        Ass1Context _context;
        public MemberRepository() 
        {
            _context = new Ass1Context();
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.Email.Equals(email) && m.Password.Equals(password));
        }
    }
}
