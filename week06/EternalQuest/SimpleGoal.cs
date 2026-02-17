public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    private SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;

        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_isComplete}";
    }

    public static SimpleGoal FromString(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);
        bool isComplete = bool.Parse(parts[3]);

        return new SimpleGoal(name, description, points, isComplete);
    }
}
