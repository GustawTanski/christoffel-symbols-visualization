using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Data {
    public class Dimension {
        public Direction Dir {
            get;
            private set;
        }

        public Vector3 DirVector {
            get {
                if (vectorToDimension.ContainsValue(Dir))
                    return vectorToDimension.KeyByValue(Dir);
                else return Vector3.zero;
            }
        }

        private Dictionary<Vector3, Direction> vectorToDimension = new Dictionary<Vector3, Direction>() {
            [Vector3.right] = Direction.x, [Vector3.up] = Direction.y, [Vector3.forward] = Direction.z
        };

        public Dimension() {}
        public Dimension(Vector3 dirVector) {
            SetDirectionFromVector3(dirVector);
        }

        public Dimension(Direction dir) {
            Dir = dir;
        }

        private void SetDirectionFromVector3(Vector3 dirVector) {
            Dir = ConvertVector3ToDirection(dirVector);
        }

        private Direction ConvertVector3ToDirection(Vector3 dirVector) {
            foreach (Vector3 dimensionVector in vectorToDimension.Keys) {
                if ((dimensionVector - dirVector).magnitude < 0.01)
                    return vectorToDimension[dimensionVector];
            }
            return Direction.zero;
        }

        public void SetDirection(Vector3 dirVector) {
            SetDirectionFromVector3(dirVector);
        }

        static public int Project(Vector3Int vector, Dimension dim) {
            return (int) Project((Vector3) vector, dim);
        }

        static public float Project(Vector3 vector, Dimension dim) {
            switch (dim.Dir) {
                case Direction.x:
                    return vector.x;
                case Direction.y:
                    return vector.y;
                case Direction.z:
                    return vector.z;
                default:
                    return 0;
            }
        }
    }
}