using System;
using System.Threading.Tasks;

namespace BetterMultiDimensional {
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
            array.ForEach((element, i, j, k) => action());
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
            return array.Select((element, i, j, k) => function());
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

    }
}