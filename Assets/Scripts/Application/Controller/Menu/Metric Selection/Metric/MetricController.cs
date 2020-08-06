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
        else HideMetric();
    }

    private bool HasTensorAMetric() {
        return tensorProperties.Metric.GetLength(0) > 0;
    }

    private async void FetchAndShowMetric() {
        laTeXOfMetric = GenerateLaTeXOfMetric();
        string nameOfFetchedMetric = tensorProperties.Name;
        await FetchTexture();
        IfNameOfFetchedIsCurrentTensorNameUpdateMetric(nameOfFetchedMetric);
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

    private void IfNameOfFetchedIsCurrentTensorNameUpdateMetric(string nameOfFetched) {
        if (IsNameOfFetchedTheCurrentTensorName(nameOfFetched)) UpdateMetric();
    }

    private bool IsNameOfFetchedTheCurrentTensorName(string nameOfFetched) {
        return nameOfFetched == tensorProperties.Name;
    }

    private void UpdateMetric() {
        SetViewTexture();
        ShowMetric();
    }

    private void SetViewTexture() {
        View.Texture = texture;
    }

    private void ShowMetric() {
        View.gameObject.SetActive(true);
    }

    private void HideMetric() {
        View.gameObject.SetActive(false);
    }
}