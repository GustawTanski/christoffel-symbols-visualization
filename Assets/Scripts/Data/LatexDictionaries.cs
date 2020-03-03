using System.Collections.Generic;
namespace Data {
    public static class LatexDictionaries {
        static public Dictionary<int, string> index = new Dictionary<int, string> {
            [0] = " t ",
            [1] = " r ",
            [2] = @"\theta ",
            [3] = @"\phi "
        };
        static public Dictionary<Size, string> size = new Dictionary<Size, string>() {
            [Size.normal] = " ",
            [Size.tiny] = @"\tiny ", 
            [Size.small] = @"\small ", 
            [Size.large] = @"\large ", 
            [Size.LARGE] = @"\LARGE ", 
            [Size.huge] = @"\huge "
        };
    }
}