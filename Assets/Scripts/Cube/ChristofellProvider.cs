using System.Linq;
using BetterMultiDimensional;
using Data;
using Latex;
using Newtonsoft.Json;

namespace Cube {
    internal class ChristofellProvider {
        public SpaceTypeDictionary SpaceLatexDict {
            private get;
            set;
        }
        public SpaceType Space {
            private get;
            set;
        }

        public string[, , ] FormulaTensor {
            get;
            private set;
        } = new string[4, 4, 4];

        public string[, , ] IndexesTensor {
            get;
            private set;
        }

        public ChristofellProvider(SpaceTypeDictionary dict, SpaceType space) {
            SpaceLatexDict = dict;
            Space = space;
            IndexesTensor = GetIndexLatexTensor();
        }

        private string[, , ] GetIndexLatexTensor() {
            return new string[4, 4, 4].Select(IndexesToLatex);
        }

        private string IndexesToLatex(string el, int i, int j, int k) {
            string[] latexArray = new int[] { i, j, k }.Select(GetIndexLatex).ToArray();
            return "(" + string.Join(", ", latexArray) + ")";
        }

        private string GetIndexLatex(int number) {
            return LatexDictionaries.index[number];
        }

        public void FetchFormulas() {
            string json = SpaceLatexDict[Space].text;
            FormulaTensor = JsonConvert.DeserializeObject<string[, , ]>(json);
        }
    }
}