using Godot;
using System;
using System.Collections.Generic;

public partial class walk : CharacterBody2D
{
	float speed = 50f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		float fDelta = (float)delta;
		Vector2 velocity = Velocity;

		// velocity = Andar(fDelta, velocity);

		velocity = AndarDiagonal(velocity, fDelta);

		MoveAndCollide(velocity);
	}

	public bool[] CheckPressed()
	{	
		bool up = false;
		bool down = false;
		bool right = false;
		bool left = false;

		if (Input.IsKeyPressed(Key.Up) || Input.IsKeyPressed(Key.W))
		{}

		bool[] direcoes = new bool[4]{up, down, left, right};
		
		return direcoes;
	}
	public Vector2 Andar(Vector2 velocity, float fDelta)
	{
		
		// if (Input.IsAnythingPressed())
		// {
		// 	if (Input.IsKeyPressed(Key.W) || Input.IsKeyPressed(Key.Up))
		// 	{
		// 		velocity.Y -= speed * fDelta;
		// 	}
		// 	if (Input.IsKeyPressed(Key.S) || Input.IsKeyPressed(Key.Down))
		// 	{
		// 		velocity.Y += speed * fDelta;
		// 	}
		// 	if (Input.IsKeyPressed(Key.D) || Input.IsKeyPressed(Key.Right))
		// 	{
		// 		velocity.X += speed * fDelta;
		// 	}
		// 	if (Input.IsKeyPressed(Key.A) || Input.IsKeyPressed(Key.Left))
		// 	{
		// 		velocity.X -= speed * fDelta;
		// 	}
		// }
		return velocity;
		
	}

	public Vector2 AndarDiagonal(Vector2 velocity, float fDelta)
	{
		float diagSpeed = CalcHipotenusa(speed, speed);

		if (Input.IsKeyPressed(Key.W) && Input.IsKeyPressed(Key.A))
		{
			velocity.X -= diagSpeed * fDelta;
			velocity.Y -= diagSpeed * fDelta;
		}

		return velocity;
	}
	public float CalcHipotenusa(float cateto1, float cateto2)
	{
		// h = raiz quadrada de (c1² + c2²)
		return (float)Math.Sqrt(Math.Pow(cateto1,2) + Math.Pow(cateto2, 2));
	}
}
