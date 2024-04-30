using Godot;
using System;

public class Missile : KinematicBody2D
{
    public float Speed { get; set; } = 400;
    public Vector2 Target { get; set; }
    public Vector2 Cannon { get; set; }
    

    public override void _Ready()
    {
        Vector2 direction = Target - Cannon;
        Rotation = direction.Angle();
    }
}
