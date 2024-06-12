using Godot;
using System;

public partial class Loading : Control
{
	Transition transition;

    public override void _Ready()
    {
        transition = GetNode<Transition>("/root/Transition");
    }

	void _on_timer_timeout()
	{
		transition.TriggerTransition(this, "res://Game/Maps/Game.tscn");
	}
}