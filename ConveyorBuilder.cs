using Godot;

public class ConveyorBuilder : Node2D
{
    PackedScene conveerPacked;
    private Node2D _conveerNode;
    float tile_size = 64f;
    private bool _conveyorIsVisible = false;

    public override void _Ready()
    {
        conveerPacked = GD.Load<PackedScene>("res://Conveer.tscn");
        _conveerNode = conveerPacked.Instance<Node2D>();
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("SetVisible") && !_conveyorIsVisible)
        {
            AddChild(_conveerNode, true);
            _conveerNode.GetChild<Area2D>(1).Dispose();
            _conveyorIsVisible = true;
        }
        if (Input.IsActionJustPressed("Rotate") && _conveyorIsVisible)
        {
            _conveerNode.RotationDegrees += 90;
        }
        _conveerNode.Position = GetGlobalMousePosition().Snapped(Vector2.One * tile_size);

        if (Input.IsActionJustPressed("RightMouseButton"))
        {
            var conveer = conveerPacked.Instance<Node2D>();
            AddChild(conveer, true);
            conveer.Position = _conveerNode.Position;
            conveer.Rotation = _conveerNode.Rotation;
        }
    }
}
