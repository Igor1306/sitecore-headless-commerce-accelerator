﻿using Newtonsoft.Json;

namespace HCA.Api.Core.Models.Braitree.PaymentToken.Request
{
    public class CreditCardRequest
    {
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "expirationMonth")]
        public string ExpirationMonth { get; set; }

        [JsonProperty(PropertyName = "expirationYear")]
        public string ExpirationYear { get; set; }

        [JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }
    }
}
