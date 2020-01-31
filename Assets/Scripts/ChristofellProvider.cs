using Newtonsoft.Json;
using UnityEngine;

namespace Data {
    public class ChristofellProvider : MonoBehaviour {
        public SpaceTypeDictionary dict;
        public SpaceType space;

        private string[, , ] tensor = new string[4, 4, 4];
        private Matrix3D matrix;

        public string[, , ] Tensor {
            get {
                return tensor;
            }
            private set {
                tensor = value;
            }
        }

        private void Start() {
            matrix = GetComponent<Matrix3D>();
            GetTensor();
            matrix.InitializeElements();
        }

        public void GetTensor() {
            var textAsset = dict[space];
            string json = textAsset.text;
            Tensor = JsonConvert.DeserializeObject<string[, , ]>(json);
        }

    }
}