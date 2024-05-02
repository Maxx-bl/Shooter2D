using Godot;
using System;

public class Missile : KinematicBody2D
{
    public float Speed { get; set; } = 800;
    public Vector2 Target { get; set; }
    public Vector2 Cannon { get; set; }
    public Vector2 Direction { get; set; }
    
    public override void _Ready()
    {
        Direction = Target - Cannon;
        Rotation = Direction.Angle();
    }

    public override void _PhysicsProcess(float delta)
    {
        MoveAndSlide(Direction.Normalized() * Speed);
    }

    void _on_Area2D_body_entered(Node body)
    {
        QueueFree();
    }
}
