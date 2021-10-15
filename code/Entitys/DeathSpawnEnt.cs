using Sandbox;
using System.Linq;
using System;

[Library( "info_death_spawn", Description = "Spawn a death here" )]
[Hammer.EditorModel( "models/editor/playerstart.vmdl" )]
[Hammer.EntityTool( "Player Spawnpoint", "Death", "Defines a point where the death can (re)spawn" )]
public partial class DeathSpawnEnt : Prop
{

	public override void Spawn()
	{
		base.Spawn();
	}
}
