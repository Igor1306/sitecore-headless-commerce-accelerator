﻿using HCA.Pages.ConstantsAndEnums;
using UIAutomationFramework.Controls;
using UIAutomationFramework.Core;

namespace HCA.Pages.Pages
{
    public class ShopPage : CommonPage
    {
        private static ShopPage _shopPage;

        private static readonly WebElement _productGrid = new WebElement("product grid", ByCustom.ClassName("listing-product-grid"));

        public static ShopPage Instance => _shopPage ??= new ShopPage();

        public override string GetPath() =>
            PagePrefix.Shop.GetPrefix();

        public override void WaitForOpened() =>
            _productGrid.WaitForPresent();


    }
}