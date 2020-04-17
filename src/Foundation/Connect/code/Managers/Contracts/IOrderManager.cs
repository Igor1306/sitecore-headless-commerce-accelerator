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

namespace HCA.Foundation.Connect.Managers
{
    using System;

    using Sitecore.Commerce.Entities.Orders;
    using Sitecore.Commerce.Services.Orders;

    public interface IOrderManager
    {
        ManagerResponse<GetVisitorOrderResult, Sitecore.Commerce.Entities.Orders.Order> GetOrderDetails(
            string orderId,
            string customerId,
            string shopName);

        ManagerResponse<GetVisitorOrdersResult, OrderHeader[]> GetVisitorOrders(
            string customerId,
            string shopName,
            DateTime? fromDate,
            DateTime? untilDate,
            int page,
            int count);

        ManagerResponse<SubmitVisitorOrderResult, Sitecore.Commerce.Entities.Orders.Order> SubmitVisitorOrder(
            Sitecore.Commerce.Entities.Carts.Cart cart);
    }
}