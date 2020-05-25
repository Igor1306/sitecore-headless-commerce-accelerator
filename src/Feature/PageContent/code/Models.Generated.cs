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

#pragma warning disable 1591
#pragma warning disable 0108
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Rainbow JS CodeGeneration.
//     (https://github.com/asmagin/rainbow-js-codegeneration)
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCA.Feature.PageContent.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Fields;
    using Sitecore.Globalization;
    using Sitecore.Data;
    using Sitecore.Data.Items;

    using System.CodeDom.Compiler;
    using HCA.Foundation.GlassMapper.Models;


    /// <summary>
    /// IBanner Interface
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Banner/Banner</para>
    /// <para>ID: aca0aaff-3317-4535-8bc5-504256e08255</para>
    /// </summary>
    [SitecoreType(TemplateId="aca0aaff-3317-4535-8bc5-504256e08255")]
    public partial interface IBanner: IGlassBase
    {

        /// <summary>
        /// The Button Text field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: 42ec7cba-9200-49fe-b5f1-03824e1dc337</para>
        /// </summary>
        [SitecoreField("Button Text")]
        string ButtonText {get; set;}

        /// <summary>
        /// The Image field.
        /// <para>Field Type: Image</para>
        /// <para>Field ID: cfb54c8b-6f8e-4bdb-9a07-7df0871196c7</para>
        /// </summary>
        [SitecoreField("Image")]
        Image Image {get; set;}

        /// <summary>
        /// The Link field.
        /// <para>Field Type: General Link</para>
        /// <para>Field ID: ed641b03-6844-4ad0-ae83-ba9d351a2660</para>
        /// </summary>
        [SitecoreField("Link")]
        Link Link {get; set;}

    }


    /// <summary>
    /// Banner Class
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Banner/Banner</para>
    /// <para>ID: aca0aaff-3317-4535-8bc5-504256e08255</para>
    /// </summary>
    [SitecoreType(TemplateId="aca0aaff-3317-4535-8bc5-504256e08255")]
    public partial class Banner: GlassBase, IBanner
    {
        /// <summary>
        /// The TemplateId string for /sitecore/templates/HCA/Feature/PageContent/Banner/Banner
        /// </summary>
        public const string TemplateId = "aca0aaff-3317-4535-8bc5-504256e08255";

        /// <summary>
        /// The Button Text field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: 42ec7cba-9200-49fe-b5f1-03824e1dc337</para>
        /// </summary>
        [SitecoreField("Button Text")]
        public virtual string ButtonText {get; set;}
        public const string ButtonTextFieldId = "42ec7cba-9200-49fe-b5f1-03824e1dc337";
        public const string ButtonTextFieldName = "Button Text";

        /// <summary>
        /// The Image field.
        /// <para>Field Type: Image</para>
        /// <para>Field ID: cfb54c8b-6f8e-4bdb-9a07-7df0871196c7</para>
        /// </summary>
        [SitecoreField("Image")]
        public virtual Image Image {get; set;}
        public const string ImageFieldId = "cfb54c8b-6f8e-4bdb-9a07-7df0871196c7";
        public const string ImageFieldName = "Image";

        /// <summary>
        /// The Link field.
        /// <para>Field Type: General Link</para>
        /// <para>Field ID: ed641b03-6844-4ad0-ae83-ba9d351a2660</para>
        /// </summary>
        [SitecoreField("Link")]
        public virtual Link Link {get; set;}
        public const string LinkFieldId = "ed641b03-6844-4ad0-ae83-ba9d351a2660";
        public const string LinkFieldName = "Link";

    }


    /// <summary>
    /// IBannerFolder Interface
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Banner/Banner Folder</para>
    /// <para>ID: 60d1329d-bfbf-4c2a-a6be-426f1c700ba9</para>
    /// </summary>
    [SitecoreType(TemplateId="60d1329d-bfbf-4c2a-a6be-426f1c700ba9")]
    public partial interface IBannerFolder: IGlassBase
    {

    }


    /// <summary>
    /// BannerFolder Class
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Banner/Banner Folder</para>
    /// <para>ID: 60d1329d-bfbf-4c2a-a6be-426f1c700ba9</para>
    /// </summary>
    [SitecoreType(TemplateId="60d1329d-bfbf-4c2a-a6be-426f1c700ba9")]
    public partial class BannerFolder: GlassBase, IBannerFolder
    {
        /// <summary>
        /// The TemplateId string for /sitecore/templates/HCA/Feature/PageContent/Banner/Banner Folder
        /// </summary>
        public const string TemplateId = "60d1329d-bfbf-4c2a-a6be-426f1c700ba9";

    }


    /// <summary>
    /// IGridLayout Interface
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Rendering Parameters/Grid Layout</para>
    /// <para>ID: 61ed6a03-bbdb-4937-87fa-db5c53fc870c</para>
    /// </summary>
    [SitecoreType(TemplateId="61ed6a03-bbdb-4937-87fa-db5c53fc870c")]
    public partial interface IGridLayout: IGlassBase
    {

        /// <summary>
        /// The First Column Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: a10a1cf0-25e7-4b9f-a9ac-6d40de3cbe88</para>
        /// </summary>
        [SitecoreField("First Column Class")]
        string FirstColumnClass {get; set;}

        /// <summary>
        /// The Second Column Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: 525bb442-fc9e-49dd-b557-52b833f0855d</para>
        /// </summary>
        [SitecoreField("Second Column Class")]
        string SecondColumnClass {get; set;}

        /// <summary>
        /// The Third Column Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: bfed443f-3ac3-460d-be12-5759b8294233</para>
        /// </summary>
        [SitecoreField("Third Column Class")]
        string ThirdColumnClass {get; set;}

        /// <summary>
        /// The Wrapper Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: b4386ac8-1f1b-49f3-adcb-264f5f595e52</para>
        /// </summary>
        [SitecoreField("Wrapper Class")]
        string WrapperClass {get; set;}

    }


    /// <summary>
    /// GridLayout Class
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Rendering Parameters/Grid Layout</para>
    /// <para>ID: 61ed6a03-bbdb-4937-87fa-db5c53fc870c</para>
    /// </summary>
    [SitecoreType(TemplateId="61ed6a03-bbdb-4937-87fa-db5c53fc870c")]
    public partial class GridLayout: GlassBase, IGridLayout
    {
        /// <summary>
        /// The TemplateId string for /sitecore/templates/HCA/Feature/PageContent/Rendering Parameters/Grid Layout
        /// </summary>
        public const string TemplateId = "61ed6a03-bbdb-4937-87fa-db5c53fc870c";

        /// <summary>
        /// The First Column Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: a10a1cf0-25e7-4b9f-a9ac-6d40de3cbe88</para>
        /// </summary>
        [SitecoreField("First Column Class")]
        public virtual string FirstColumnClass {get; set;}
        public const string FirstColumnClassFieldId = "a10a1cf0-25e7-4b9f-a9ac-6d40de3cbe88";
        public const string FirstColumnClassFieldName = "First Column Class";

        /// <summary>
        /// The Second Column Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: 525bb442-fc9e-49dd-b557-52b833f0855d</para>
        /// </summary>
        [SitecoreField("Second Column Class")]
        public virtual string SecondColumnClass {get; set;}
        public const string SecondColumnClassFieldId = "525bb442-fc9e-49dd-b557-52b833f0855d";
        public const string SecondColumnClassFieldName = "Second Column Class";

        /// <summary>
        /// The Third Column Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: bfed443f-3ac3-460d-be12-5759b8294233</para>
        /// </summary>
        [SitecoreField("Third Column Class")]
        public virtual string ThirdColumnClass {get; set;}
        public const string ThirdColumnClassFieldId = "bfed443f-3ac3-460d-be12-5759b8294233";
        public const string ThirdColumnClassFieldName = "Third Column Class";

        /// <summary>
        /// The Wrapper Class field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: b4386ac8-1f1b-49f3-adcb-264f5f595e52</para>
        /// </summary>
        [SitecoreField("Wrapper Class")]
        public virtual string WrapperClass {get; set;}
        public const string WrapperClassFieldId = "b4386ac8-1f1b-49f3-adcb-264f5f595e52";
        public const string WrapperClassFieldName = "Wrapper Class";

    }


    /// <summary>
    /// IRecommendedProducts Interface
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Recommended Products/Recommended Products</para>
    /// <para>ID: 02303189-7dc9-41c9-914a-4784878a6a7d</para>
    /// </summary>
    [SitecoreType(TemplateId="02303189-7dc9-41c9-914a-4784878a6a7d")]
    public partial interface IRecommendedProducts: IGlassBase
    {

        /// <summary>
        /// The Header field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: ba9cd774-93ea-490e-b978-38efe2c648ed</para>
        /// </summary>
        [SitecoreField("Header")]
        string Header {get; set;}

    }


    /// <summary>
    /// RecommendedProducts Class
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Recommended Products/Recommended Products</para>
    /// <para>ID: 02303189-7dc9-41c9-914a-4784878a6a7d</para>
    /// </summary>
    [SitecoreType(TemplateId="02303189-7dc9-41c9-914a-4784878a6a7d")]
    public partial class RecommendedProducts: GlassBase, IRecommendedProducts
    {
        /// <summary>
        /// The TemplateId string for /sitecore/templates/HCA/Feature/PageContent/Recommended Products/Recommended Products
        /// </summary>
        public const string TemplateId = "02303189-7dc9-41c9-914a-4784878a6a7d";

        /// <summary>
        /// The Header field.
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Field ID: ba9cd774-93ea-490e-b978-38efe2c648ed</para>
        /// </summary>
        [SitecoreField("Header")]
        public virtual string Header {get; set;}
        public const string HeaderFieldId = "ba9cd774-93ea-490e-b978-38efe2c648ed";
        public const string HeaderFieldName = "Header";

    }


    /// <summary>
    /// IRecommendedProductsFolder Interface
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Recommended Products/Recommended Products Folder</para>
    /// <para>ID: 2ef7b0f6-a5e5-43e6-acec-0f1c2eed1731</para>
    /// </summary>
    [SitecoreType(TemplateId="2ef7b0f6-a5e5-43e6-acec-0f1c2eed1731")]
    public partial interface IRecommendedProductsFolder: IGlassBase
    {

    }


    /// <summary>
    /// RecommendedProductsFolder Class
    /// <para>Path: /sitecore/templates/HCA/Feature/PageContent/Recommended Products/Recommended Products Folder</para>
    /// <para>ID: 2ef7b0f6-a5e5-43e6-acec-0f1c2eed1731</para>
    /// </summary>
    [SitecoreType(TemplateId="2ef7b0f6-a5e5-43e6-acec-0f1c2eed1731")]
    public partial class RecommendedProductsFolder: GlassBase, IRecommendedProductsFolder
    {
        /// <summary>
        /// The TemplateId string for /sitecore/templates/HCA/Feature/PageContent/Recommended Products/Recommended Products Folder
        /// </summary>
        public const string TemplateId = "2ef7b0f6-a5e5-43e6-acec-0f1c2eed1731";

    }

}