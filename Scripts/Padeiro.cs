using Godot;
using System;

public partial class Padeiro : CharacterBody2D
{
	float speed = 100f;

	Sprite2D sprite;
	Texture2D padeiroFrente;
	Texture2D padeiroCostas;
	Texture2D padeiroLado;
	PackedScene paoScene;

	// double lastBread = 0;
	// double attackSpeed = 1.5f;

	float fDelta;

	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
		padeiroFrente = GD.Load<Texture2D>("res://Sprites/Padeiro/Padeiro_frente1.png");
		padeiroCostas = GD.Load<Texture2D>("res://Sprites/Padeiro/Padeiro_costas.png");
		padeiroLado = GD.Load<Texture2D>("res://Sprites/Padeiro/Padeiro_lado.png");
		paoScene = ResourceLoader.Load<PackedScene>("res://Cenas/Projeteis/fr_bread.tscn");
	}
	public override void _Process(double delta)
	{	
		
		fDelta = (float)delta;

		Velocity = Andar();
		Atirar();

		MoveAndCollide(Velocity);
	}

	public void Atirar()
	{
		Vector2 inputs = GetInputsShoot();
		
		if (inputs.Y != 0|| inputs.X != 0)
		{
			Node paoInstance = paoScene.Instantiate();
			AddSibling(paoInstance);
		}
		
	}
	public Vector2 GetInputsShoot()
	{
		float up = 0;
		float down = 0;
		float right = 0;
		float left = 0;

		if (Input.IsKeyPressed(Key.Up))
			up = -1;
		if (Input.IsKeyPressed(Key.Left))
			left = -1;
		if (Input.IsKeyPressed(Key.Down))
			down = 1;
		if (Input.IsKeyPressed(Key.Right))
			right = 1;

		// Debug.Print($"X = {left + right} Y = {up + down}");
		return new Vector2(left + right, up + down);
	}
	public Vector2 GetInputsWalk(){
		float up = 0;
		float down = 0;
		float right = 0;
		float left = 0;

		if (Input.IsKeyPressed(Key.W))
			up = -1;
		if (Input.IsKeyPressed(Key.A))
			left = -1;
		if (Input.IsKeyPressed(Key.S))
			down = 1;
		if (Input.IsKeyPressed(Key.D))
			right = 1;

		// Debug.Print($"X = {left + right} Y = {up + down}");
		return new Vector2(left + right, up + down);
	}
	
	public Vector2 Andar()
	{
		Vector2 inputs = GetInputsWalk();

		if (inputs.X != 0 && inputs.Y != 0)
		{
			inputs /= (float)Math.Sqrt(2);
		}
		
		if (inputs.X > 0)
		{
			sprite.Texture = padeiroLado;
			sprite.FlipH = true;
		}
		else if (inputs.X < 0)
		{
			sprite.Texture = padeiroLado;
			sprite.FlipH = false;
		}
		else if (inputs.Y > 0)
		{
			sprite.Texture = padeiroFrente;
			sprite.FlipH = false;
		}
		else if (inputs.Y < 0)
		{
			sprite.Texture = padeiroCostas;
			sprite.FlipH = false;
		}
		inputs *= speed * fDelta;
		return inputs;
		
	}
}
