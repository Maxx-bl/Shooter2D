using Godot;
using System;

public partial class MainMenu : Control
{
	void _on_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://");
	}
}
