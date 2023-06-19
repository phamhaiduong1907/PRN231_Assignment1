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

        public async void Delete(int id)
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

        public async void Save(Member member)
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

        public async void Update(int id, Member member)
        {
            Member memberById = await GetMemberById(id);
            if(memberById != null )
            {
                Member memberByEmail = await GetMemberByEmail(member.Email);
                if(memberByEmail == null)
                {
                    _context.Entry(member).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception();
                }
            } 
            else 
            { 
                throw new Exception(); 
            }
        }
    }
}
