public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }

    public abstract string GetStringRepresentation();

    public static Goal CreateFromString(string line)
    {
        string[] parts = line.Split(":");
        if (parts.Length < 2) return null;

        string type = parts[0];
        string data = parts[1];

        if (type == "SimpleGoal") return SimpleGoal.FromString(data);
        if (type == "EternalGoal") return EternalGoal.FromString(data);
        if (type == "ChecklistGoal") return ChecklistGoal.FromString(data);

        return null;
    }
}