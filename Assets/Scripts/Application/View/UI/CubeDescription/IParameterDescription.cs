public interface IParameterDescription {
    string Parameter { get; set; }
    string Description { get; set; }
    void Destroy();
}