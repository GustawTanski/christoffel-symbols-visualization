using UnityEngine;
using System.Linq;
using BetterMultidimensionalArray;

public class MetricController : ChristoffelElement {
    private MetricView View => App.view.menu.metricSelection.metric;
    private void Awake() {
        App.spaceDataChanged.listOfHandlers += async(caller, e) => {
            if (e.tensorProperties.Metric.GetLength(0) > 0) {
                string matrixTeX = e.tensorProperties.Metric.ToJagged().Aggregate<string[], string>(
                    "",
                    (string acc, string[] curr) => {
                        return $"{acc}{curr.Aggregate((acc2, curr2) => $"{acc2} & {curr2}")}\\\\\n";
                    }
                );
                string teX = $"g_{{\\mu\\nu}} = \\begin{{bmatrix}}{matrixTeX}\\end{{bmatrix}}";
                Texture2D texture = await LaTeXTextureDownloader.FetchOneTexture(teX);
                View.Texture = texture;
            }
        };
    }
}