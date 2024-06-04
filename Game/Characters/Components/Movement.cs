using Godot;
using System;

public class Movement : Node2D
{
    [Export] public float Speed { get; set; }

    public Vector2 GetInput()
    {
        Vector2 velocity = new Vector2();

        if (Input.IsActionPressed("move_right"))
        {
            velocity.x += 1;
        }
        if (Input.IsActionPressed("move_left"))
        {
            velocity.x -= 1;
        }
        if (Input.IsActionPressed("move_down"))
        {
            velocity.y += 1;
        }
        if (Input.IsActionPressed("move_up"))
        {
            velocity.y -= 1;
        }

        velocity = velocity.Normalized() * Speed;

        return velocity;
    }
}
