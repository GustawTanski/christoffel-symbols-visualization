using UnityEngine;
namespace Data {
    interface IDataLoadAndSaveSystem {
        TextAsset[] LoadAll();
        TextAsset Load(string name);
        void Save(TextAsset asset);
        void Delete(string name);

    }
}