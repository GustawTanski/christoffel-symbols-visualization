using System.Linq;
using Data;
public partial class IndexToLaTeXConverter {
    static private class GroupToLaTeXStringConverter {
        private const string EMPTY_LATEX_STRING = @"\:";
        static private string[] laTeXStrings;
        static private IGrouping<TensorProperties.Index.IndexPosition, IndexWrapper> group;
        static public string Convert(IGrouping<TensorProperties.Index.IndexPosition, IndexWrapper> group) {
            GroupToLaTeXStringConverter.group = group;
            ResetLaTeXStrings();
            AssignIndexesCoordinateLaTeXToLaTeXStrings();
            return ConvertLaTeXStringsToGroupLaTeXString();
        }

        static private void ResetLaTeXStrings() {
            laTeXStrings = new string[3].Select(_ => EMPTY_LATEX_STRING).ToArray();
        }

        static private void AssignIndexesCoordinateLaTeXToLaTeXStrings() {
            foreach (IndexWrapper item in group) AssignIndexCoordinateLaTeXToLaTeXStrings(item);
        }

        static private void AssignIndexCoordinateLaTeXToLaTeXStrings(IndexWrapper indexWrapper) {
            laTeXStrings[indexWrapper.Number] = indexWrapper.CoordinateLaTeX;
        }

        static private string ConvertLaTeXStringsToGroupLaTeXString() {
            return $"{TensorProperties.positionToLaTeX[group.Key]}{{{string.Join(" ", laTeXStrings)}}}";
        }
    }
}