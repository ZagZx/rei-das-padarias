using Godot;
using System.Diagnostics;

public partial class Menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TextureButton jogar = GetNode<TextureButton>("Jogar");
		jogar.Connect("pressed", Callable.From(() => OnPressPlay()));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnPressPlay()
	{
		GetTree().ChangeSceneToFile("res://Cenas/Main.tscn");
		Debug.Print("apertei");
	}
}
