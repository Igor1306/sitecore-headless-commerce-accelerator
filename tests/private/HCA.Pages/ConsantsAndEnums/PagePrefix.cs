﻿using System.Runtime.Serialization;
using UIAutomationFramework.Utils;

namespace HCA.Pages.ConsantsAndEnums
{
    public enum PagePrefix
    {
        [EnumMember(Value = "")]
        Home,

        [EnumMember(Value = "Search")]
        Search,

        [EnumMember(Value = "Cart")]
        Cart,

        [EnumMember(Value = "Shop")]
        Shop,

        [EnumMember(Value = "Shop/Phone")]
        PhoneShop,

        [EnumMember(Value = "Product")]
        Product,

        [EnumMember(Value = "Checkout/Shipping")]
        CheckoutShipping,

        [EnumMember(Value = "Checkout/Billing")]
        CheckoutBilling,

        [EnumMember(Value = "Checkout/Payment")]
        CheckoutPayment,

        [EnumMember(Value = "Checkout/Confirmation")]
        CheckoutConfirmation,

        [EnumMember(Value = "Account")]
        Account,

        [EnumMember(Value = "Account/Sign-up")]
        AccountSignUp,

        [EnumMember(Value = "Account/Order-history")]
        AccountOrderHistory,
    }

    public static class PagePrefixExtensions
    {
        public static string GetPrefix(this PagePrefix prefix) => 
            prefix.GetAttribute<EnumMemberAttribute>().Value;
    }
}