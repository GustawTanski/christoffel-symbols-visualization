using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Data {
    public enum SpaceType {
        PlainSpace,
        Blackhole
    }

    [Serializable]
    public class SpaceTypeDictionary : SerializableDictionaryBase<SpaceType, TextAsset> {}
}