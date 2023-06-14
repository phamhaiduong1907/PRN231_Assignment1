using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ass1Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private IMemberRepository _memberRepository;

        public MemberController(ILogger<MemberController> logger, IMemberRepository memberRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _memberRepository.GetAll();
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<Member> GetMemberByEmailAndPassword(string username, string password) 
        {
            return await _memberRepository.GetByEmailAndPassword(username, password);
        }
    }
}
