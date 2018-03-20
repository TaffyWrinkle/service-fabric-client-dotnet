// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the health state chunk of a stateful service replica or a stateless service instance.
    /// The replica health state contains the replica ID and its aggregated health state.
    /// </summary>
    public partial class ReplicaHealthStateChunk : EntityHealthStateChunk
    {
        /// <summary>
        /// Initializes a new instance of the ReplicaHealthStateChunk class.
        /// </summary>
        /// <param name="healthState">The health state of a Service Fabric entity such as Cluster, Node, Application, Service,
        /// Partition, Replica etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'</param>
        /// <param name="replicaOrInstanceId">Id of a stateful service replica or a stateless service instance. This ID is used
        /// in the queries that apply to both stateful and stateless services. It is used by Service Fabric to uniquely
        /// identify a replica of a partition of a stateful service or an instance of a stateless service partition. It is
        /// unique within a partition and does not change for the lifetime of the replica or the instance. If a stateful
        /// replica gets dropped and another replica gets created on the same node for the same partition, it will get a
        /// different value for the ID. If a stateless instance is failed over on the same or different node it will get a
        /// different value for the ID.</param>
        public ReplicaHealthStateChunk(
            HealthState? healthState = default(HealthState?),
            string replicaOrInstanceId = default(string))
            : base(
                healthState)
        {
            this.ReplicaOrInstanceId = replicaOrInstanceId;
        }

        /// <summary>
        /// Gets id of a stateful service replica or a stateless service instance. This ID is used in the queries that apply to
        /// both stateful and stateless services. It is used by Service Fabric to uniquely identify a replica of a partition of
        /// a stateful service or an instance of a stateless service partition. It is unique within a partition and does not
        /// change for the lifetime of the replica or the instance. If a stateful replica gets dropped and another replica gets
        /// created on the same node for the same partition, it will get a different value for the ID. If a stateless instance
        /// is failed over on the same or different node it will get a different value for the ID.
        /// </summary>
        public string ReplicaOrInstanceId { get; }
    }
}
