using TMPro;

public class CubeDescriptionView : ChristofellElement {
    public TextMeshProUGUI title;

    private void Start() {
        title.text = "pieski";
        App.spaceChanged.listOfHandlers += (object sender, SpaceChangedArgs e) => {
            title.text = e.tensorProperties.Name;
        };
    }

}