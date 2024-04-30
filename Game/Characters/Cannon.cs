using Godot;
using System;

public class Cannon : Node2D
{
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("shoot"))
        {
            InstanctiateMissile();
        }
    }

    void InstanctiateMissile()
    {
        PackedScene missileScene = GD.Load<PackedScene>("res://Game/Missile/Missile.tscn");
        Missile missile = missileScene.Instance<Missile>();
        missile.Target = GetGlobalMousePosition();
        missile.Cannon = GlobalPosition;
        missile.Position = GlobalPosition;
        GetParent().GetParent().AddChild(missile);
    }
}
