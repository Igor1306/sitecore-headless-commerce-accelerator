﻿using AutoTests.AutomationFramework.UI.Driver;
using AutoTests.HCA.Core.UI;
using AutoTests.HCA.Core.UI.CommonElements;
using AutoTests.HCA.Core.UI.Pages;
using NUnit.Framework;

namespace AutoTests.HCA.Tests.UITests
{
    [UiTest]
    [Parallelizable(ParallelScope.None)]
    [TestFixture(BrowserType.Chrome)]
    public class ShopPageTests : HcaWebTest
    {
        [SetUp]
        public void SetUp()
        {
            _hcaWebSite.NavigateToPage(_hcaWebSite.ShopPage, "Home Theater");
            _hcaWebSite.ShopPage.WaitForOpened();
        }

        private readonly HcaWebSite _hcaWebSite;
        private readonly ShopPage _shopPage;
        private readonly ProductsFilterSection _filterSection;
        private readonly ProductGridSection _productGrid;
        public const int DEF_PRODUCTS_COUNT_ON_PAGE = 12;
        public const string DEF_OPTION_NAME = "Aura Home Theater In a Box";
        public const string DEF_PRODUCT_NAME = "Habitat Aura 2.1 Channel Soundbar with Wireless Subwoofer";

        public ShopPageTests(BrowserType browserType) : base(browserType)
        {
            _hcaWebSite = HcaWebSite.Instance;
            _shopPage = _hcaWebSite.ShopPage;
            _filterSection = _hcaWebSite.ProductsFilterSection;
            _productGrid = _hcaWebSite.ProductGridSection;
        }

        [Test]
        public void ShopPageTests_01_SelectFilterOptionsTest()
        {
            _hcaWebSite.ProductsFilterSection.FilterSectionIsPresent();
            Assert.Multiple(() =>
            {
                _filterSection.SelectFilterOptionByName(DEF_OPTION_NAME);
                _shopPage.WaitForOpened();
                _filterSection.VerifyFilterOptionIsChecked(DEF_OPTION_NAME);
                Assert.AreEqual(_productGrid.TotalProducts, _filterSection.GetProductsCountFromOption(DEF_OPTION_NAME));
            });
        }

        [Test]
        public void ShopPageTests_02_DeselectFilterOptionsTest()
        {
            _hcaWebSite.ProductsFilterSection.FilterSectionIsPresent();
            Assert.Multiple(() =>
            {
                var productsInitialQuantity = _productGrid.TotalProducts;
                _filterSection.SelectFilterOptionByName(DEF_OPTION_NAME);
                _shopPage.WaitForOpened();
                _filterSection.DeselectFilter(DEF_OPTION_NAME);
                _shopPage.WaitForOpened();
                _filterSection.VerifyFilterOptionIsUnchecked(DEF_OPTION_NAME);
                Assert.AreEqual(productsInitialQuantity, _productGrid.TotalProducts);
            });
        }

        [Test]
        public void ShopPageTests_03_FilterDisableButtonTest()
        {
            _hcaWebSite.ProductsFilterSection.FilterSectionIsPresent();
            Assert.Multiple(() =>
            {
                _filterSection.SelectFilterOptionByName(DEF_OPTION_NAME);
                _shopPage.WaitForOpened();
                _filterSection.ClickFilterDisableButton();
                _shopPage.WaitForOpened();
                _filterSection.VerifyFilterOptionIsUnchecked(DEF_OPTION_NAME);
            });
        }

        [Test]
        public void ShopPageTests_04_FilterHideAllButtonTest()
        {
            _hcaWebSite.ProductsFilterSection.FilterSectionIsPresent();
            Assert.Multiple(() =>
            {
                _filterSection.ClickHideOrShowLink();
                _filterSection.VerifyShowLink("SHOW ALL");
                _filterSection.ClickHideOrShowLink();
                _filterSection.VerifyHideLink("HIDE ALL");
            });
        }

        [Test]
        public void ShopPageTests_05_ProductHeaderTest()
        {
            var totalProducts = _productGrid.TotalProducts;

            Assert.Multiple(() =>
            {
                for (var i = 1; DEF_PRODUCTS_COUNT_ON_PAGE * i < totalProducts; i++)
                {
                    _productGrid.ClickLoadMoreLink();
                    _productGrid.WaitForLazyLoadingSpinnerIsNotPresent();
                }

                var expProductTitle = _productGrid.GetDisplayedProductsCount() + " PRODUCTS";
                Assert.AreEqual(expProductTitle, _productGrid.GetProductsHeaderText());
            });
        }

        [Test]
        public void ShopPageTests_06_LoadProductsTest()
        {
            var totalProducts = _productGrid.TotalProducts;
            var actualProductCount = _productGrid.GetDisplayedProductsCount();
            Assert.LessOrEqual(actualProductCount, DEF_PRODUCTS_COUNT_ON_PAGE,
                $"The number of loaded products at a time should be {DEF_PRODUCTS_COUNT_ON_PAGE}");
            Assert.Multiple(() =>
            {
                for (var i = 1; DEF_PRODUCTS_COUNT_ON_PAGE * i < totalProducts;)
                {
                    _productGrid.ClickLoadMoreLink();
                    _productGrid.WaitForLazyLoadingSpinnerIsNotPresent();
                    actualProductCount = _productGrid.GetDisplayedProductsCount();
                    Assert.LessOrEqual(actualProductCount, DEF_PRODUCTS_COUNT_ON_PAGE * ++i,
                        $"The number of loaded products at a time should be {DEF_PRODUCTS_COUNT_ON_PAGE}");
                }

                Assert.AreEqual(totalProducts, _productGrid.GetDisplayedProductsCount());
                _productGrid.VerifyLoadMoreLink();
            });
        }

        [Test]
        public void ShopPageTests_07_ViewProductTest()
        {
            Assert.Multiple(() =>
            {
                _productGrid.ChooseProduct(DEF_PRODUCT_NAME);
                _hcaWebSite.ProductPage.WaitForOpened();
                Assert.AreEqual(DEF_PRODUCT_NAME.ToUpper(), _hcaWebSite.ProductPage.TitleText);
            });
        }
    }
}