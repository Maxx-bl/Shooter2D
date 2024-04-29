using Godot;
using System;

public class Player : KinematicBody2D
{

    Movement movement;

    public override void _Ready()
    {
        movement = GetNode<Movement>("Movement");
    }

    public override void _PhysicsProcess(float delta)
    {
        MoveAndSlide(movement.GetInput());
        LookAt(GetGlobalMousePosition());
    }

}
