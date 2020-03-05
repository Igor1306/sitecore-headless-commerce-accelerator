//    Copyright 2020 EPAM Systems, Inc.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System.Web.Mvc;

namespace Wooli.Feature.Checkout.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using Foundation.Commerce.Models;
    using Foundation.Commerce.Models.Entities;
    using Foundation.Commerce.Services.Cart;
    using Foundation.Commerce.Utils;
    using Foundation.Extensions.Extensions;
    using Models.Requests;
    using Sitecore.Diagnostics;
    using IHttpActionResult = ActionResult;

    [RoutePrefix(Constants.CommerceRoutePrefix + "/carts")]
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            Assert.ArgumentNotNull(cartService, nameof(cartService));
            this.cartService = cartService;
        }

        [HttpGet, ActionName("get")]
        public IHttpActionResult GetCart()
        {
            return this.Execute(this.cartService.GetCart);
        }

        [HttpPost, ActionName("addCartLine")]
        public IHttpActionResult AddCartLine(AddCartLineRequest request)
        {
            return this.ExecuteWithCurrentCart(cart => this.cartService.AddCartLine(cart, request.ProductId, request.VariantId, request.Quantity));
        }

        [HttpPut, ActionName("updateCartLine")]
        public IHttpActionResult UpdateCartLine(UpdateCartLineRequest request)
        {
            return this.ExecuteWithCurrentCart(cart => this.cartService.UpdateCartLine(cart, request.ProductId, request.VariantId, request.Quantity));
        }

        [HttpDelete, ActionName("removeCartLine")]
        public IHttpActionResult RemoveCartLine(RemoveCartLineRequest request)
        {
            return this.ExecuteWithCurrentCart(cart => this.cartService.RemoveCartLine(cart, request.ProductId, request.VariantId));
        }

        [HttpPost, ActionName("addPromoCode")]
        public IHttpActionResult AddPromoCode(PromoCodeRequest request)
        {
            return this.ExecuteWithCurrentCart(cart => this.cartService.AddPromoCode(cart, request.PromoCode));
        }

        [HttpDelete, ActionName("removePromoCode")]
        public IHttpActionResult RemovePromoCode(PromoCodeRequest request)
        {
            return this.ExecuteWithCurrentCart(cart => this.cartService.RemovePromoCode(cart, request.PromoCode));
        }

        private IHttpActionResult ExecuteWithCurrentCart(Func<Cart, Result<Cart>> action)
        {
            return this.Execute(
                () =>
            {
                var cartResult = this.cartService.GetCart();
                return action.Invoke(cartResult.Data);
            });
        }

        private IHttpActionResult Execute(Func<Result<Cart>> action)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    var errorMessages =
                        this.ModelState.SelectMany(state => state.Value?.Errors.Select(error => error.ErrorMessage)).ToArray();
                    return this.JsonError(errorMessages, HttpStatusCode.BadRequest);
                }

                var result = action.Invoke();

                return result.Success
                    ? this.JsonOk(result.Data)
                    : this.JsonError(
                        result.Errors?.ToArray(),
                        HttpStatusCode.InternalServerError,
                        tempData: result.Data);
            }
            catch (Exception exception)
            {
                return this.JsonError(exception.Message, HttpStatusCode.InternalServerError, exception);
            }
        }
    }
}