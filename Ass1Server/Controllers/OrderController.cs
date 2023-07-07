using Ass1Server.Models.Order;
using Ass1Server.Models.OrderDetail;
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

        [HttpGet("{memberId}/orders")]
        public async Task<ActionResult<IEnumerable<OrderInfoDTO>>> GetOrdersByMemberId(int memberId)
        {
            IEnumerable<Order> orders = await _repository.GetOrdersByMemberId(memberId);
            return Ok(_mapper.Map<IEnumerable<OrderInfoDTO>>(orders));
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderWithDetailDTO>> GetOrderById(int orderId)
        {
            Order order = await _repository.GetOrderById(orderId);
            if (order != null)
            {
                List<OrderDetailDTO> odDTOs = new List<OrderDetailDTO>();
                foreach (var item in order.OrderDetails)
                {
                    double DiscountAmount = item.Discount.HasValue ? 1.0 - (item.Discount.Value / 100.0d) : 1.0d;
                    odDTOs.Add(new OrderDetailDTO
                    {
                        OrderId = item.OrderId,
                        Discount = item.Discount,
                        ProductId = item.ProductId,
                        ProductName = item.Product.ProductName,
                        Quantity = item.Quantity,
                        Price = item.Quantity * item.Product.UnitPrice * DiscountAmount
                    }
                    );
                }
                OrderWithDetailDTO result = new OrderWithDetailDTO
                {
                    Email = order.Member.Email,
                    Freight = order.Freight,
                    OrderDate = order.OrderDate,
                    OrderId = orderId,
                    RequiredDate = order.RequiredDate,
                    ShippedDate = order.ShippedDate,
                    OrderDetails = odDTOs
                };
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("report")]
        public async Task<ActionResult<IEnumerable<OrderReportDTO>>> GetOrderReports(DateTime? startDate, DateTime? endDate)
        {
            if ((startDate == null && endDate != null) || (startDate != null && endDate == null)) 
            {
                return BadRequest();
            }
            IEnumerable<Order> orders = await _repository.GetOrdersWithDetail(startDate, endDate);
            List<OrderReportDTO> result = new List<OrderReportDTO>();
            foreach (var order in orders)
            {
                double? discount = order.OrderDetails.Where(od => od.Discount.HasValue).Sum(od => od.Product.UnitPrice * od.Discount / 100.0d);
                OrderReportDTO od = new OrderReportDTO
                {

                    Email =order.Member.Email,
                    Freight = order.Freight,
                    ShippedDate = order.ShippedDate,
                    Discount = discount,
                    Price = order.OrderDetails.Sum(o => o.Product.UnitPrice) - (discount.HasValue?discount.Value:0d)
                };
                result.Add(od);
            }
            return Ok(result);
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
