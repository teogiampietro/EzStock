using AutoMapper;
using EzStock.Domain.Entities;
using EzStock.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<Product>> Get([FromQuery] GetProductsQuery input)
        {
            var hospedajes = await mediator.Send(input);

            return mapper.Map<List<Product>>(hospedajes);
        }
    }
}
