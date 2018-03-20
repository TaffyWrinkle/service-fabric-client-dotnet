// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines matching criteria to determine whether a node should be included in the returned cluster health chunk.
    /// One filter can match zero, one or multiple nodes, depending on its properties.
    /// Can be specified in the cluster health chunk query description.
    /// </summary>
    public partial class NodeHealthStateFilter
    {
        /// <summary>
        /// Initializes a new instance of the NodeHealthStateFilter class.
        /// </summary>
        /// <param name="nodeNameFilter">Name of the node that matches the filter. The filter is applied only to the specified
        /// node, if it exists.
        /// If the node doesn't exist, no node is returned in the cluster health chunk based on this filter.
        /// If the node exists, it is included in the cluster health chunk if the health state matches the other filter
        /// properties.
        /// If not specified, all nodes that match the parent filters (if any) are taken into consideration and matched against
        /// the other filter members, like health state filter.
        /// </param>
        /// <param name="healthStateFilter">The filter for the health state of the nodes. It allows selecting nodes if they
        /// match the desired health states.
        /// The possible values are integer value of one of the following health states. Only nodes that match the filter are
        /// returned. All nodes are used to evaluate the cluster aggregated health state.
        /// If not specified, default value is None, unless the node name is specified. If the filter has default value and
        /// node name is specified, the matching node is returned.
        /// The state values are flag based enumeration, so the value could be a combination of these values obtained using
        /// bitwise 'OR' operator.
        /// For example, if the provided value is 6, it matches nodes with HealthState value of OK (2) and Warning (4).
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </param>
        public NodeHealthStateFilter(
            string nodeNameFilter = default(string),
            int? healthStateFilter = 0)
        {
            this.NodeNameFilter = nodeNameFilter;
            this.HealthStateFilter = healthStateFilter;
        }

        /// <summary>
        /// Gets name of the node that matches the filter. The filter is applied only to the specified node, if it exists.
        /// If the node doesn't exist, no node is returned in the cluster health chunk based on this filter.
        /// If the node exists, it is included in the cluster health chunk if the health state matches the other filter
        /// properties.
        /// If not specified, all nodes that match the parent filters (if any) are taken into consideration and matched against
        /// the other filter members, like health state filter.
        /// </summary>
        public string NodeNameFilter { get; }

        /// <summary>
        /// Gets the filter for the health state of the nodes. It allows selecting nodes if they match the desired health
        /// states.
        /// The possible values are integer value of one of the following health states. Only nodes that match the filter are
        /// returned. All nodes are used to evaluate the cluster aggregated health state.
        /// If not specified, default value is None, unless the node name is specified. If the filter has default value and
        /// node name is specified, the matching node is returned.
        /// The state values are flag based enumeration, so the value could be a combination of these values obtained using
        /// bitwise 'OR' operator.
        /// For example, if the provided value is 6, it matches nodes with HealthState value of OK (2) and Warning (4).
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </summary>
        public int? HealthStateFilter { get; }
    }
}
