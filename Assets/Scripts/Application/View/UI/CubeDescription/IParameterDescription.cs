using UnityEngine;
public interface IParameterDescription {
    RectTransform RectTransform { get; }
    string Parameter { get; set; }
    string Description { get; set; }
    void Destroy();
}