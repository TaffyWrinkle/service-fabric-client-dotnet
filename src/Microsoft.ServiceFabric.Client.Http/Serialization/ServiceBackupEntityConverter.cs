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
    /// Converter for <see cref="ServiceBackupEntity" />.
    /// </summary>
    internal class ServiceBackupEntityConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceBackupEntity Deserialize(JsonReader reader)
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
        internal static ServiceBackupEntity GetFromJsonProperties(JsonReader reader)
        {
            var serviceName = default(ServiceName);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("ServiceName", propName, StringComparison.Ordinal) == 0)
                {
                    serviceName = ServiceNameConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ServiceBackupEntity(
                serviceName: serviceName);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ServiceBackupEntity obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.EntityKind.ToString(), "EntityKind", JsonWriterExtensions.WriteStringValue);
            if (obj.ServiceName != null)
            {
                writer.WriteProperty(obj.ServiceName, "ServiceName", ServiceNameConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
