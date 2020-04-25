using UnityEngine;

public class ChristofellApplication : MonoBehaviour {
    public ChristofellModel model;
    public ChristofellView view;
    public ChristofellController controller;
    public ChristofellEvent<ZerosHidedArgs> zerosHided = new ChristofellEvent<ZerosHidedArgs>();
    public ChristofellEvent<SpaceDropdownChangedArgs> spaceDropdownChanged = new ChristofellEvent<SpaceDropdownChangedArgs>();
    public ChristofellEvent<MiniCubeRotatorClickedEventArgs> miniCubeRotatorClicked
        = new ChristofellEvent<MiniCubeRotatorClickedEventArgs>();
    public ChristofellEvent<ResetButtonClickedArgs> resetButtonClicked = new ChristofellEvent<ResetButtonClickedArgs>();
    public ChristofellEvent<SpaceChangedArgs> spaceChanged = new ChristofellEvent<SpaceChangedArgs>();
}