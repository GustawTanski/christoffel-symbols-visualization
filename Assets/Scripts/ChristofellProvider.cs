using Newtonsoft.Json;
using UnityEngine;

namespace Data {
    public class ChristofellProvider : MonoBehaviour {
        public SpaceTypeDictionary dict;
        public SpaceType space;

        public string[, , ] Tensor {
            get;
            private set;
        }

        private void Start() {
            GetTensor();
        }

        public void GetTensor() {
            var textAsset = dict[space];
            string json = textAsset.text;
            Tensor = JsonConvert.DeserializeObject<string[, , ]>(json);
        }

        private void OnValidate() {
            GetTensor();
        }
    }
}