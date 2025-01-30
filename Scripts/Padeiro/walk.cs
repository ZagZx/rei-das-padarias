using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

// não ta funcionando instanciar cena
public partial class walk : CharacterBody2D
{
	float speed = 100f;

	Sprite2D sprite;
	Texture2D padeiroFrente;
	Texture2D padeiroCostas;
	PackedScene paoScene;
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
		padeiroFrente = GD.Load<Texture2D>("res://Sprites/Padeiro/Padeiro_frente1.png");
		padeiroCostas = GD.Load<Texture2D>("res://Sprites/Padeiro/Padeiro_costas.png");
		paoScene = ResourceLoader.Load<PackedScene>("res://Cenas/Projeteis/fr_bread.tscn");
	}
	public override void _Process(double delta)
	{	
		float fDelta = (float)delta;

		Velocity = Andar(fDelta);
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

		if (Input.IsActionJustPressed("ui_up"))
			up = -1;
		if (Input.IsActionJustPressed("ui_left"))
			left = -1;
		if (Input.IsActionJustPressed("ui_down"))
			down = 1;
		if (Input.IsActionJustPressed("ui_right"))
			right = 1;

		Debug.Print($"X = {left + right} Y = {up + down}");
		return new Vector2(left + right, up + down);
	}
	/// <summary>
	/// Checa as teclas pressionadas e retorna um Vector2
	/// </summary>
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
	
	public Vector2 Andar(float fDelta)
	{
		Vector2 inputs = GetInputsWalk();

		if (inputs.X != 0 && inputs.Y != 0)
		{
			inputs /= (float)Math.Sqrt(2);
		}
		if (inputs.Y > 0)
		{
			sprite.Texture = padeiroFrente;
		}
		else if (inputs.Y < 0)
		{
			sprite.Texture = padeiroCostas;
		}

		inputs *= speed * fDelta;
		return inputs;
		
	}
}
