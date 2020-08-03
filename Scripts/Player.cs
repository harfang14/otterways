using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    public int Speed = 280;
    private Vector2 _screenSize;

    public override void _Ready()
    { 
        _screenSize = GetViewport().Size;
       // GD.Print ("Joueur prêt"); 
    }
    public override void _PhysicsProcess(float delta)
    {
        var velocity = new Vector2(); 

        if (Input.IsActionPressed("ui_right"))
        {
            velocity.x += 1; 
        }

        if (Input.IsActionPressed("ui_left"))
        {
            velocity.x -= 1;
        }

        if (Input.IsActionPressed("ui_down"))
        {
            velocity.y += 1;
        }

        if (Input.IsActionPressed("ui_up"))
        {
            velocity.y -= 1;
        }

        var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

        if (velocity.Length() > 0)
        {
            velocity = MoveAndSlide(velocity) * Speed;
            animatedSprite.Play();
        }
        else
        {
            animatedSprite.Stop();
        }

        Position += velocity * delta;
        Position = new Vector2(
        x: Mathf.Clamp(Position.x, 0, _screenSize.x),
        y: Mathf.Clamp(Position.y, 0, _screenSize.y));

        if (velocity.x != 0)
        {
            animatedSprite.Animation = "walk";
            animatedSprite.FlipV = false;
            animatedSprite.FlipH = velocity.x < 0;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventKey eventKey)
        if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape)
            GetTree().Quit();
    }
}


