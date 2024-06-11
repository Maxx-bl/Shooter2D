using Godot;
using System;

public partial class Cannon : Node2D
{
	public bool CanShoot { get; set; } = true;

    [Export] ProgressBar progressBar;
    [Export] Timer timer;
    Damages damages;

    public override void _Ready()
    {
        damages = GetParent().GetNode<Damages>("Damages");
        timer.WaitTime = (float)progressBar.MaxValue;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("shoot") && CanShoot)
        {
            CanShoot = false;
            progressBar.SelfModulate = new Color(255, 0, 0, 1);
            timer.Start();
            InstanctiateMissile();
        }
        ActualizeProgressBar();
    }

    void InstanctiateMissile()
    {
        PackedScene missileScene = GD.Load<PackedScene>("res://Game/Characters/Components/Missile/Missile.tscn");
        Missile missile = missileScene.Instantiate<Missile>();
        missile.Target = GetGlobalMousePosition();
        missile.Cannon = GlobalPosition;
        missile.Position = GlobalPosition;
        missile.GetNode<Damages>("Damages").Damage = damages.Damage;
        GetParent().GetParent().AddChild(missile);
    }

    void _on_timer_timeout()
    {
        CanShoot = true;
        progressBar.SelfModulate = new Color(0, 255, 0, 1);
    }

    void ActualizeProgressBar()
	{
		progressBar.Value = progressBar.MaxValue - (float)timer.TimeLeft;
	}
}
