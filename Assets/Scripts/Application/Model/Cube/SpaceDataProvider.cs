using System.Collections.Generic;
using Data;
using UnityEngine;
public static class SpaceDataProvider {
    public static Dictionary<string, TextAsset> spacesData = new Dictionary<string, TextAsset>();
    private static IDataLoadAndSaveSystem dataSystem = new ResourceDataSystem();
    public static void LoadResources() {
        foreach (TextAsset resource in dataSystem.LoadAll()) {
            spacesData[resource.name] = resource;
        }
    }
}