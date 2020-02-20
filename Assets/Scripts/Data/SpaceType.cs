using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Data {
    public enum SpaceType {
        Minkowski,
        Schwarzschild,
        AdsSchwarzschild,
        Kerr
    }

    [Serializable]
    public class SpaceTypeDictionary : SerializableDictionaryBase<SpaceType, TextAsset> {}
}