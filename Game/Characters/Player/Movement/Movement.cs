using Godot;
using System;

public partial class Movement : Node2D
{
	[Export] public float Speed { get; set; }

    public Vector2 GetInput()
    {
        Vector2 velocity = new Vector2();

        if (Input.IsActionPressed("move_right"))
        {
            velocity.X += 1;	
        }
        if (Input.IsActionPressed("move_left"))
        {
            velocity.X -= 1;
        }
        if (Input.IsActionPressed("move_down"))
        {
            velocity.Y += 1;
        }
        if (Input.IsActionPressed("move_up"))
        {
            velocity.Y -= 1;
        }

        velocity = velocity.Normalized() * Speed;

        return velocity;
    }
}
