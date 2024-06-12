using Godot;
using System;

public partial class MainMenu : Control
{

	Transition transition;

    public override void _Ready()
    {
        transition = GetNode<Transition>("/root/Transition");
    }

    void _on_play_pressed()
	{
		transition.TriggerTransition(this, "res://Menus/Loading/Loading.tscn");
	}

	void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}
