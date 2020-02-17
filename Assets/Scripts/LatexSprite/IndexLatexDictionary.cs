using System.Collections.Generic;

namespace Latex {
    public static class IndexLatex {
        static public Dictionary<int, string> dictionary = new Dictionary<int, string>();
        static IndexLatex() {
            dictionary.Add(0, "t");
            dictionary.Add(1, "r");
            dictionary.Add(2, @"\theta");
            dictionary.Add(3, @"\phi");
        }
    }
}