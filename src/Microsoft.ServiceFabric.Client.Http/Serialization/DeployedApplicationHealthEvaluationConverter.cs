// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="DeployedApplicationHealthEvaluation" />.
    /// </summary>
    internal class DeployedApplicationHealthEvaluationConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static DeployedApplicationHealthEvaluation Deserialize(JsonReader reader)
        {
            reader.ReadStartObject();
            var obj = GetFromJsonProperties(reader);
            reader.ReadEndObject();
            return obj;
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static DeployedApplicationHealthEvaluation GetFromJsonProperties(JsonReader reader)
        {
            var aggregatedHealthState = default(HealthState?);
            var description = default(string);
            var nodeName = default(NodeName);
            var applicationName = default(ApplicationName);
            var unhealthyEvaluations = default(IEnumerable<HealthEvaluationWrapper>);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("AggregatedHealthState", propName, StringComparison.Ordinal) == 0)
                {
                    aggregatedHealthState = HealthStateConverter.Deserialize(reader);
                }
                else if (string.Compare("Description", propName, StringComparison.Ordinal) == 0)
                {
                    description = reader.ReadValueAsString();
                }
                else if (string.Compare("NodeName", propName, StringComparison.Ordinal) == 0)
                {
                    nodeName = NodeNameConverter.Deserialize(reader);
                }
                else if (string.Compare("ApplicationName", propName, StringComparison.Ordinal) == 0)
                {
                    applicationName = ApplicationNameConverter.Deserialize(reader);
                }
                else if (string.Compare("UnhealthyEvaluations", propName, StringComparison.Ordinal) == 0)
                {
                    unhealthyEvaluations = reader.ReadList(HealthEvaluationWrapperConverter.Deserialize);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new DeployedApplicationHealthEvaluation(
                aggregatedHealthState: aggregatedHealthState,
                description: description,
                nodeName: nodeName,
                applicationName: applicationName,
                unhealthyEvaluations: unhealthyEvaluations);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, DeployedApplicationHealthEvaluation obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.AggregatedHealthState, "AggregatedHealthState", HealthStateConverter.Serialize);
            if (obj.Description != null)
            {
                writer.WriteProperty(obj.Description, "Description", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.NodeName != null)
            {
                writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            }

            if (obj.ApplicationName != null)
            {
                writer.WriteProperty(obj.ApplicationName, "ApplicationName", ApplicationNameConverter.Serialize);
            }

            if (obj.UnhealthyEvaluations != null)
            {
                writer.WriteEnumerableProperty(obj.UnhealthyEvaluations, "UnhealthyEvaluations", HealthEvaluationWrapperConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
