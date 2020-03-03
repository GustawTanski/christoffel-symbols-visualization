using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
namespace BetterMultidimensionalArray {
    static class MultidimensionalArrayExtension {
        static public void ForEach<T>(this T[, , ] array, Action<T, int, int, int> action) {
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    for (int k = 0; k < array.GetLength(2); k++) {
                        action(array[i, j, k], i, j, k);
                    }
                }
            }
        }
        static public void ForEach<T>(this T[, , ] array, Action<T> action) {
            array.ForEach((element, i, j, k) => action(element));
        }

        static public void ForEach<T>(this T[, , ] array, Action action) {
            array.ForEach((_, i, j, k) => action());
        }

        static public S[, , ] Select<T, S>(this T[, , ] array, Func<T, int, int, int, S> function) {
            S[, , ] newArray = new S[array.GetLength(0), array.GetLength(1), array.GetLength(2)];
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    for (int k = 0; k < array.GetLength(2); k++) {
                        newArray[i, j, k] = function(array[i, j, k], i, j, k);
                    }
                }
            }
            return newArray;
        }

        static public S[, , ] Select<T, S>(this T[, , ] array, Func<T, S> function) {
            return array.Select((element, i, j, k) => function(element));
        }

        static public S[, , ] Select<T, S>(this T[, , ] array, Func<S> function) {
            return array.Select((_, i, j, k) => function());
        }

        static public async Task<T[, , ]> WaitForAll<T>(this Task<T>[, , ] taskArray) {
            T[, , ] newArray = new T[taskArray.GetLength(0), taskArray.GetLength(1), taskArray.GetLength(2)];
            for (int i = 0; i < taskArray.GetLength(0); i++) {
                for (int j = 0; j < taskArray.GetLength(1); j++) {
                    for (int k = 0; k < taskArray.GetLength(2); k++) {
                        newArray[i, j, k] = await taskArray[i, j, k];
                    }
                }
            }
            return newArray;
        }

        static public IEnumerable<T> Where<T>(this T[, , ] array, Func<T, int, int, int, bool> predicate) {
            List<T> newArray = new List<T>();
            array.ForEach((element, i, j, k) => {
                if (predicate(element, i, j, k)) {
                    newArray.Add(element);
                }
            });
            return newArray;
        }

        static public IEnumerable<T> Where<T>(this T[, , ] array, Func<T, bool> predicate) {
            return array.Cast<T>().Where(predicate);
        }

        static public IEnumerable<T> Where<T>(this T[, , ] array, Func<bool> predicate) {
            return array.Where((_) => predicate());
        }

        static public int[] FindIndex<T>(this T[, , ] array, Func<T, int, int, int, bool> predicate) {
            bool breakFlag = false;
            int[] indexes = null;
            for (int i = 0; i < array.GetLength(0) && !breakFlag; i++) {
                for (int j = 0; j < array.GetLength(1) && !breakFlag; j++) {
                    for (int k = 0; k < array.GetLength(2) && !breakFlag; k++) {
                        if (predicate(array[i, j, k], i, j, k)) {
                            indexes = new [] { i, j, k };
                            breakFlag = true;
                        }
                    }
                }
            }
            return indexes;
        }

        static public int[] FindIndex<T>(this T[, , ] array, Func<T, bool> predicate) {
            return array.FindIndex((element, i, j, k) => predicate(element));
        }

        static public int[] FindIndex<T>(this T[, , ] array, Func<bool> predicate) {
            return array.FindIndex((_) => predicate());
        }

        static public T[, ] GetPlane<T>(this T[, , ] array, Dimension constIndex, int planeIndex) {
            switch (constIndex) {
                case Dimension.x:
                    return array.GetXPlane(planeIndex);
                case Dimension.y:
                    return array.GetYPlane(planeIndex);
                case Dimension.z:
                    return array.GetZPlane(planeIndex);
                case Dimension.zero:
                    throw new ArgumentException("Direction.zero is not a proper plane's const index.");
                default:
                    throw new ArgumentException("Not known value.");
            }
        }

        static public T[, ] GetXPlane<T>(this T[, , ] array, int planeIndex) {
            return array.SliceTo2DAndMap(1, 2, (i, j) => array[planeIndex, i, j]);
        }
        static public T[, ] GetYPlane<T>(this T[, , ] array, int planeIndex) {
            return array.SliceTo2DAndMap(0, 2, (i, j) => array[i, planeIndex, j]);
        }
        static public T[, ] GetZPlane<T>(this T[, , ] array, int planeIndex) {
            return array.SliceTo2DAndMap(0, 1, (i, j) => array[i, j, planeIndex]);
        }

        static private T[, ] SliceTo2DAndMap<T>(
            this T[, , ] array,
            int rowIndex,
            int columnIndex,
            Func<int, int, T> function
        ) {
            T[, ] plane = new T[array.GetLength(rowIndex), array.GetLength(columnIndex)];
            for (int i = 0; i < array.GetLength(rowIndex); i++) {
                for (int j = 0; j < array.GetLength(columnIndex); j++) {
                    plane[i, j] = function(i, j);
                }
            }
            return plane;
        }
    }
}