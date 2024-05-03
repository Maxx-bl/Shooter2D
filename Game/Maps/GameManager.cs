using Godot;
using System;

public class GameManager : Node2D
{

    Node2D SpawnPoint;
    Node2D Nav;

    public override void _Ready()
    {
        Nav = GetNode<Node2D>("Navigation2D");
        InstantiateMap();

        SpawnPoint = GetNode<Node2D>("Navigation2D/TileMap/Spawns/P1");
        InstantiatePlayer();
    }

    void InstantiateMap()
    {
        PackedScene mapScene = GD.Load<PackedScene>("res://Game/Maps/SoloMode.tscn");
        TileMap map = mapScene.Instance<TileMap>();
        Nav.AddChild(map);
    }

    void InstantiatePlayer()
    {
        PackedScene playerScene = GD.Load<PackedScene>("res://Game/Characters/Player/Player.tscn");
        KinematicBody2D player = playerScene.Instance<KinematicBody2D>();
        player.Position = SpawnPoint.Position;
        AddChild(player);
    }

}
