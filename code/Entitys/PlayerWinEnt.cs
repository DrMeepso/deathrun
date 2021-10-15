using Sandbox;
using System.Linq;
using System;

[Library( "info_player_win", Description = "Player Win Zone" )]
[Hammer.Solid]
[Hammer.EntityTool( "Player Winpoint", "Win", "Defines a point where a player can win the game" )]
public partial class PlayerWinEnt : Prop
{

	public override void Spawn()
	{
		base.Spawn();
	}

	public override void Touch( Entity other )
	{
		if ( other is GamePlayer player )


		if ( player.isDesth is true ) return;
			

		if ( IsServer )
		{
			Log.Info( "Players Win, They Reached The End!" );
			foreach ( GamePlayer playerloop in All.OfType<GamePlayer>() )
			{
				if ( playerloop.isSpectating is false )
				{
					playerloop.isSpectating = true;
					playerloop.isDesth = false;
					playerloop.Respawn();
				}

			}
		}
		base.Touch( other );
	}
}
