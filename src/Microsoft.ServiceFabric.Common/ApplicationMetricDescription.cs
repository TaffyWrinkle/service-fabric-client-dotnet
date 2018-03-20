// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes capacity information for a custom resource balancing metric. This can be used to limit the total
    /// consumption of this metric by the services of this application.
    /// </summary>
    public partial class ApplicationMetricDescription
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationMetricDescription class.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="maximumCapacity">The maximum node capacity for Service Fabric application.
        /// This is the maximum Load for an instance of this application on a single node. Even if the capacity of node is
        /// greater than this value, Service Fabric will limit the total load of services within the application on each node
        /// to this value.
        /// If set to zero, capacity for this metric is unlimited on each node.
        /// When creating a new application with application capacity defined, the product of MaximumNodes and this value must
        /// always be smaller than or equal to TotalApplicationCapacity.
        /// When updating existing application with application capacity, the product of MaximumNodes and this value must
        /// always be smaller than or equal to TotalApplicationCapacity.
        /// </param>
        /// <param name="reservationCapacity">The node reservation capacity for Service Fabric application.
        /// This is the amount of load which is reserved on nodes which have instances of this application.
        /// If MinimumNodes is specified, then the product of these values will be the capacity reserved in the cluster for the
        /// application.
        /// If set to zero, no capacity is reserved for this metric.
        /// When setting application capacity or when updating application capacity; this value must be smaller than or equal
        /// to MaximumCapacity for each metric.
        /// </param>
        /// <param name="totalApplicationCapacity">The total metric capacity for Service Fabric application.
        /// This is the total metric capacity for this application in the cluster. Service Fabric will try to limit the sum of
        /// loads of services within the application to this value.
        /// When creating a new application with application capacity defined, the product of MaximumNodes and MaximumCapacity
        /// must always be smaller than or equal to this value.
        /// </param>
        public ApplicationMetricDescription(
            string name = default(string),
            long? maximumCapacity = default(long?),
            long? reservationCapacity = default(long?),
            long? totalApplicationCapacity = default(long?))
        {
            this.Name = name;
            this.MaximumCapacity = maximumCapacity;
            this.ReservationCapacity = reservationCapacity;
            this.TotalApplicationCapacity = totalApplicationCapacity;
        }

        /// <summary>
        /// Gets the name of the metric.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the maximum node capacity for Service Fabric application.
        /// This is the maximum Load for an instance of this application on a single node. Even if the capacity of node is
        /// greater than this value, Service Fabric will limit the total load of services within the application on each node
        /// to this value.
        /// If set to zero, capacity for this metric is unlimited on each node.
        /// When creating a new application with application capacity defined, the product of MaximumNodes and this value must
        /// always be smaller than or equal to TotalApplicationCapacity.
        /// When updating existing application with application capacity, the product of MaximumNodes and this value must
        /// always be smaller than or equal to TotalApplicationCapacity.
        /// </summary>
        public long? MaximumCapacity { get; }

        /// <summary>
        /// Gets the node reservation capacity for Service Fabric application.
        /// This is the amount of load which is reserved on nodes which have instances of this application.
        /// If MinimumNodes is specified, then the product of these values will be the capacity reserved in the cluster for the
        /// application.
        /// If set to zero, no capacity is reserved for this metric.
        /// When setting application capacity or when updating application capacity; this value must be smaller than or equal
        /// to MaximumCapacity for each metric.
        /// </summary>
        public long? ReservationCapacity { get; }

        /// <summary>
        /// Gets the total metric capacity for Service Fabric application.
        /// This is the total metric capacity for this application in the cluster. Service Fabric will try to limit the sum of
        /// loads of services within the application to this value.
        /// When creating a new application with application capacity defined, the product of MaximumNodes and MaximumCapacity
        /// must always be smaller than or equal to this value.
        /// </summary>
        public long? TotalApplicationCapacity { get; }
    }
}
