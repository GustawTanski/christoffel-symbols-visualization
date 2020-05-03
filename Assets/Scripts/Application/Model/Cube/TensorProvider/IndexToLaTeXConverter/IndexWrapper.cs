using Data;
public partial class IndexToLaTeXConverter {
    private struct IndexWrapper {
        public string CoordinateLaTeX { get; set; }
        public int Number { get; set; }
        public TensorProperties.Index Index { get; set; }

    }
}