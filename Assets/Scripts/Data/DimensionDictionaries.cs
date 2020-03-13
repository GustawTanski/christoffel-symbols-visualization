using System.Collections.Generic;
using UnityEngine;
namespace Data {
    static class DimensionDictionaries {
        static public Dictionary<Vector3, Direction> vectorToDimension = new Dictionary<Vector3, Direction>() {
            [Vector3.right] = Direction.x, 
            [Vector3.up] = Direction.y, 
            [Vector3.forward] = Direction.z
        };
        
        static DimensionDictionaries () {
        }
    }
}