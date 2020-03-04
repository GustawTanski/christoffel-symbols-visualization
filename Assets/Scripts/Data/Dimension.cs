using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Data {
    public enum Direction {
        zero,
        x,
        y,
        z
    }

    public class Dimension {
        public Direction Dir {
            get;
            private set;
        }

        public Vector3 DirVector {
            get {
                return vectorToDimension.FirstOrDefault(el => el.Value == Dir).Key;
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
            Dir = vectorToDimension.FirstOrDefault(el => el.Key == dirVector).Value;
        }

        public void SetDirection(Vector3 dirVector) {
            SetDirectionFromVector3(dirVector);
        }

        static public float GetProjection(Vector3 vector, Dimension dim) {
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

        static public int Project(Vector3Int vector, Dimension dim) {
            return (int) GetProjection((Vector3) vector, dim);
        }
    }
}