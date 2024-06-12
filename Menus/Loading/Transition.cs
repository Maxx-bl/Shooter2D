using Godot;
using System;

public partial class Transition : CanvasLayer
{
	[Export] ColorRect colorRect;
	[Export] AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        colorRect.Visible = false;
    }

	public async void TriggerTransition(Node oldNode, string sceneName)
	{
		colorRect.Visible = true;
		animationPlayer.Play("fade_to_black");
		await ToSignal(GetTree().CreateTimer(0.5), "timeout");
		PackedScene scene = GD.Load<PackedScene>(sceneName);
		var node = scene.Instantiate();
		AddSibling(node);
		oldNode.QueueFree();
	}

	void _on_animation_player_animation_finished(string animationName)
	{
		if (animationName == "fade_to_black") {
			animationPlayer.Play("fade_to_normal");
		} else if (animationName == "fade_to_normal") {
			colorRect.Visible = false;
		}
	}
}
