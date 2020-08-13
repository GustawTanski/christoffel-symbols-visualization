using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphicPopperSwitch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GraphicPopper popper;
    public string laTeX;

    public Texture2D texture;

    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        if (laTeX != "") FetchTexture();
    }

    public async Task FetchTexture() {
        texture = await LaTeXTextureDownloader.FetchOneTexture(laTeX);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        SetTextureAsPopperContent();
        MoveAndShowPopper();
    }

    private void SetTextureAsPopperContent() {
        popper.SetTexture(texture);
    }

    private void MoveAndShowPopper() {
        popper.MoveAndShow(CalculatePopperPosition());
    }

    private Vector3 CalculatePopperPosition() {
        Vector2 dist = GetPivotToLeftTopCornerTranslation();
        return transform.position - new Vector3(dist.x, dist.y, 0);
    }

    private Vector2 GetPivotToLeftTopCornerTranslation() {
        return new Vector2(rectTransform.pivot.x * rectTransform.rect.width, -rectTransform.pivot.y * rectTransform.rect.height);
    }

    public void OnPointerExit(PointerEventData eventData) {
        popper.Hide();
    }
}