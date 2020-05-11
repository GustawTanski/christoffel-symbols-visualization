using System;
using UnityEngine;
namespace Data {
    public class ResourceDataSystem : IDataLoadAndSaveSystem {
        public TextAsset[] LoadAll() {
            return Resources.LoadAll<TextAsset>("Data");
        }
        public TextAsset Load(string name) {
            return Resources.Load<TextAsset>($"Data/{name}");
        }
        public void Save(TextAsset asset) {
            throw new NotImplementedException();
        }
        public void Delete(string name) {
            throw new NotImplementedException();
        }
    }
}