using Godot;
using System;

public class Area2D : Godot.Area2D
{   
    bool BodyStayOnCollisionShape ;
    int PlayerCollision = 0;

    public override void _Ready()
    {
        Connect("body_entered", this, nameof(OnBodyEntered));
        Connect("body_exited", this, nameof(OnBodyExited));
       // GD.Print("START ! ");
    }

    public void OnBodyEntered(Node body)
    {
        BodyStayOnCollisionShape = true;

        if(body is Player )
        {
             PlayerCollision +=1;
           // GD.Print("Entrer dans zone ! ");
        }
    }

    public void OnBodyExited(Node body)
    {
        BodyStayOnCollisionShape = false; 

        if(body is Player)
        {   PlayerCollision = 0;
           // GD.Print("Sortie de zone ! ");
        }
    }

    public override void _Process(float delta)
    {       
        var animatedSprite = GetNode <AnimatedSprite>("AnimatedSprite");
        if (Input.IsActionJustPressed("ui_select") && BodyStayOnCollisionShape && PlayerCollision==1)
        {
           // GD.Print("Interaction OK !");
            animatedSprite.Animation = "done";   
        }
    }
}
