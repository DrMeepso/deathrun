using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Role : Panel
{
	public Label Roletext;
	public Panel RoleBG;
	public Role()
	{
		StyleSheet.Load( "/ui/Role.scss" );

		RoleBG = Add.Panel( "RoleBG" );

		Roletext = RoleBG.Add.Label( "0", "textRole" );

	}

	public override void Tick()
	{
		base.Tick();

		var bruh = Local.Pawn as GamePlayer;

		//Roletext.Style.FontFamily = "Source Code Pro";
		Roletext.Text = bruh.isDesth + "";
		if ( bruh.isSpectating is false )
		{
			if ( bruh.isDesth )
			{
				Roletext.Text = "Death!";
				Roletext.Style.FontColor = "#de5b5b";
			}
			else
			{
				Roletext.Text = "Player!";
				Roletext.Style.FontColor = "#6E85B2";
			}
		} else
		{
			Roletext.Text = "Spectating";
			Roletext.Style.FontColor = "#6E85B2";
		}
	}
}
