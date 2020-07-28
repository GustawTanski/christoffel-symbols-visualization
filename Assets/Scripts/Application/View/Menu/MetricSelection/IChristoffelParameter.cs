public interface IChristoffelParameter {
    string Parameter { get; set; }
    string Description { get; set; }
    void Destroy();
}