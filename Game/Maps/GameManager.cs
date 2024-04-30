using Godot;
using System;

public class GameManager : Node2D
{

    public override void _Ready()
    {
        PackedScene playerScene = GD.Load<PackedScene>("res://Game/Characters/Player.tscn");
        KinematicBody2D player = playerScene.Instance<KinematicBody2D>();
        AddChild(player);
    }

}
