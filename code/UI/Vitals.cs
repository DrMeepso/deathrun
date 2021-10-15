using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

/*
Color Palette
https://colorhunt.co/palette/261c2c3e2c415c527f6e85b2
*/
public partial class Vitals : Panel
{
	private Label Health;
	private Panel HealthBar;
	private float HealthbarSize;
	private Panel healthIconBackText;
	private Panel healthText;

	public Vitals()
	{
		StyleSheet.Load( "/ui/Vitals.scss" );

		Panel HealthBack = Add.Panel( "healthBack" );

		Panel healthIconBack = HealthBack.Add.Panel( "healthIconBack" );
		healthIconBack.Add.Label( "favorite", "healthIcon" );

		Panel healthBarBack = HealthBack.Add.Panel( "healthBarBack" );
		HealthBar = healthBarBack.Add.Panel( "healthBar" );

		Health = HealthBack.Add.Label( "0", "healthText" );
	}

	public override void Tick()
	{
		base.Tick();

		var player = Local.Pawn;
		if ( player == null ) return;
		Health.Text = $"{HealthbarSize.CeilToInt()}%";

		HealthBar.Style.Dirty();
		HealthbarSize = HealthbarSize * (1f - 0.5f) + player.Health * 0.5f;
		HealthBar.Style.Width = Length.Percent( HealthbarSize );

		HealthBar.Style.BackgroundColor = $"rgb({222 * (1 - HealthbarSize / 100) + 110 * HealthbarSize / 100}, {133 * (1 - HealthbarSize / 100) + 133 * HealthbarSize / 100}, {178 * (1 - HealthbarSize / 100) + 178 * HealthbarSize / 100})";

		if ( Input.Pressed( InputButton.Menu ) )
		{
			player.TakeDamage( DamageInfo.Generic( 10 ) );
			Log.Error( "Dammage" );
		}

	}
}
