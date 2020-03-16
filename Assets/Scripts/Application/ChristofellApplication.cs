using System;
using Data;
using UnityEngine;

public class ChristofellApplication : MonoBehaviour {
    public ChristofellModel model;
    public ChristofellView view;
    public ChristofellController controller;
    public ChristofellEvent<ZerosHidedArgs> zerosHidedEvent = new ChristofellEvent<ZerosHidedArgs>();
    public ChristofellEvent<SpaceChangedArgs> spaceChangedEvent = new ChristofellEvent<SpaceChangedArgs>();

}

public class ZerosHidedArgs: EventArgs {

}

public class SpaceChangedArgs : EventArgs {
    public SpaceType space;

    public SpaceChangedArgs(SpaceType space) {
        this.space = space;
    }
}