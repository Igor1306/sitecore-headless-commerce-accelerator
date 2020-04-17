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

namespace Wooli.Foundation.Commerce.Infrastructure.Pipelines
{
    using System.Linq;

    using Connect.Managers;

    using Context;

    using DependencyInjection;

    using Extensions.Services;

    using Providers;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;

    using Constants = Utils.Constants;

    [Service(typeof(ICatalogItemResolver))]
    public class CatalogItemResolver : ICatalogItemResolver
    {
        private readonly IPageTypeProvider pageTypeProvider;

        private readonly ISearchManager searchManager;

        private readonly ISiteContext siteContext;

        private readonly ISiteDefinitionsProvider siteDefinitionsProvider;

        private readonly IStorefrontContext storefrontContext;

        public CatalogItemResolver(
            ISearchManager searchManager,
            IPageTypeProvider pageTypeProvider,
            IStorefrontContext storefrontContext,
            ISiteDefinitionsProvider siteDefinitionsProvider,
            ISiteContext siteContext,
            IAnalyticsManager analyticsManager)
        {
            this.searchManager = searchManager;
            this.pageTypeProvider = pageTypeProvider;
            this.storefrontContext = storefrontContext;
            this.siteDefinitionsProvider = siteDefinitionsProvider;
            this.siteContext = siteContext;
        }

        public void ProcessItemAndApplyContext(Item contextItem, string[] urlSegments)
        {
            Assert.ArgumentNotNull(contextItem, nameof(contextItem));

            if (urlSegments == null)
            {
                return;
            }

            var rootItem = this.siteDefinitionsProvider.GetCurrentSiteDefinition()?.RootItem;
            if (rootItem == null)
            {
                return;
            }

            if (this.siteContext.CurrentItem != null)
            {
                return;
            }

            var currentItem = Context.Item;
            while ((currentItem != null) && (currentItem.ID != rootItem.ID))
            {
                var urlSegment = urlSegments?.LastOrDefault()?.TrimEnd('/');

                this.ProcessItem(currentItem, urlSegment, this.storefrontContext.CatalogName);

                if (urlSegments?.Length > 0)
                {
                    urlSegments = urlSegments.Take(urlSegments.Length - 1).ToArray();
                }

                currentItem = currentItem.Parent;
            }
        }

        private void ProcessItem(Item item, string urlSegment, string catalogName)
        {
            var contextItemType = this.pageTypeProvider.ResolveByItem(item);
            if (contextItemType == Constants.ItemType.Unknown)
            {
                return;
            }

            var itemName = item.Name != "*" ? item.Name : urlSegment;
            if (string.IsNullOrEmpty(itemName))
            {
                return;
            }

            Item catalogItem;
            switch (contextItemType)
            {
                case Constants.ItemType.Category:
                    catalogItem = this.searchManager.GetCategory(catalogName, itemName);
                    this.siteContext.CurrentCategoryItem = catalogItem;
                    break;
                case Constants.ItemType.Product:
                    catalogItem = this.searchManager.GetProduct(catalogName, itemName);
                    this.siteContext.CurrentProductItem = catalogItem;
                    break;
                default:
                    return;
            }

            if (this.siteContext.CurrentItem == null)
            {
                this.siteContext.CurrentItem = catalogItem;
            }
        }
    }
}