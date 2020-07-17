﻿using Newtonsoft.Json;

namespace HCA.Api.Core.Models.Braitree.PaymentToken.Request
{
    public class PaymentRequest
    {
        [JsonProperty("clientSdkMetaData")]
        public ClientSdkMetaData ClientSdkMetaData { get; set; }

        [JsonProperty("operationName")]
        public string OperationName { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("variables")]
        public Variables Variables { get; set; }
    }
}