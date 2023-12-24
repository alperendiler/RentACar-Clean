using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse result = await Mediator.Send(createBrandCommand);
            return Created("",result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListBrandQuery getListBrandQuery)
        {
            
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdBrandQuery getByIdBrandQuery)
        {

            GetByIdBrandResponse result = await Mediator.Send(getByIdBrandQuery);
            return Ok(result);
        }
    }
}
