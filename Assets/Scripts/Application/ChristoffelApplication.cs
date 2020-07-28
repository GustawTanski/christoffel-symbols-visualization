using UnityEngine;

public class ChristoffelApplication : MonoBehaviour {
    public ChristofellModel model;
    public ChristofellView view;
    public ChristofellController controller;
    public ChristoffelEvent<ZerosHidedArgs> zerosHided = new ChristoffelEvent<ZerosHidedArgs>();
    public ChristoffelEvent<MiniCubeRotatorClickedArgs> miniCubeRotatorClicked = new ChristoffelEvent<MiniCubeRotatorClickedArgs>();
    public ChristoffelEvent<ResetButtonClickedArgs> resetButtonClicked = new ChristoffelEvent<ResetButtonClickedArgs>();
    public ChristoffelEvent<SpaceChangedArgs> spaceDataChanged = new ChristoffelEvent<SpaceChangedArgs>();
    public ChristoffelEvent<SpaceChangedArgs> spaceVisualizedByCubeChanged = new ChristoffelEvent<SpaceChangedArgs>();
    public ChristoffelEvent<MenuChangedArgs> menuChanged = new ChristoffelEvent<MenuChangedArgs>();
    public ChristoffelEvent<LabelSliderValueChangedArgs> labelSliderValueChanged =
        new ChristoffelEvent<LabelSliderValueChangedArgs>();
    public ChristoffelEvent<ParameterSelectionButtonPressedArgs> parameterSelectionButtonPressed =
        new ChristoffelEvent<ParameterSelectionButtonPressedArgs>();
    public ChristoffelEvent<ToolsToggledArgs> toolsToggled = new ChristoffelEvent<ToolsToggledArgs>();
}