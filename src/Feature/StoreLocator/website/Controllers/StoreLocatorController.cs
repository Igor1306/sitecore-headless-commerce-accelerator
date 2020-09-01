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

namespace HCA.Feature.StoreLocator.Controllers
{
    using System.Web.Mvc;

    using HCA.Feature.StoreLocator.Models.Requests;
    using HCA.Feature.StoreLocator.Services;
    using HCA.Foundation.Base.Controllers;

    public class StoreLocatorController : BaseController
    {
        private readonly IStoreLocatorService storeLocatorService;

        public StoreLocatorController(IStoreLocatorService storeLocatorService)
        {
            this.storeLocatorService = storeLocatorService;
        }

        [HttpGet]
        [ActionName("stores")]
        public ActionResult GetLocations(StoreLocationRequest storeLocationRequest)
        {
            return this.Execute(
                () => this.storeLocatorService.FindStoresByGeolocation(
                    storeLocationRequest.Lat,
                    storeLocationRequest.Lng,
                    storeLocationRequest.Radius));
        }
    }
}