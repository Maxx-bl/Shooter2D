using Godot;
using System;

public class Bot : KinematicBody2D
{
    float Speed = 150f;
    NavigationAgent2D Nav;
    Timer TimerNav;
    KinematicBody2D Target;
    Vector2 Velocity;

    public override void _Ready()
    {
        Nav = GetNode<NavigationAgent2D>("NavigationAgent2D");
        TimerNav = GetNode<Timer>("TimerNav");
        Velocity = Vector2.Zero;
        Target = GetParent().GetNode<KinematicBody2D>("Player");
    }

    public override void _PhysicsProcess(float delta)
    {
        LookAt(Target.Position);
        Vector2 MoveDirection = Position.DirectionTo(Nav.GetTargetLocation());
        Velocity = MoveDirection * Speed;
        Nav.SetVelocity(Velocity);
        MoveAndSlide(Velocity);
    }

    void MakePath()
    {
        Nav.SetTargetLocation(Target.GlobalPosition);
    }

    void _on_TimerNav_timeout()
    {
        MakePath();
    }
}
