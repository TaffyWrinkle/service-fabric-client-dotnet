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
    /// Converter for <see cref="BackupEntityKind" />.
    /// </summary>
    internal class BackupEntityKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static BackupEntityKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(BackupEntityKind);

            if (string.Compare(value, "Invalid", StringComparison.Ordinal) == 0)
            {
                obj = BackupEntityKind.Invalid;
            }
            else if (string.Compare(value, "Partition", StringComparison.Ordinal) == 0)
            {
                obj = BackupEntityKind.Partition;
            }
            else if (string.Compare(value, "Service", StringComparison.Ordinal) == 0)
            {
                obj = BackupEntityKind.Service;
            }
            else if (string.Compare(value, "Application", StringComparison.Ordinal) == 0)
            {
                obj = BackupEntityKind.Application;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, BackupEntityKind? value)
        {
            switch (value)
            {
                case BackupEntityKind.Invalid:
                    writer.WriteStringValue("Invalid");
                    break;
                case BackupEntityKind.Partition:
                    writer.WriteStringValue("Partition");
                    break;
                case BackupEntityKind.Service:
                    writer.WriteStringValue("Service");
                    break;
                case BackupEntityKind.Application:
                    writer.WriteStringValue("Application");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type BackupEntityKind");
            }
        }
    }
}
