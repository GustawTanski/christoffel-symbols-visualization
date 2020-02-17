using System;
using System.Collections.Generic;

namespace ForEach {
    static class IEnumerableExtension {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int, IEnumerable<T>> cb) {
            int i = 0;
            foreach (T el in enumerable) {
                cb(el, i, enumerable);
            }
        }
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> cb) {
            ForEach(enumerable, (el, i, nothing) => cb(el, i));
        }
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> cb) {
            ForEach(enumerable, (el, i, nothing) => cb(el));
        }
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action cb) {
            ForEach(enumerable, (el, i, nothing) => cb());
        }
    }

}