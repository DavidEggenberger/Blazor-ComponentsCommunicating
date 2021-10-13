using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorCompoonentsCommunicateBillaterl.Features;
using MediatR;

namespace BlazorCompoonentsCommunicateBillaterl.Features
{
    public class AddProductToCartCommand : IRequest<AddProductToCartResponse>
    {
        public Product Product { get; set; }
    }
    public class AddProductToCartResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class AddProductToBasketEventArgs : EventArgs
    {
        public Product Product { get; set; }
    }
}
namespace BlazorCompoonentsCommunicateBillaterl
{
    public partial class CartComponent : IRequestHandler<AddProductToCartCommand, AddProductToCartResponse>
    {
        public static event EventHandler<AddProductToBasketEventArgs> ProductAdded;
        private static List<AddProductToCartCommand> addProductToCartCommands = new List<AddProductToCartCommand>();
        public async Task<AddProductToCartResponse> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            decimal totalPrice = addProductToCartCommands.Sum(x => x.Product.Price) + request.Product.Price;
            if(totalPrice < 200)
            {
                ProductAdded?.Invoke(this, new AddProductToBasketEventArgs { Product = request.Product });
                addProductToCartCommands.Add(request);
                return new AddProductToCartResponse { Succeeded = true };
            }
            return new AddProductToCartResponse
            {
                Succeeded = false,
                Message = $"{totalPrice} exceeds the limit of 200$"
            };
        }
    }
}