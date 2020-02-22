using Data;
using UnityEngine;

public class ChristofellApplication : MonoBehaviour {
    public ChristofellModel model;
    public ChristofellView view;
    public ChristofellController controller;
    public ChristofellEvent zerosHidedEvent = new ChristofellEvent();
    public ChristofellEvent<SpaceType> spaceChangedEvent = new ChristofellEvent<SpaceType>();

}