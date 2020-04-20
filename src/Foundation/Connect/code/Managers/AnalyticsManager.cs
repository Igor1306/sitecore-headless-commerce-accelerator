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
    using DependencyInjection;

    using Providers.Contracts;

    using Sitecore.Commerce.Services.Catalog;
    using Sitecore.Diagnostics;

    [Service(typeof(IAnalyticsManager))]
    public class AnalyticsManager : IAnalyticsManager
    {
        private readonly CatalogServiceProvider catalogServiceProvider;

        public AnalyticsManager(IConnectServiceProvider connectServiceProvider)
        {
            Assert.ArgumentNotNull(connectServiceProvider, nameof(connectServiceProvider));
            this.catalogServiceProvider = connectServiceProvider.GetCatalogServiceProvider();
        }

        public void VisitedCategoryPage(string shopName, string categoryId, string categoryName)
        {
            Assert.IsNotNullOrEmpty(categoryId, nameof(categoryId));
            Assert.IsNotNullOrEmpty(categoryName, nameof(categoryName));
            var request = new VisitedCategoryPageRequest(shopName, categoryId, categoryName);

            this.catalogServiceProvider.VisitedCategoryPage(request);
        }

        public void VisitedProductDetailsPage(string shopName, string productId, string productName)
        {
            Assert.IsNotNullOrEmpty(productId, nameof(productId));
            Assert.IsNotNullOrEmpty(productName, nameof(productName));
            var request = new VisitedProductDetailsPageRequest(shopName, productId, productName, null, null);

            this.catalogServiceProvider.VisitedProductDetailsPage(request);
        }
    }
}