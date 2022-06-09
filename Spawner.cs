using Godot;

public class Spawner : Node2D
{
    private Area2D _areaConveerDetect;
    private PackedScene _stonePacked;
    private Node2D _stone;
    private Path2D _conveerPath;
    private bool _canSpawn = true;

    public override void _Ready()
    {
        _areaConveerDetect = GetNode<Area2D>("DetectConveerArea");
        _stonePacked = GD.Load<PackedScene>("res://Stone.tscn");
    }

    public override void _Process(float delta)
    {

    }

    private void OnCollisionAreaEnter(Area2D area2D)
    {
        if (area2D.CollisionLayer == 16)
        {
            if (_canSpawn)
            {
                for (int i = 0; i < 1; i++)
                {
                    _stone = _stonePacked.Instance<Node2D>();
                    AddChild(_stone, true);
                    _stone.GlobalPosition = area2D.GlobalPosition;
                    GD.Print(_stone.Position);
                }
                _canSpawn = false;
            }

        }
    }
}
