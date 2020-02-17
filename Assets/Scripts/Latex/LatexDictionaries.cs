using System.Collections.Generic;
using Cube;

namespace Latex {
    public static class LatexDictionaries {
        static public Dictionary<int, string> index = new Dictionary<int, string>();
        static public Dictionary<Size, string> size = new Dictionary<Size, string>();
        static LatexDictionaries() {
            SetIndex();
            SetSize();
        }

        static private void SetIndex() {
            index.Add(0, " t ");
            index.Add(1, " r ");
            index.Add(2, @"\theta ");
            index.Add(3, @"\phi ");
        }

        static private void SetSize() {
            size.Add(Size.normal, " ");
            size.Add(Size.tiny, @"\tiny ");
            size.Add(Size.small, @"\small ");
            size.Add(Size.large, @"\large ");
            size.Add(Size.LARGE, @"\LARGE ");
            size.Add(Size.huge, @"\huge ");
        }
    }
}