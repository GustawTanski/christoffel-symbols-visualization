using System.Linq;
using System;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;

namespace Data {
    public class EasySaveDataSystem : IDataLoadAndSaveSystem {

        private static List<string> allFileNames = new List<string>();
        const string ALL_FILE_NAMES_FILE_NAME = "_____21312_123sadlk31jkl2123qwadsc";
        static readonly EasyFileSave NAMES_FILE = new EasyFileSave(ALL_FILE_NAMES_FILE_NAME);

        static EasySaveDataSystem() {
            if (NAMES_FILE.Load()) {
                allFileNames = (List<string>) NAMES_FILE.GetDeserialized("names", typeof(List<string>));
            } else {
                allFileNames = new List<string>();
            }
        }

        public TextAsset[] LoadAll() {
            return allFileNames.Select(name => Load(name)).ToArray();
        }
        public TextAsset Load(string name) {
            EasyFileSave file = new EasyFileSave(name);
            if (file.Load()) {
                TextAsset asset = new TextAsset(file.GetString("text"));
                asset.name = name;
                file.Dispose();
                return asset;
            }
            throw new Exception();
        }
        public void Save(TextAsset asset) {
            EasyFileSave file = new EasyFileSave(asset.name);
            file.Add("text", asset.text);
            file.Save();
            AddToFileNames(asset.name);
        }

        private void AddToFileNames(string name) {
            allFileNames.Add(name);
            NAMES_FILE.AddSerialized("names", allFileNames);
            NAMES_FILE.Save();
        }
        public void Delete(string name) {
            EasyFileSave file = new EasyFileSave(name);
            file.Delete();
            DeleteFromFileNames(name);
        }

        private void DeleteFromFileNames(string name) {
            allFileNames.Remove(name);
            NAMES_FILE.AddSerialized("names", allFileNames);
        }

    }
}