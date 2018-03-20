// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Client.Http.Serialization;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Class containing methods for performing ServiceClient operataions.
    /// </summary>
    internal partial class ServiceClient : IServiceClient
    {
        private readonly ServiceFabricHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the ServiceClient class.
        /// </summary>
        /// <param name="httpClient">ServiceFabricHttpClient instance.</param>
        public ServiceClient(ServiceFabricHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<PagedData<ServiceInfo>> GetServiceInfoListAsync(
            ApplicationName applicationName,
            string serviceTypeName = default(string),
            ContinuationToken continuationToken = default(ContinuationToken),
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationName.ThrowIfNull(nameof(applicationName));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Applications/{applicationId}/$/GetServices";
            url = url.Replace("{applicationId}", applicationName.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serviceTypeName?.AddToQueryParameters(queryParams, $"ServiceTypeName={serviceTypeName}");
            continuationToken?.AddToQueryParameters(queryParams, $"ContinuationToken={continuationToken.ToString()}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponseAsPagedData(RequestFunc, url, ServiceInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ServiceInfo> GetServiceInfoAsync(
            ApplicationName applicationName,
            ServiceName serviceId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationName.ThrowIfNull(nameof(applicationName));
            serviceId.ThrowIfNull(nameof(serviceId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Applications/{applicationId}/$/GetServices/{serviceId}";
            url = url.Replace("{applicationId}", applicationName.GetId().ToString());
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ServiceInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApplicationNameInfo> GetApplicationNameInfoAsync(
            ServiceName serviceId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/GetApplicationName";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ApplicationNameInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task CreateServiceAsync(
            ApplicationName applicationName,
            ServiceDescription serviceDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationName.ThrowIfNull(nameof(applicationName));
            serviceDescription.ThrowIfNull(nameof(serviceDescription));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Applications/{applicationId}/$/GetServices/$/Create";
            url = url.Replace("{applicationId}", applicationName.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            string content;
            using (var sw = new StringWriter())
            {
                ServiceDescriptionConverter.Serialize(new JsonTextWriter(sw), serviceDescription);
                content = sw.ToString();
            }

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(content, Encoding.UTF8)
                };
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task CreateServiceFromTemplateAsync(
            ApplicationName applicationName,
            ServiceFromTemplateDescription serviceFromTemplateDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationName.ThrowIfNull(nameof(applicationName));
            serviceFromTemplateDescription.ThrowIfNull(nameof(serviceFromTemplateDescription));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Applications/{applicationId}/$/GetServices/$/CreateFromTemplate";
            url = url.Replace("{applicationId}", applicationName.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            string content;
            using (var sw = new StringWriter())
            {
                ServiceFromTemplateDescriptionConverter.Serialize(new JsonTextWriter(sw), serviceFromTemplateDescription);
                content = sw.ToString();
            }

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(content, Encoding.UTF8)
                };
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteServiceAsync(
            ServiceName serviceId,
            bool? forceRemove = default(bool?),
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/Delete";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            forceRemove?.AddToQueryParameters(queryParams, $"ForceRemove={forceRemove}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                };
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task UpdateServiceAsync(
            ServiceName serviceId,
            ServiceUpdateDescription serviceUpdateDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            serviceUpdateDescription.ThrowIfNull(nameof(serviceUpdateDescription));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/Update";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            string content;
            using (var sw = new StringWriter())
            {
                ServiceUpdateDescriptionConverter.Serialize(new JsonTextWriter(sw), serviceUpdateDescription);
                content = sw.ToString();
            }

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(content, Encoding.UTF8)
                };
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ServiceDescription> GetServiceDescriptionAsync(
            ServiceName serviceId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/GetDescription";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ServiceDescriptionConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ServiceHealth> GetServiceHealthAsync(
            ServiceName serviceId,
            int? eventsHealthStateFilter = 0,
            int? partitionsHealthStateFilter = 0,
            bool? excludeHealthStatistics = false,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/GetHealth";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            eventsHealthStateFilter?.AddToQueryParameters(queryParams, $"EventsHealthStateFilter={eventsHealthStateFilter}");
            partitionsHealthStateFilter?.AddToQueryParameters(queryParams, $"PartitionsHealthStateFilter={partitionsHealthStateFilter}");
            excludeHealthStatistics?.AddToQueryParameters(queryParams, $"ExcludeHealthStatistics={excludeHealthStatistics}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ServiceHealthConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ServiceHealth> GetServiceHealthUsingPolicyAsync(
            ServiceName serviceId,
            int? eventsHealthStateFilter = 0,
            int? partitionsHealthStateFilter = 0,
            ApplicationHealthPolicy applicationHealthPolicy = default(ApplicationHealthPolicy),
            bool? excludeHealthStatistics = false,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/GetHealth";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            eventsHealthStateFilter?.AddToQueryParameters(queryParams, $"EventsHealthStateFilter={eventsHealthStateFilter}");
            partitionsHealthStateFilter?.AddToQueryParameters(queryParams, $"PartitionsHealthStateFilter={partitionsHealthStateFilter}");
            excludeHealthStatistics?.AddToQueryParameters(queryParams, $"ExcludeHealthStatistics={excludeHealthStatistics}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            string content;
            using (var sw = new StringWriter())
            {
                ApplicationHealthPolicyConverter.Serialize(new JsonTextWriter(sw), applicationHealthPolicy);
                content = sw.ToString();
            }

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(content, Encoding.UTF8)
                };
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ServiceHealthConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task ReportServiceHealthAsync(
            ServiceName serviceId,
            HealthInformation healthInformation,
            bool? immediate = false,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            healthInformation.ThrowIfNull(nameof(healthInformation));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/ReportHealth";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            immediate?.AddToQueryParameters(queryParams, $"Immediate={immediate}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            string content;
            using (var sw = new StringWriter())
            {
                HealthInformationConverter.Serialize(new JsonTextWriter(sw), healthInformation);
                content = sw.ToString();
            }

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(content, Encoding.UTF8)
                };
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ResolvedServicePartition> ResolveServiceAsync(
            ServiceName serviceId,
            int? partitionKeyType = default(int?),
            string partitionKeyValue = default(string),
            string previousRspVersion = default(string),
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            serviceId.ThrowIfNull(nameof(serviceId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Services/{serviceId}/$/ResolvePartition";
            url = url.Replace("{serviceId}", serviceId.GetId().ToString());
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            partitionKeyType?.AddToQueryParameters(queryParams, $"PartitionKeyType={partitionKeyType}");
            partitionKeyValue?.AddToQueryParameters(queryParams, $"PartitionKeyValue={partitionKeyValue}");
            previousRspVersion?.AddToQueryParameters(queryParams, $"PreviousRspVersion={previousRspVersion}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ResolvedServicePartitionConverter.Deserialize, requestId, cancellationToken);
        }
    }
}
