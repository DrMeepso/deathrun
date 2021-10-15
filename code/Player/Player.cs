using Sandbox;
using System.Linq;
using System;

partial class GamePlayer : Player
{
	[Net]
	public bool isDesth { get; set; }
	[Net]
	public bool isSpectating { get; set; }
	[Net]
	public int playerID { get; set; }

	public override void Respawn()
	{


		if ( isSpectating )
		{
			Controller = new NoclipController();
			Camera = new FirstPersonCamera();
			SetModel( "models/citizen_props/foamhand.vmdl" );
			EnableAllCollisions = false;
		}
		else
		{
			SetModel( "models/citizen/citizen.vmdl" );

			// Use WalkController for movement (you can make your own PlayerController for 100% control)
			Controller = new WalkController();

			// Use StandardPlayerAnimator  (you can make your own PlayerAnimator for 100% control)
			Animator = new StandardPlayerAnimator();

			// Use ThirdPersonCamera (you can make your own Camera for 100% control)
			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

		}

		base.Respawn();

		if ( isDesth )
		{
			Position = Entity.All.OfType<DeathSpawnEnt>().First<DeathSpawnEnt>().Position;
			Rotation = Entity.All.OfType<DeathSpawnEnt>().First<DeathSpawnEnt>().Rotation;
		}
	}


	public override void Simulate( Client cl )
	{
		base.Simulate( cl );
			if ( isSpectating is false )
			{
				TickPlayerUse();
			}
		}

	public override void OnKilled()
	{
		base.OnKilled();
		isSpectating = true;
		if ( IsServer is false ) return;
		if ( isDesth )
		{
			Log.Info( "Death is dead, Players win!" );


			foreach ( GamePlayer player in All.OfType<GamePlayer>() )
			{
				if ( player.isSpectating is false )
				{
					player.isSpectating = true;
					player.isDesth = false;
					player.Respawn();
				}

			}
			return;
		}

		var alive = 0;
		foreach ( GamePlayer player in All.OfType<GamePlayer>() )
		{
				if ( player.isSpectating == false )
				{
					++alive;
				}
		}

		if ( alive <= 1 )
		{
			Log.Info( "Death has won, All the players are dead" );

			foreach ( GamePlayer player in All.OfType<GamePlayer>() )
			{
				if ( player.isSpectating == false )
				{
					player.isSpectating = true;
					player.isDesth = false;
					player.Respawn();
				}

			}
		}

		Respawn();
	}
}
