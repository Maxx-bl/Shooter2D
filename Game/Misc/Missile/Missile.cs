using Godot;
using System;

public class Missile : KinematicBody2D
{
    public float Speed { get; set; } = 800;
    public Vector2 Target { get; set; }
    public Vector2 Cannon { get; set; }
    public Vector2 Direction { get; set; }
    Damages Damages;
    
    public override void _Ready()
    {
        Damages = GetNode<Damages>("Damages");

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

        if (body.IsInGroup("Targetable"))
        {
            Health BodyHealth = body.GetNode<Health>("Health");
            BodyHealth.Damage(Damages.Damage);
        }
    }
}
