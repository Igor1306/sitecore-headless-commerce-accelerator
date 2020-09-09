﻿using System;
using System.Collections.Generic;
using System.Net;
using AutoTests.AutomationFramework.API.Models;
using AutoTests.AutomationFramework.Shared.Models;
using RestSharp;

namespace AutoTests.AutomationFramework.API.Services.RestService
{
    public interface IHttpClientService
    {
        Uri BaseUri { get; }

        void AddDefaultHeaders(Dictionary<string, string> headers);

        void SetCookieIfNotSet(CookieData cookie);

        void SetHttpBasicAuthenticator(string userName, string password);

        void SetTimeOut(int timeOut);

        TModel ExecuteJsonRequest<TModel, TData, TErrors>(Uri endpoint, Method method, object obj = null)
            where TData : class
            where TErrors : class
            where TModel : class, IResponse<TData, TErrors>, new();

        CookieCollection GetCookies();
    }
}