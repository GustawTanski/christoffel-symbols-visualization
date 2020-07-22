using System.Collections.Generic;
using ParameterFlag = System.UInt32;
using System.Linq;

public class SpaceSelector : ChristofellElement {

    private const ParameterFlag nullFlag = 0;
    private const ParameterFlag M = 0b1;
    private const ParameterFlag Q = 0b10;
    private const ParameterFlag a = 0b100;
    private const ParameterFlag Lambda = 0b1000;
    private const ParameterFlag n = 0b1_0000;

    private ParameterFlag state = nullFlag;

    private void Awake() {
        App.spaceSelectionButtonPressed.listOfHandlers += (caller, e) => {
            if (e.isOn) state |= ConvertParameterToFlag(e.parameter);
            else state &= ~ConvertParameterToFlag(e.parameter);
            string spaceType = GetSpaceFromState();
            if (spaceType != App.model.cube.spaceType && spaceType != "Nothing")
                App.controller.cube.SetSpaceType(spaceType);
        };
    }

    private ParameterFlag ConvertParameterToFlag(SpaceParameter parameter) {
        return (ParameterFlag) parameter;
    }

    private string GetSpaceFromState() {
        switch (state) {
            case nullFlag:
                return "Minkowski";
            case M:
                return "Schwarzschild";
            case M | a:
                return "Kerr";
            default:
                return "Nothing";
        };
    }

    private void Start() {
        SelectionCrossModel crossModel = App.model.menu.toolsMenu.selectionCross;
        if (crossModel.M) state |= M;
        if (crossModel.Q) state |= Q;
        if (crossModel.a) state |= a;
        if (crossModel.Lambda) state |= Lambda;
        if (crossModel.n) state |= n;
    }
}