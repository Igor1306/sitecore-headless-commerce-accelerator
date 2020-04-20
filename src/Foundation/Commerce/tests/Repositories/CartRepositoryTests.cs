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

namespace Wooli.Foundation.Commerce.Tests.Repositories
{
    using System.Collections.Generic;

    using Commerce.ModelMappers;
    using Commerce.Repositories;

    using Connect.Managers;

    using Context;

    using ModelInitializers;

    using Models.Catalog;
    using Models.Checkout;

    using NSubstitute;

    using Sitecore.Commerce.Entities.Carts;
    using Sitecore.Commerce.Entities.Prices;
    using Sitecore.Commerce.Services.Carts;
    using Sitecore.Data;
    using Sitecore.FakeDb;

    using Xunit;

    public class CartRepositoryTests
    {
        [Fact]
        public void GetCurrentCart_ProductId_ProductIsReturned()
        {
            // Setup
            const string ProductIdValue = "productId";

            var cartManager = Substitute.For<ICartManager>();
            var catalogRepository = Substitute.For<ICatalogRepository>();
            var accountManager = Substitute.For<IAccountManager>();
            var addressPartyMapper = Substitute.For<IEntityMapper>();
            var cartModelBuilder = Substitute.For<ICartModelBuilder>();
            var storefrontContext = Substitute.For<IStorefrontContext>();
            var visitorContext = Substitute.For<IVisitorContext>();

            var productItemId = new ID();
            var productDbItem = new DbItem("ProductItem", productItemId);
            productDbItem.Fields.Add("ProductId", ProductIdValue);

            using (var db = new Db
            {
                productDbItem
            })
            {
                var cart = new Cart
                {
                    Total = new Total(),
                    Lines = new List<CartLine>
                    {
                        new CartLine
                        {
                            Product = new CartProduct
                            {
                                ProductId = ProductIdValue
                            },
                            Total = new Total()
                        }
                    }
                };

                var productItem = db.GetItem(productItemId);

                storefrontContext.ShopName.Returns("shopName");
                visitorContext.ContactId.Returns("contactId");
                cartManager.GetCurrentCart("shopName", "contactId")
                    .Returns(
                        new ManagerResponse<CartResult, Cart>(
                            new CartResult
                            {
                                Cart = cart
                            },
                            cart));
                catalogRepository.GetProduct(ProductIdValue).Returns(new ProductModel(productItem));
                cartModelBuilder.Initialize(Arg.Any<Cart>())
                    .Returns(
                        new CartModel
                        {
                            CartLines = new List<CartLineModel>
                            {
                                new CartLineModel
                                {
                                    Product = new ProductModel(productItem)
                                }
                            }
                        });

                // Execute
                var repository = new CartRepository(
                    cartManager,
                    catalogRepository,
                    accountManager,
                    cartModelBuilder,
                    addressPartyMapper,
                    storefrontContext,
                    visitorContext);
                var result = repository.GetCurrentCart();

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result.CartLines);
                Assert.Contains(result.CartLines, x => x.Product.ProductId == ProductIdValue);
            }
        }
    }
}