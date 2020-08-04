using System.Linq;
using System.Threading.Tasks;
using BetterMultidimensionalArray;
using Data;
using UnityEngine;

public class MetricController : ChristoffelElement {
    private MetricView View => App.view.menu.metricSelection.metric;

    private TensorProperties tensorProperties;
    private string laTeXOfMetric;
    private Texture2D texture;
    private void Awake() {
        App.spaceDataChanged.listOfHandlers += OnSpaceDataChanged;
    }

    private void OnSpaceDataChanged(object caller, SpaceChangedArgs e) {
        tensorProperties = e.tensorProperties;
        if (HasTensorAMetric()) FetchAndShowMetric();
    }

    private bool HasTensorAMetric() {
        return tensorProperties.Metric.GetLength(0) > 0;
    }

    private async void FetchAndShowMetric() {
        laTeXOfMetric = GenerateLaTeXOfMetric();
        await FetchTexture();
        ShowMetric();
    }

    private string GenerateLaTeXOfMetric() {
        string matrixBody = GenerateLaTeXOfBodyOfMatrix();
        return GenerateLaTeXOfMetricFromBody(matrixBody);
    }

    private string GenerateLaTeXOfBodyOfMatrix() {
        return tensorProperties.Metric
            .ToJagged()
            .Select(row => row.Aggregate(ConnectCellsIntoRow))
            .Aggregate(ConnectRowsIntoTable);
    }

    private string ConnectCellsIntoRow(string previousCells, string currentCells) {
        return $"{previousCells} & {currentCells}";
    }

    private string ConnectRowsIntoTable(string previousRows, string currentRow) {
        return $"{previousRows}\\\\\n{currentRow}";
    }

    private string GenerateLaTeXOfMetricFromBody(string matrixBody) {
        return $"g_{{\\mu\\nu}} = \\begin{{bmatrix}}{matrixBody}\\end{{bmatrix}}";
    }

    private async Task FetchTexture() {
        texture = await LaTeXTextureDownloader.FetchOneTexture(laTeXOfMetric);
    }

    private void ShowMetric() {
        View.Texture = texture;
    }
}