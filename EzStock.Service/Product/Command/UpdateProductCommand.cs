using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzStock.Service.Product.Command
{
    public record UpdateProductCommand(int IdProduct, string Name, double Price) : INotification
    {
    }
}
