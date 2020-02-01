using Data;
using Newtonsoft.Json;

namespace Cube {
    internal class ChristofellProvider {
        private SpaceTypeDictionary dict;
        private SpaceType space;

        public string[, , ] Tensor {
            get;
            private set;
        }

        public ChristofellProvider(SpaceTypeDictionary dict, SpaceType space) {
            Tensor = new string[4, 4, 4];
            this.dict = dict;
            this.space = space;
        }

        public void FetchTensor() {
            var textAsset = dict[space];
            string json = textAsset.text;
            Tensor = JsonConvert.DeserializeObject<string[, , ]>(json);
        }

        public void SetDictionary(SpaceTypeDictionary dict) {
            this.dict = dict;
        }

        public void SetSpace(SpaceType space) {
            this.space = space;
        }

    }
}