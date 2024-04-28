namespace Lab5.Presentation.Scenarios;

public interface IScenario
{
    string Name { get; }

    Task Run();
}