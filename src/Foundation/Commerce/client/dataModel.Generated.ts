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

// tslint:disable:indent array-type

    export interface AddressModel {
        address1: string;
        address2: string;
        city: string;
        country: string;
        countryCode: string;
        email: string;
        externalId: string;
        firstName: string;
        isPrimary: boolean;
        lastName: string;
        name: string;
        partyId: string;
        state: string;
        zipPostalCode: string;
    }
    export interface BaseCheckoutModel {
        userAddresses: AddressModel[];
    }
    export interface BillingModel extends BaseCheckoutModel {
        paymentClientToken: string;
        paymentMethods: PaymentMethodModel[];
        paymentOptions: PaymentOptionModel[];
    }
    export interface CartLineModel {
        id: string;
        price: CartPriceModel;
        product: ProductModel;
        quantity: number;
        variant: ProductVariantModel;
    }
    export interface CartModel {
        addresses: AddressModel[];
        adjustments: string[];
        cartLines: CartLineModel[];
        email: string;
        id: string;
        payments: FederatedPaymentModel[];
        price: CartPriceModel;
        shippings: ShippingMethodModel[];
    }
    export interface CartPriceModel {
        currencyCode: string;
        currencySymbol: string;
        handlingTotal: number;
        shippingTotal: number;
        subtotal: number;
        taxTotal: number;
        total: number;
        totalSavings: number;
    }
    export interface CategoryModel {
        childrenCategoryList: string[];
        description: string;
        displayName: string;
        name: string;
        parentCatalogList: string[];
        sitecoreId: string;
    }
    export interface CategorySearchInformation {
        itemsPerPage: number;
        requiredFacets: CommerceQueryFacet[];
        sortFields: CommerceQuerySort[];
    }
    export interface CommerceUserModel {
        contactId: string;
        customerId: string;
        email: string;
        firstName: string;
        lastName: string;
    }
    export interface CountryRegionModel {
        countryCode: string;
        name: string;
        subdivisions: SubdivisionModel[];
    }
    export interface DeliveryModel extends BaseCheckoutModel {
        newPartyId: string;
        shippingOptions: ShippingOptionModel[];
    }
    export interface FacetResultModel {
        displayName: string;
        foundValues: FacetValueResultModel[];
        name: string;
        values: any[];
    }
    export interface FacetValueResultModel {
        aggregateCount: number;
        name: string;
    }
    export interface FederatedPaymentModel {
        cardToken: string;
        partyID: string;
        paymentMethodId: string;
    }
    export interface GetShippingArgs {
        shippingAddress: AddressModel;
        shippingPreferenceType: string;
    }
    export interface OrderModel extends CartModel {
        status: string;
        trackingNumber: string;
    }
    export interface PaymentMethodModel {
        description: string;
        externalId: string;
    }
    export interface PaymentOptionModel {
        description: string;
        name: string;
        paymentOptionTypeName: string;
    }
    export interface ProductListResultModel {
        childProducts: ProductModel[];
        currentCatalogItemId: string;
        currentPageNumber: number;
        facets: FacetResultModel[];
        maxPageSize: number;
        searchKeyword: string;
        sortOptions: SortOptionModel[];
        totalItemCount: number;
        totalPageCount: number;
    }
    export interface ProductModel {
        adjustedPrice: number;
        brand: string;
        currencySymbol: string;
        customerAverageRating: number;
        description: string;
        displayName: string;
        imageUrls: string[];
        listPrice: number;
        productId: string;
        stockStatusName: string;
        tags: string[];
        variants: ProductVariantModel[];
    }
    export interface ProductVariantModel {
        adjustedPrice: number;
        brand: string;
        currencySymbol: string;
        customerAverageRating: number;
        description: string;
        displayName: string;
        imageUrls: string[];
        listPrice: number;
        productId: string;
        productVariantId: string;
        stockStatusName: string;
        tags: string[];
        variantProperties: { [key: string]: string };
    }
    export interface SetPaymentArgs {
        billingAddress: AddressModel;
        federatedPayment: FederatedPaymentModel;
    }
    export interface SetShippingArgs {
        orderShippingPreferenceType: string;
        shippingAddresses: AddressModel[];
        shippingMethods: ShippingMethodModel[];
    }
    export interface SetShippingModel {
        success: boolean;
    }
    export interface ShippingMethodModel {
        description: string;
        electronicDeliveryEmail: string;
        electronicDeliveryEmailContent: string;
        externalId: string;
        lineIds: string[];
        name: string;
        partyId: string;
        shippingOptionId: string;
        shippingPreferenceType: string;
        shopName: string;
    }
    export interface ShippingModel extends BaseCheckoutModel {
        shippingMethods: ShippingMethodModel[];
    }
    export interface ShippingOptionModel {
        description: string;
        name: string;
        shippingOptionType: number;
        shopName: string;
    }
    export interface SortOptionModel {
        displayName: string;
        isSelected: boolean;
        name: string;
        sortDirection: SortDirection;
    }
    export interface SubdivisionModel {
        code: string;
        name: string;
    }
    export interface SubmitOrderModel {
        confirmationId: string;
    }
    export interface VoidResult {
    }
    export interface CommerceQueryFacet {
        displayName: string;
        foundValues: FacetValue[];
        name: string;
        values: any[];
    }
    export interface CommerceQuerySort {
        displayName: string;
        name: string;
    }
    export interface FacetValue {
        aggregateCount: number;
        name: string;
    }
    export interface KeyValuePair<TKey, TValue> {
        key: TKey;
        value: TValue;
    }
    export interface OrderHistoryResultModel {
        currentPageNumber: number;
        orders: CartModel[];
    }
    export interface UserLoginModel {
        email: string;
        password: string;
    }
    export interface ValidateCredentialsResultModel {
        hasValidCredentials: boolean;
    }
    export interface ChangePasswordModel {
        email: string;
        newPassword: string;
        oldPassword: string;
    }
    export interface ChangePasswordResultModel {
        passwordChanged: boolean;
    }
    export interface CreateAccountModel {
        email: string;
        firstName: string;
        lastName: string;
        password: string;
    }
    export interface CreateAccountResultModel {
        accountInfo: CommerceUserModel;
        created: boolean;
        message: string;
    }
    export interface ValidateAccountModel {
        email: string;
    }
    export interface ValidateAccountResultModel {
        email: string;
        inUse: boolean;
        invalid: boolean;
    }
    export const enum SortDirection {
        Asc = 0,
        Desc = 1
    }
