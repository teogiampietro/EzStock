using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzStock.Service.Command
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
