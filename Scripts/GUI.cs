using Godot;
using System;

public class GUI : MarginContainer
{


private Label WashLabel;
private Label BroomLabel;
private Label TrashLabel;

    public override void _Ready()
    {
        WashLabel = (Label)GetNode("WashLabel");
        BroomLabel = (Label)GetNode("BroomLabel");
        TrashLabel = (Label)GetNode("TrashLabel");
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
