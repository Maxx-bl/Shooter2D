using Godot;
using System;

public class MainMenu : Control
{
    void _on_Button_pressed()
    {
        GetTree().ChangeScene("res://Game/Maps/Map.tscn");
    }
}
