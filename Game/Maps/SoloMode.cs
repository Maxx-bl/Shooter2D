using Godot;
using System;

public class SoloMode : TileMap
{

    Timer TimerSpawnBots;

    public override void _Ready()
    {
        TimerSpawnBots = GetNode<Timer>("TimerSpawnBots");
        TimerSpawnBots.WaitTime = 5f;
    }

    void InstantiateBot()
    {
        Random ran = new Random();
        Node2D BotSpawPoint = GetNode<Node2D>($"Spawns/Bot{ran.Next(1, 5)}");
        PackedScene botScene = GD.Load<PackedScene>("res://Game/Characters/Bot/Bot.tscn");
        KinematicBody2D bot = botScene.Instance<KinematicBody2D>();
        bot.Position = BotSpawPoint.Position;
        AddChild(bot);
    }

    void _on_TimerSpawnBots_timeout()
    {
        InstantiateBot();
    }
}
