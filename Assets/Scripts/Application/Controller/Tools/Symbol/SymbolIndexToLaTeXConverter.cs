using Data;
public class SymbolIndexToLaTeXConverter : IndexToLaTeXConverter {

    static public string Convert(TensorProperties props) {
        return new SymbolIndexToLaTeXConverter(props).GetLaTeX();
    }

    public SymbolIndexToLaTeXConverter(TensorProperties props) : base(props) {}

    protected override IndexWrapper ConvertToWrappers(TensorProperties.Index index, int n) {
        return new IndexWrapper {
            CoordinateLaTeX = index.LaTeX,
                Number = n,
                Index = index
        };
    }
}