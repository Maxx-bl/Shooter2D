using Godot;
using System;

public class Cannon : Node2D
{

    public bool CanShoot { get; set; } = true;

    ProgressBar pb;
    Timer tm;

    Damages Damages;

    public override void _Ready()
    {
        Damages = GetParent().GetNode<Damages>("Damages");
        pb = GetNode<ProgressBar>("Reload");
        tm = GetNode<Timer>("Reload/Timer");
        tm.WaitTime = (float)pb.MaxValue;
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("shoot") && CanShoot)
        {
            CanShoot = false;
            pb.SelfModulate = new Color(255, 0, 0, 1);
            tm.Start();
            InstanctiateMissile();
        }
        ActualizeProgressBar();
    }

    void InstanctiateMissile()
    {
        PackedScene missileScene = GD.Load<PackedScene>("res://Game/Misc/Missile/Missile.tscn");
        Missile missile = missileScene.Instance<Missile>();
        missile.Target = GetGlobalMousePosition();
        missile.Cannon = GlobalPosition;
        missile.Position = GlobalPosition;
        missile.GetNode<Damages>("Damages").Damage = Damages.Damage;
        GetParent().GetParent().AddChild(missile);
    }

    void _on_Timer_timeout()
    {
        CanShoot = true;
        pb.SelfModulate = new Color(0, 255, 0, 1);
    }

    void ActualizeProgressBar()
	{
		pb.Value = pb.MaxValue - (float)tm.TimeLeft;
	}
}
