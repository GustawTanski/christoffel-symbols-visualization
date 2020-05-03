using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Data;
using TMPro;
using UnityEngine;

public partial class CubeDescriptionView : ChristofellElement {
    public TextMeshProUGUI title;
    public TextDescription textDescriptionPrefab;
    public LaTeXDescription laTeXDescriptionPrefab;
    public GameObject descriptionContainer;

    private IParameterDescription[] parameterDescriptions = new IParameterDescription[0];
    private SpaceChangedArgs spaceChangedArgs;
    private IParameterDescription currentDescAsset;
    private TensorProperties.LaTeXCharacter currentParameter;
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
    private void Awake() {
        SetListeners();
    }

    private void SetListeners() {
        App.spaceChanged.listOfHandlers += OnSpaceChanged;
    }

    private void OnSpaceChanged(object caller, SpaceChangedArgs e) {
        spaceChangedArgs = e;
        SetNewTitle();
        CleanDescription();
        CreateDescription();
    }

    private void SetNewTitle() {
        title.text = spaceChangedArgs.tensorProperties.Name;
    }

    private void CleanDescription() {
        foreach (IParameterDescription desc in parameterDescriptions) {
            desc.Destroy();
        }
    }

    private void CreateDescription() {
        parameterDescriptions = spaceChangedArgs.tensorProperties.Parameters
            .Concat(spaceChangedArgs.tensorProperties.Coordinates)
            .Where(parameter => parameter.Description.Length > 0)
            .Select(CreateParameterDescription)
            .ToArray();
    }

    private IParameterDescription CreateParameterDescription(TensorProperties.LaTeXCharacter parameter) {
        currentParameter = parameter;
        try {
            TryCreatingTextDescription();
        } catch (KeyNotFoundException _) {
            CreateLaTeXDescription();
        }
        return currentDescAsset;
    }

    private void TryCreatingTextDescription() {
        string text = GetUnicodeFromCurrentParameter();
        currentDescAsset = Instantiate(textDescriptionPrefab, descriptionContainer.transform);
        currentDescAsset.Parameter = text;
        currentDescAsset.Description = currentParameter.Description;
    }

    private string GetUnicodeFromCurrentParameter() {
        string temp = currentParameter.LaTeX + "";
        foreach (Regex filter in FILTERS) {
            temp = filter.Replace(temp, (a) => LaTeXToUnicode[a.Value]);
        }
        return temp;
    }

    private void CreateLaTeXDescription() {
        currentDescAsset = Instantiate(laTeXDescriptionPrefab, descriptionContainer.transform);
        currentDescAsset.Parameter = currentParameter.LaTeX;
        currentDescAsset.Description = currentParameter.Description;
    }

}