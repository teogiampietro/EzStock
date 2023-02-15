using AutoMapper;
using EzStock.Api.Util;
using EzStock.Domain.Entities;
using EzStock.Service.Command;
using EzStock.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace EzStock.Api.Controllers
{
    public class ProductController : MainController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public ProductController(IMediator _mediator, IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<List<Product>> GetAll([FromQuery] GetProductsQuery input)
        {
            var product = await mediator.Send(input);

            return mapper.Map<List<Product>>(product);
        }

        [HttpGet("{productsIds}")]
        public async Task<List<Product>> GetById(string productsIds)
        {
            var product = await mediator.Send(new GetProductsByIdQuery() { Ids = QueryParams.GetListInt(productsIds) });

            return mapper.Map<List<Product>>(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductCommand input)
        {
            await mediator.Publish(input);

            return StatusCode(201);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            await mediator.Publish(command);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Publish(new DeleteProductByIdCommand(id));
            return StatusCode(201);
        }
    }
}
