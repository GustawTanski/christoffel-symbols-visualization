using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Data {
    public class Dimension {

        private const float MINIMAL_DIFFERENCE_MAGNITUDE = 0.1f;
        public Direction Dir {
            get;
            private set;
        }

        public Vector3 DirVector => ConverDirectionToVector(Dir);

        private Vector3 ConverDirectionToVector(Direction dir) {
            if (vectorToDirection.ContainsValue(dir))
                return vectorToDirection.KeyByValue(dir);
            else return Vector3.zero;
        }

        static private Dictionary<Vector3, Direction> vectorToDirection = new Dictionary<Vector3, Direction>() {
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

        static private Direction ConvertVector3ToDirection(Vector3 dirVector) {
            return vectorToDirection
                .FirstOrDefault(keyValuePair => AreVectorsAlmostEqual(keyValuePair.Key, dirVector))
                .Value;
        }

        static private bool AreVectorsAlmostEqual(Vector3 first, Vector3 second) {
            return (first - second).magnitude < MINIMAL_DIFFERENCE_MAGNITUDE;
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