using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzStock.Service.Command
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
