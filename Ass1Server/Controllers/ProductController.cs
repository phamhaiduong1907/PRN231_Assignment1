using Ass1Server.Models.Category;
using Ass1Server.Models.Product;
using AutoMapper;
using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ass1Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMapper _mapper;
        IProductRepository _repository;

        public ProductController(IMapper mapper, IProductRepository repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInfoDTO>>> GetProducts()
        {
            return Ok(_mapper.Map<IEnumerable<ProductInfoDTO>>(await _repository.GetAllProducts()));
        }

        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<CategoryInfoDTO>>> GetCategories()
        {
            return Ok(_mapper.Map<IEnumerable<CategoryInfoDTO>>(await _repository.GetAllCategories()));
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync([FromBody] ProductModifyDTO product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.Save(_mapper.Map<Product>(product));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> OnPutAsync([FromBody] ProductModifyDTO product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _repository.Update(_mapper.Map<Product>(product));
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> OnDeleteAsync(int id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();
        }
        
    }
}
