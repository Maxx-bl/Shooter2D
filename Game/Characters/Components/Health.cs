using Godot;
using System;

public class Health : Node2D
{

    [Export] public float DefaultHP { get; set; }

    public float HP { get; set; }

    public override void _Ready()
    {
        SetHP(DefaultHP);
    }

    public void SetHP(float val)
    {
        HP = val;
    }

    public void Damage(float val)
    {
        HP -= val;
        if (HP <= 0) Death();
    }

    void Death()
    {
        GetParent().QueueFree();
    }
}
