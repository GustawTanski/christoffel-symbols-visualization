using Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Cube {
    internal class ChristofellProvider {
        public SpaceTypeDictionary SpaceLatexDict {
            private get;
            set;
        }
        public SpaceType Space {
            private get;
            set;
        }

        public string[, , ] Tensor {
            get;
            private set;
        } = new string[4, 4, 4];

        public ChristofellProvider(SpaceTypeDictionary dict, SpaceType space) {
            SpaceLatexDict = dict;
            Space = space;
        }

        public void FetchTensor() {
            string json = SpaceLatexDict[Space].text;
            Tensor = JsonConvert.DeserializeObject<string[, , ]>(json);
        }
    }
}