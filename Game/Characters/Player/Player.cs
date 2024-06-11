using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] Movement movement;

    public override void _PhysicsProcess(double delta)
    {
		Velocity = movement.GetInput();
		MoveAndSlide();
        LookAt(GetGlobalMousePosition());
    }
}
