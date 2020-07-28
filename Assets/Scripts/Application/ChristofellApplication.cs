using UnityEngine;

public class ChristofellApplication : MonoBehaviour {
    public ChristofellModel model;
    public ChristofellView view;
    public ChristofellController controller;
    public ChristofellEvent<ZerosHidedArgs> zerosHided = new ChristofellEvent<ZerosHidedArgs>();
    public ChristofellEvent<MiniCubeRotatorClickedArgs> miniCubeRotatorClicked = new ChristofellEvent<MiniCubeRotatorClickedArgs>();
    public ChristofellEvent<ResetButtonClickedArgs> resetButtonClicked = new ChristofellEvent<ResetButtonClickedArgs>();
    public ChristofellEvent<SpaceChangedArgs> spaceDataChanged = new ChristofellEvent<SpaceChangedArgs>();
    public ChristofellEvent<SpaceChangedArgs> spaceVisualizedByCubeChanged = new ChristofellEvent<SpaceChangedArgs>();
    public ChristofellEvent<MenuChangedArgs> menuChanged = new ChristofellEvent<MenuChangedArgs>();
    public ChristofellEvent<LabelSliderValueChangedArgs> labelSliderValueChanged =
        new ChristofellEvent<LabelSliderValueChangedArgs>();
    public ChristofellEvent<ParameterSelectionButtonPressedArgs> parameterSelectionButtonPressed =
        new ChristofellEvent<ParameterSelectionButtonPressedArgs>();
    public ChristofellEvent<ToolsToggledArgs> toolsToggled = new ChristofellEvent<ToolsToggledArgs>();
}