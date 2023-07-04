using Ass1Server.Models.Order;
using AutoMapper;
using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ass1Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository _repository;
        IMapper _mapper;
        public OrderController(IOrderRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderInfoDTO>>> GetAllOrders()
        {
            IEnumerable<Order> orders = await _repository.GetOrders();
            return Ok(_mapper.Map<IEnumerable<OrderInfoDTO>>(orders));
        }

        [HttpGet("{memberId}")]
        public async Task<ActionResult<IEnumerable<OrderInfoDTO>>> GetOrdersByMemberId(int memberId)
        {
            IEnumerable<Order> orders = await _repository.GetOrdersByMemberId(memberId);
            return Ok(_mapper.Map<IEnumerable<OrderInfoDTO>>(orders));
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(OrderCreateDTO order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.CreateOrder(_mapper.Map<Order>(order));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> OnPutAsync(int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> OnDeleteAsync(int id)
        {
            return NoContent();
        }
    }
}
