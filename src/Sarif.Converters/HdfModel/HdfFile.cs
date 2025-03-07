﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

using Newtonsoft.Json;

namespace Microsoft.CodeAnalysis.Sarif.Converters.HdfModel
{
    // <auto-generated />
    // To parse this JSON data use var hdfFile = HdfFile.FromJson(jsonString)
    public partial class HdfFile
    {
        [JsonProperty("platform", Required = Required.Always)]
        public Platform Platform { get; set; }

        [JsonProperty("profiles", Required = Required.Always)]
        public List<ExecJsonProfile> Profiles { get; set; }

        [JsonProperty("statistics", Required = Required.Always)]
        public Statistics Statistics { get; set; }

        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }

        public static HdfFile FromJson(string json) => JsonConvert.DeserializeObject<HdfFile>(json, Converter.Settings);
    }
}
