public interface IChristoffelParameter {
    string Parameter { get; set; }
    string Description { get; set; }

    Popper Popper { set; }
    void Destroy();
}