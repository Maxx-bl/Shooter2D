using Godot;
using System;

public partial class Bot : CharacterBody2D
{
    [Export] NavigationAgent2D nav;
    CharacterBody2D Target;
    float Speed;

    public override void _Ready()
    {
        Target = GetParent().GetNode<CharacterBody2D>("Player");
        Speed = GetNode<Speed>("Speed").MoveSpeed;
    }

    public override void _PhysicsProcess(double delta)
    {
        var dir = ToLocal(nav.GetNextPathPosition()).Normalized();
        Velocity = dir * Speed;
        MoveAndSlide();
    }

    void _on_timer_timeout()
    {
        nav.TargetPosition = Target.GlobalPosition;
    }
}
