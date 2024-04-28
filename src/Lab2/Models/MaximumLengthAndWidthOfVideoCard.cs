namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public record MaximumLengthAndWidthOfVideoCard(double Width, double Height)
{
    private bool isCorrectData = Width >= 0 && Height >= 0;

    public bool CheckCorrectData()
    {
        return isCorrectData;
    }
}