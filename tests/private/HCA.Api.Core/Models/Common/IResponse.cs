﻿namespace HCA.Api.Core.Models.Common
{
    public interface IResponse<TData, TErrors>
        where TData : class
        where TErrors : class
    {
        bool IsSuccessful { get; set; }

        TData OkResponseData { get; set; }

        TErrors Errors { get; set; }
    }
}
