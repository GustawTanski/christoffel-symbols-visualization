using System;
using System.Collections.Generic;
using System.Linq;
using Data;
public partial class IndexToLaTeXConverter {
    private TensorProperties properties;
    private int[] cubeIndexes;

    static public implicit operator Func<string, int, int, int, string>(IndexToLaTeXConverter converter) {
        return converter.Convert;
    }

    public IndexToLaTeXConverter(TensorProperties props) {
        properties = props;
    }

    private string Convert(string _, int i, int j, int k) {
        SetCubeIndexes(i, j, k);
        return GetLaTeX();
    }

    private void SetCubeIndexes(int i, int j, int k) {
        cubeIndexes = new [] { i, j, k };
    }

    private string GetLaTeX() {
        return properties.Symbol + GetIndexesLaTeXString();;
    }

    private string GetIndexesLaTeXString() {
        return string.Join("", GetUpAndDownIndexLaTeXStrings());;
    }

    private IEnumerable<string> GetUpAndDownIndexLaTeXStrings() {
        return properties
            .Indexes
            .Select(ConvertToWrappers)
            .GroupBy(wrapper => wrapper.Index.Position)
            .Select(GroupToLaTeXStringConverter.Convert);
    }

    private IndexWrapper ConvertToWrappers(TensorProperties.Index index, int n) {
        return new IndexWrapper {
            CoordinateLaTeX = properties.Coordinates[cubeIndexes[n]].LaTeX,
                Number = n,
                Index = index
        };
    }

}