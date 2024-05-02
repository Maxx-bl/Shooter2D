using Godot;
using System;

public class Cannon : Node2D
{

    public bool CanShoot { get; set; } = true;

    ProgressBar pb;
    Timer tm;

    public override void _Ready()
    {
        pb = GetNode<ProgressBar>("Reload");
        tm = GetNode<Timer>("Reload/Timer");
        tm.WaitTime = (float)pb.MaxValue;
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("shoot") && CanShoot)
        {
            CanShoot = false;
            tm.Start();
            InstanctiateMissile();
        }
        ActualizeProgressBar();
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

    void _on_Timer_timeout()
    {
        CanShoot = true;
    }

    void ActualizeProgressBar()
	{
		pb.Value = pb.MaxValue - (float)tm.TimeLeft;
	}
}
