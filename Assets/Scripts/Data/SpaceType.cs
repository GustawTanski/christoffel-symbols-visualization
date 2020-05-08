using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Data {
    public enum SpaceType {
        Minkowski,
        Schwarzschild,
        AdsSchwarzschild,
        Kerr,
        Friedman_Robertson_Walker,
    }

    [Serializable]
    public class SpaceTypeDictionary : SerializableDictionaryBase<SpaceType, TextAsset> {}
}