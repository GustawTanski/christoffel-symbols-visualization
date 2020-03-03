using System.Collections.Generic;
using UnityEngine;
namespace Data {
    static class DimensionDictionaries {
        static public Dictionary<Vector3, Dimension> vectorToDimension = new Dictionary<Vector3, Dimension>() {
            [Vector3.right] = Dimension.x, 
            [Vector3.up] = Dimension.y, 
            [Vector3.forward] = Dimension.z
        };
        
        static DimensionDictionaries () {
        }
    }
}