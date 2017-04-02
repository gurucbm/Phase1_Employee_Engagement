import * as ko from "knockout"
import * as Controllers from "Controllers/IController"

class MenuItem
{
	constructor(
		public Title: String
	,	public Href	: String
	,	public Icon	: String
	)
	{
		this.IsActive = ko.computed(() => window.location.pathname == this.Href);
	}

	IsActive: KnockoutComputed<Boolean>;
}

class SideNavbarController
	implements Controllers.IController
{
	Items: KnockoutObservableArray<MenuItem>;

	constructor()
	{
		this.Items = ko.observableArray<MenuItem>(
			[
				new MenuItem("Dashboard", "/", "dashboard")
			,	new MenuItem("Reviews", "/Reviews/Members", "star-half-full")
			,	new MenuItem("Team", "/Configure/Team", "group")
            , new MenuItem("Reports", "/Reports", "bar-chart")
            , new MenuItem("UserAdministration", "/Administer/Users", "gears")
//			,	new MenuItem("Account", "/Configure/Account", "gear")
			//,	new MenuItem("Logout", "/Account/Logout", "sign-out")
			]
		);
	}
}

export default () => new SideNavbarController();