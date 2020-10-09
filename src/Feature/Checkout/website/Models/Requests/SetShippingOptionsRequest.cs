﻿//    Copyright 2020 EPAM Systems, Inc.
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

namespace HCA.Feature.Checkout.Models.Requests
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    using Foundation.Commerce.Models.Entities.Addresses;
    using Foundation.Commerce.Models.Entities.Shipping;

    using TypeLite;

    [ExcludeFromCodeCoverage]
    [TsClass]
    public class SetShippingOptionsRequest
    {
        [Required]
        public string OrderShippingPreferenceType { get; set; }

        [Required]
        public List<Address> ShippingAddresses { get; set; }

        [Required]
        public List<ShippingMethod> ShippingMethods { get; set; }
    }
}