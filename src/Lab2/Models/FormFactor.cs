namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public record FormFactor(double Width, double Height)
{
    private bool isCorrectData = Width > 0 && Height > 0;
    public double Square { get; } = Width * Height;
    public bool CheckOnCorrectInput()
    {
        return isCorrectData;
    }
}