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

        public async Task<Member> GetMemberById(int id) 
        {
            var member = await _context.Members.FindAsync(id);
            return member;
        }

        public async Task<Member> GetMemberByEmail(string email)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Email.Equals(email));
            return member;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _context.Members.AsNoTracking().ToListAsync();
        }

        public async Task<Member> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Members.AsNoTracking().FirstOrDefaultAsync(m => m.Email.Equals(email) && m.Password.Equals(password));
        }

        public async Task<IEnumerable<Member>> GetByHint(string hint)
        {
            hint = hint.ToLower();
            return await _context.Members.Where(m => m.City.ToLower().Contains(hint) || 
                                                m.Country.ToLower().Contains(hint) ||
                                                m.CompanyName.ToLower().Contains(hint) ||
                                                m.Email.ToLower().Contains(hint))
                                                .AsNoTracking()
                                                .ToListAsync();
        }

        public async Task Delete(int id)
        {
            Member member = await _context.Members.FindAsync(id);
            if(member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Save(Member member)
        {
            var memberToSave = await GetMemberByEmail(member.Email);
            if (memberToSave != null)
            {
                throw new Exception();
            }
            else
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(int id, Member member)
        {
            Member memberById = await GetMemberById(id);
            if(memberById != null )
            {
                Member memberByEmail = await _context.Members.Where(m => m.Email == member.Email && m.MemberId != id).FirstOrDefaultAsync();
                if(memberByEmail == null)
                {
                    memberById.Email = member.Email;
                    memberById.City = member.City;
                    memberById.Country = member.Country;
                    memberById.CompanyName = member.CompanyName;
                    _context.Members.Update(memberById);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Save failed");
                }
            } 
            else 
            { 
                throw new Exception("Cannot find member"); 
            }
        }
    }
}
