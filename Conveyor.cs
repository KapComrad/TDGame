using Godot;

public class Conveyor : Area2D
{
    private Node2D _stone;
    private Node2D[] _stones;
    private KinematicBody2D _stoneBody;
    private bool _stoneInConveyor;
    private float _velocity = 3;
    private Vector2 _motion = Vector2.Right;
    private Position2D _position;
    public override void _Ready()
    {
        _position = Owner.GetNode<Position2D>("Position2D");
    }

    public override void _Process(float delta)
    {
        foreach (var stone in GetOverlappingBodies())
        {
            _motion = _position.GlobalTransform.BasisXform(_position.Position);
            _stone = (Node2D)stone;
            _stoneBody = (KinematicBody2D)_stone;
            _stoneBody.MoveAndCollide(_motion.LimitLength(_velocity));
        }
    }
}
