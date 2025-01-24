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
		Dictionary<string, bool> direcoes = CheckPressed();

		// velocity = Andar(fDelta, velocity);
		// velocity = AndarDiagonal(velocity, fDelta);

		// MoveAndCollide(velocity);
	}

	/// <summary>
	/// Checa as teclas pressionadas e retorna um dicionário com as chaves WASD e valores booleanos
	/// </summary>
	public Dictionary<string, bool> CheckPressed()
	{	
		bool up = false;
		bool down = false;
		bool right = false;
		bool left = false;

		if (Input.IsKeyPressed(Key.W))
			up = true;
		if (Input.IsKeyPressed(Key.A))
			left = true;
		if (Input.IsKeyPressed(Key.S))
			down = true;
		if (Input.IsKeyPressed(Key.D))
			right = true;
		
		Dictionary<string,bool> direcoes = new Dictionary<string, bool>()
		{
			{"up",up},
			{"down",down},
			{"left",left},
			{"right",right}
		};

		// foreach (string key in direcoes.Keys){
		// 	Debug.WriteLine("Loop:");
		// 	Debug.WriteLine($"{key}:{direcoes[key]}");
		// }

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

	public Vector2 AndarReto(Vector2 velocity, float fDelta, Dictionary<string,bool> direcoes)
	{

		
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
