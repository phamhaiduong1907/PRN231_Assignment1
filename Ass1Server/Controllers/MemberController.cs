using Ass1Server.Models.Member;
using AutoMapper;
using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace Ass1Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMapper _mapper;
        private IMemberRepository _memberRepository;

        public MemberController( IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }   

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IEnumerable<MemberInfoDTO>> GetMembers()
        {
            IEnumerable<Member> members = await _memberRepository.GetAll();
            return _mapper.Map<IEnumerable<MemberInfoDTO>>(members);
        }

        [HttpGet("login")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<MemberInfoDTO>> GetMemberByEmailAndPassword(string username, string password) 
        {
            Member member = await _memberRepository.GetByEmailAndPassword(username, password);
            if(member == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_mapper.Map<MemberInfoDTO>(member));
            }
        }

        [HttpGet("search")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<MemberInfoDTO>>> SearchMemberByHint(string search_query)
        {
            IEnumerable<Member> members = await _memberRepository.GetByHint(search_query);
            return _mapper.Map<IEnumerable<MemberInfoDTO>>(members).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync([FromBody] MemberInfoDTO member)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("model is invalid");
            }
            try
            {
                await _memberRepository.Save(_mapper.Map<MemberInfoDTO,Member>(member));
            }
            catch
            {
                return BadRequest("database exception");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> OnPutAsync(int id,[FromBody] MemberInfoDTO member)
        {
            if (id != member.MemberId)
                return BadRequest("id is not consistent");
            if (!ModelState.IsValid)
            {
                return BadRequest("model is invalid");
            }
            try
            {
                await _memberRepository.Update(id, _mapper.Map<MemberInfoDTO, Member>(member));
            }
            catch
            {
                return BadRequest("database exception");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> OnDeleteAsync(int id)
        {
            try
            {
                await _memberRepository.Delete(id);
            }
            catch
            {
                return BadRequest("db exception");
            }
            return NoContent();
        }
    }
}
