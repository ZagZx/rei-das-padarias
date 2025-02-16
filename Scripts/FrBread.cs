using Godot;

public partial class FrBread : Area2D
{	
	float breadSpeed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Scale = new Vector2(0.3f, 0.3f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		

	}

	public void SerAtirado(Vector2 direcoes)
	{
		
		Rotate(0.2f);


	} 
}
