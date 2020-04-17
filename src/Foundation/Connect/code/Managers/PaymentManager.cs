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

namespace Wooli.Foundation.Connect.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using DependencyInjection;

    using Providers.Contracts;

    using Sitecore.Commerce.Engine.Connect.Entities;
    using Sitecore.Commerce.Engine.Connect.Pipelines.Arguments;
    using Sitecore.Commerce.Entities.Carts;
    using Sitecore.Commerce.Entities.Payments;
    using Sitecore.Commerce.Services;
    using Sitecore.Commerce.Services.Payments;
    using Sitecore.Diagnostics;

    using GetPaymentMethodsRequest = Sitecore.Commerce.Engine.Connect.Services.Payments.GetPaymentMethodsRequest;

    [Service(typeof(IPaymentManager))]
    public class PaymentManager : IPaymentManager
    {
        private readonly PaymentServiceProvider paymentServiceProvider;

        public PaymentManager(IConnectServiceProvider connectServiceProvider)
        {
            Assert.ArgumentNotNull(connectServiceProvider, nameof(connectServiceProvider));
            this.paymentServiceProvider = connectServiceProvider.GetPaymentServiceProvider();
        }

        public ManagerResponse<ServiceProviderResult, string> GetPaymentClientToken()
        {
            var request = new ServiceProviderRequest();
            var clientTokenResult =
                this.paymentServiceProvider.RunPipeline<ServiceProviderRequest, PaymentClientTokenResult>(
                    "commerce.payments.getClientToken",
                    request);
            return new ManagerResponse<ServiceProviderResult, string>(clientTokenResult, clientTokenResult.ClientToken);
        }

        public ManagerResponse<GetPaymentMethodsResult, IEnumerable<PaymentMethod>> GetPaymentMethods(
            Cart cart,
            PaymentOption paymentOption)
        {
            var request = new GetPaymentMethodsRequest(cart as CommerceCart, paymentOption);

            var paymentMethods = this.paymentServiceProvider.GetPaymentMethods(request);
            return new ManagerResponse<GetPaymentMethodsResult, IEnumerable<PaymentMethod>>(
                paymentMethods,
                paymentMethods.PaymentMethods.ToList());
        }

        public ManagerResponse<GetPaymentOptionsResult, IEnumerable<PaymentOption>> GetPaymentOptions(string shopName, Cart cart)
        {
            var request = new GetPaymentOptionsRequest(shopName, cart);
            var paymentOptions = this.paymentServiceProvider.GetPaymentOptions(request);
            return new ManagerResponse<GetPaymentOptionsResult, IEnumerable<PaymentOption>>(
                paymentOptions,
                paymentOptions.PaymentOptions.ToList());
        }
    }
}