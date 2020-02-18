using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Data {

    public class SpaceTypeDropdown : MonoBehaviour {
        public Dropdown dropdown;

        private void Start() {
            PopulateList();
        }

        private void PopulateList() {
            List<string> names = Enum.GetNames(typeof(SpaceType)).ToList();
            dropdown.AddOptions(names);
            dropdown.value
        }
    }
}