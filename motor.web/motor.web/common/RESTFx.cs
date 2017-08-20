using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Configuration;
using motor.logic.common;
using motor.logic.model;
using System.Data.Entity;

namespace motor.web.common
{
    interface IRESTFx<T>
    {
        IRestResponse<T> DoRequest(Method method, string resource, object data, string authenticationToken);
    }

    public class RESTFx
    {
        RestClient client = new RestClient(ConfigurationManager.AppSettings["motorHostServiceAddress"]); //base request url
        public IRestResponse DoRequest(Method method, string resource, object data, string authenticationToken)
        {
            RestRequest request = PrepareRequest(method, resource, data, authenticationToken);

            return client.Execute(request);
        }
        public static RestRequest PrepareRequest(Method method, string resource, object data, string authenticationToken)
        {
            RestRequest request = new RestRequest(resource, method);
            request.AddJsonBody(data);
            request.AddHeader("authToken", authenticationToken);
            return request;
        }

    }

    public class PaymentCardsRESTFx : IRESTFx<PaymentCardResponse>
    {
        RestClient client = new RestClient(ConfigurationManager.AppSettings["motorHostServiceAddress"]); //base request url
        public IRestResponse<PaymentCardResponse> DoRequest(Method method, string resource, object data, string authenticationToken)
        {
            RestRequest request = RESTFx.PrepareRequest(method, resource, data, authenticationToken);

            return client.Execute<PaymentCardResponse>(request);
        }

        
    }
}