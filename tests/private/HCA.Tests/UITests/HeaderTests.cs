﻿using HCA.Pages;
using HCA.Pages.CommonElements;
using HCA.Pages.ConsantsAndEnums;
using HCA.Pages.ConsantsAndEnums.Header;
using HCA.Pages.ConsantsAndEnums.Header.MainMenu;
using HCA.Pages.ConsantsAndEnums.Header.MainMenu.SubMenuItems;
using NUnit.Framework;
using UIAutomationFramework.Driver;

namespace HCA.Tests.UITests
{
    [UiTest, TestFixture(BrowserType.Chrome)]
    public class HeaderTests : HcaWebTest
    {
        private HcaWebSite _hcaWebSite;
        private MainMenuControl _mainMenuControl;
        private readonly string _categoryTitle = "CATEGORY";
        private readonly string _featuredTitle = "FEATURED";

        public HeaderTests(BrowserType browserType) : base(browserType) { }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _hcaWebSite = HcaWebSite.Instance;
            _mainMenuControl = _hcaWebSite.MainMenuControl;
        }

        [Test]
        public void HeaderTest([Values] PagePrefix pagePrefix)
        {
            const int expMenuItemCounts = 5;

            _hcaWebSite.GoToPageWithDefaultParams(pagePrefix);

            var headerControl = _hcaWebSite.HeaderControl;
            headerControl.HeaderIsPresent();
            Assert.Multiple(() =>
            {
                headerControl.VerifyLogoNavigationLink(_hcaWebSite.Uri.AbsoluteUri);

                headerControl.VerifyQuickNavigationLink(QuickNavigationLink.StoreLocator);
                headerControl.VerifyQuickNavigationLink(QuickNavigationLink.OnlineFlyer);
                headerControl.VerifyQuickNavigationLink(QuickNavigationLink.LanguageAndCurrency);

                headerControl.VerifyUserNavigationLink(UserNavigationLink.WishList);
                headerControl.VerifyUserNavigationLink(UserNavigationLink.ShoppingCart);
                headerControl.VerifyUserNavigationLink(UserNavigationLink.MyAccount);
                headerControl.ClickUserButton();
                _hcaWebSite.LoginForm.WaitForPresentForm();
                _hcaWebSite.LoginForm.IsFormPresent();
                headerControl.ClickUserButton();
                _hcaWebSite.LoginForm.WaitForNotPresentForm();
                _hcaWebSite.LoginForm.VerifyFormNotPresent();

                _mainMenuControl.MenuContainerIsPresent();
                Assert.AreEqual(expMenuItemCounts, _mainMenuControl.MenuItemsCount,
                    $"Expected Menu Items count: {expMenuItemCounts}. Actual: {_mainMenuControl.MenuItemsCount}");

                CheckFullyMenuItem(MenuItem.Cameras, SubMenuItem.CameraAccessories,
                    SubMenuItem.Camcorders,
                    SubMenuItem.Drones,
                    SubMenuItem.PointAndShoot,
                    SubMenuItem.MirrorLessBundles,
                    SubMenuItem.New,
                    SubMenuItem.Promotions,
                    SubMenuItem.Blog);
                CheckFullyMenuItem(MenuItem.Computers, SubMenuItem.Desktops,
                    SubMenuItem.Laptops,
                    SubMenuItem.Tablets,
                    SubMenuItem.New,
                    SubMenuItem.Promotions,
                    SubMenuItem.Blog);
                CheckFullyMenuItem(MenuItem.HouseHold, SubMenuItem.Gaming,
                    SubMenuItem.HealthAndBeautyAndFitness,
                    SubMenuItem.HealthAndBeautyAndFitness,
                    SubMenuItem.HomeTheater,
                    SubMenuItem.New,
                    SubMenuItem.Promotions,
                    SubMenuItem.Blog);
                CheckFullyMenuItem(MenuItem.Multimedia, SubMenuItem.HomeAudio,
                    SubMenuItem.CarSpeakers,
                    SubMenuItem.Amplifiers,
                    SubMenuItem.HomeTheater,
                    SubMenuItem.New,
                    SubMenuItem.Promotions,
                    SubMenuItem.Blog);
                CheckFullyMenuItem(MenuItem.Phones, SubMenuItem.Phones,
                    SubMenuItem.Audio,
                    SubMenuItem.SmartPhoneCases,
                    SubMenuItem.New,
                    SubMenuItem.Promotions,
                    SubMenuItem.Blog);

                Assert.AreEqual("I'M LOOKING FOR...", headerControl.SearchFieldPlaceholderText);
                headerControl.SearchText("123");
                _hcaWebSite.SearchPage.WaitForOpened();
                _hcaWebSite.SearchPage.VerifyOpened();
            });
        }

        private void CheckFullyMenuItem(MenuItem menuItem, params SubMenuItem[] subMenuItems)
        {
            _mainMenuControl.VerifyMenuItem(menuItem);
            _mainMenuControl.MoveMouseTiMenuItem(menuItem);
            _mainMenuControl.TitleMenuItemIsPresent(_categoryTitle, menuItem);
            _mainMenuControl.TitleMenuItemIsPresent(_featuredTitle, menuItem);
            _mainMenuControl.VerifyMenuItemImage(menuItem);
            _mainMenuControl.VerifySubMenuItems(menuItem, subMenuItems);
        }
    }
}