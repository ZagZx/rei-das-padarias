using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

// Problemas a serem corrigidos: 
// 1º Calculo da hipotenusa errado? o personagem está andando rápido demais quando segura duas direções
// 2º Personagem prefere ir para o lado esquerdo ao pressionar A,D
// Solução 2º: na função CheckPressed() fazer uma checagem para quando duas teclas de direções opostas
// forem pressionadas, retornar ambas as teclas como false

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

		velocity = Andar(velocity, fDelta, direcoes);
		// velocity = Andar(fDelta, velocity);
		// velocity = AndarDiagonal(velocity, fDelta);

		MoveAndCollide(velocity);
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
			{"right",right},
			{"oneKey", false}
		};

		int contador = 0;		
		foreach (string key in direcoes.Keys)
		{
			if (key != "oneKey")
			{
				if (direcoes[key] == true){
					contador += 1;}
			}
		}

		if (contador == 1)
		{
			direcoes["oneKey"] = true;
		}

		foreach (string key in direcoes.Keys){ 
			Debug.WriteLine("Loop:");
			Debug.WriteLine($"{key}:{direcoes[key]}");
		}

		return direcoes;
	}
	public Vector2 Andar(Vector2 velocity, float fDelta, Dictionary<string, bool> direcoes)
	{
		
		if (direcoes["oneKey"]) 
			velocity = AndarReto(velocity, fDelta, direcoes);
		else
			velocity = AndarDiagonal(velocity,fDelta, direcoes);

		
		return velocity;
		
	}
	/// <summary>
	/// Faz o personagem andar quando há apenas uma tecla de movimento pressionada, é importante que faça uma 
	/// checagem das teclas pressionadas com a função CheckPressed() e só execute essa função caso oneKey seja
	/// true no dicionário
	/// </summary>
	public Vector2 AndarReto(Vector2 velocity, float fDelta, Dictionary<string,bool> direcoes)
	{
		if (direcoes["up"])
			velocity.Y -= speed * fDelta;
		else if (direcoes["down"])
			velocity.Y += speed * fDelta;
		else if (direcoes["right"])
			velocity.X += speed * fDelta;
		else if (direcoes["left"])
			velocity.X -= speed * fDelta;
		
		return velocity;
	}
	public Vector2 AndarDiagonal(Vector2 velocity, float fDelta, Dictionary<string, bool> direcoes)
	{
		float diagSpeed = CalcHipotenusa(speed, speed);
		
		if (direcoes["up"] && direcoes["left"])
		{
			velocity.X -= diagSpeed * fDelta;
			velocity.Y -= diagSpeed * fDelta;
		}
		else if (direcoes["up"] && direcoes["right"])
		{
			velocity.X += diagSpeed * fDelta;
			velocity.Y -= diagSpeed * fDelta;
		}
		else if (direcoes["down"] && direcoes["left"])
		{
			velocity.X -= diagSpeed * fDelta;
			velocity.Y += diagSpeed * fDelta;
		}
		else if (direcoes["down"] && direcoes["right"])
		{
			velocity.X += diagSpeed * fDelta;
			velocity.Y += diagSpeed * fDelta;
		}

		return velocity;
	} 
	public float CalcHipotenusa(float cateto1, float cateto2)
	{
		// h = raiz quadrada de (c1² + c2²)
		return (float)Math.Sqrt(Math.Pow(cateto1,2) + Math.Pow(cateto2, 2));
	}
}
