using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Data {
    public class TensorProperties {
        [JsonIgnore]
        static public Dictionary<TensorProperties.Index.IndexPosition, string> positionToLaTeX = new Dictionary<TensorProperties.Index.IndexPosition, string> {
            [TensorProperties.Index.IndexPosition.up] = "^",
            [TensorProperties.Index.IndexPosition.down] = "_"
        };
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("data", Required = Required.Always)]
        public string[, , ] Data { get; set; }

        [JsonProperty("indexes", Required = Required.Always)]
        public Index[] Indexes { get; set; }

        [JsonProperty("symbol", Required = Required.Always)]
        public string Symbol { get; set; }

        [JsonProperty("parameters")]
        public LaTeXCharacter[] Parameters { get; set; } = new LaTeXCharacter[0];

        [JsonProperty("coordinates", Required = Required.Always)]
        public LaTeXCharacter[] Coordinates { get; set; }

        [JsonProperty("metric")]
        public string[,] Metric { get; set; } = new string[0,0];

        [JsonProperty("description")]
        public string Description { get; set; } = "";

        [JsonProperty("wikipedia-path")]
        public string WikipediaPath { get; set; } = "";

        public class LaTeXCharacter {
            [JsonProperty("char", Required = Required.Always)]
            public string LaTeX { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; } = "";
            [JsonProperty("color")]
            public string Color { get; set; } = "#ffffff";

            [JsonProperty("isLaTeXDescription")]
            public bool IsLaTeXDescription { get; set; } = false;
        }

        public class Index : LaTeXCharacter {
            [JsonProperty("position", Required = Required.Always)]
            [JsonConverter(typeof(StringEnumConverter))]
            public IndexPosition Position { get; set; }
            public enum IndexPosition {
                up = 1,
                down = -1
            }
        }
    }

}