using UnityEngine;

public class ChristofellApplication : MonoBehaviour {
    public ChristofellModel model;
    public ChristofellView view;
    public ChristofellController controller;
    public ChristofellEvent<ZerosHidedArgs> zerosHidedEvent = new ChristofellEvent<ZerosHidedArgs>();
    public ChristofellEvent<SpaceChangedArgs> spaceChangedEvent = new ChristofellEvent<SpaceChangedArgs>();
    public ChristofellEvent<MiniCubeRotatorClickedEventArgs> miniCubeRotatorClicked 
        = new ChristofellEvent<MiniCubeRotatorClickedEventArgs>();

}