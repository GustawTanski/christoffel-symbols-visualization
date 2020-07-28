using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MetricSelectionView : MenuElement {
    public ParametersPanelView parametersPanel;
    public TMP_Dropdown dropdown;
    public TMP_Text spacetimeName;
    public Button applyButton;
    public GameObject warning;
    public ChristoffelParameter christoffelParameterPrefab;
    public GameObject ParametersContainer;
    private static readonly Regex COMMAN_FILTER = new Regex(@"(\\not)?[\\][a-zA-Z]+(\{[a-zA-Z0-9]*\})?", RegexOptions.Compiled);
    private static readonly Regex SUPERSCRIPT_FILTER = new Regex(@"\^[a-zA-Z0-9]", RegexOptions.Compiled);
    private static readonly Regex SUBSCRIPT_FILTER = new Regex(@"_[a-zA-Z0-9]", RegexOptions.Compiled);
    private static readonly Regex LETTER_FILTER = new Regex(@"[a-zA-Z0-9]", RegexOptions.Compiled);
    private static readonly Regex[] FILTERS = new [] {
        COMMAN_FILTER,
        SUPERSCRIPT_FILTER,
        SUBSCRIPT_FILTER,
        LETTER_FILTER
    };

    private List<ChristoffelParameter> christoffelParameters = new List<ChristoffelParameter>();
    public void UpdateParameters(TensorProperties.LaTeXCharacter[] parameters) {
        christoffelParameters.ForEach(parameter => Destroy(parameter.gameObject));
        christoffelParameters = parameters.Select(parameter => {
            ChristoffelParameter a = Instantiate(christoffelParameterPrefab, ParametersContainer.transform);
            string temp = parameter.LaTeX + "";
            foreach (Regex filter in FILTERS) {
                temp = filter.Replace(temp, (b) => CubeDescriptionView.LaTeXToUnicode[b.Value]);
            }
            a.text.text = temp;
            return a;
        }).ToList();
    }

}