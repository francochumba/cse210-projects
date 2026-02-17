public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    private ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;

        _amountCompleted++;

        int earned = GetPoints();
        if (_amountCompleted == _target)
        {
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string baseDetails = base.GetDetailsString();
        return $"{baseDetails} -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }

    public static ChecklistGoal FromString(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);
        int bonus = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int amountCompleted = int.Parse(parts[5]);

        return new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
    }
}
