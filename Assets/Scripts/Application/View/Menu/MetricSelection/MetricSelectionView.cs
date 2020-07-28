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
    public TextParameter textParameterPrefab;
    public LaTeXParameter laTeXParameterPrefab;
    public GameObject parametersContainer;
    private static readonly Regex COMMAND_FILTER = new Regex(@"(\\not)?[\\][a-zA-Z]+(\{[a-zA-Z0-9]*\})?", RegexOptions.Compiled);
    private static readonly Regex SUPERSCRIPT_FILTER = new Regex(@"\^((\{[^\}]+\})|.)", RegexOptions.Compiled);
    private static readonly Regex SUBSCRIPT_FILTER = new Regex(@"_((\{[^\}]+\})|.)", RegexOptions.Compiled);
    private static readonly Regex LETTER_FILTER = new Regex(@"[a-zA-Z0-9]", RegexOptions.Compiled);
    private static readonly Regex[] FILTERS = new [] {
        COMMAND_FILTER,
        SUPERSCRIPT_FILTER,
        SUBSCRIPT_FILTER,
        LETTER_FILTER
    };
    private List<IChristoffelParameter> christoffelParameters = new List<IChristoffelParameter>();
    private MetricSelectionModel Model => App.model.menu.metricSelection;
    private TensorProperties.LaTeXCharacter[] parametersData;
    private TensorProperties.LaTeXCharacter currentParameterData;
    private IChristoffelParameter currentParameter;
    public void UpdateParameters(TensorProperties.LaTeXCharacter[] parameters) {
        parametersData = parameters;
        RemoveAllParameters();
        CreateParameters();
    }

    private void RemoveAllParameters() {
        foreach (IChristoffelParameter parameter in christoffelParameters)
            parameter.Destroy();
    }

    private void CreateParameters() {
        christoffelParameters = parametersData
            .Where(parameter => parameter.Description.Length > 0)
            .Select(CreateParameterDescription)
            .ToList();
    }

    private IChristoffelParameter CreateParameterDescription(TensorProperties.LaTeXCharacter parameter) {
        currentParameterData = parameter;
        try {
            TryCreatingTextDescription();
        } catch (KeyNotFoundException) {
            CreateLaTeXDescription();
        }
        return currentParameter;
    }

    private void TryCreatingTextDescription() {
        string text = GetUnicodeFromCurrentParameter();
        currentParameter = Instantiate(textParameterPrefab, parametersContainer.transform);
        currentParameter.Parameter = text;
        currentParameter.Description = currentParameterData.Description;
    }

    private string GetUnicodeFromCurrentParameter() {
        string temp = currentParameterData.LaTeX + "";
        foreach (Regex filter in FILTERS) {
            temp = filter.Replace(temp, (a) => {
                Debug.Log(a);
                return Model.LaTeXToUnicode[a.Value];
            });
        }
        return temp;
    }

    private void CreateLaTeXDescription() {
        currentParameter = Instantiate(laTeXParameterPrefab, parametersContainer.transform);
        currentParameter.Parameter = currentParameterData.LaTeX;
        currentParameter.Description = currentParameterData.Description;
    }

}