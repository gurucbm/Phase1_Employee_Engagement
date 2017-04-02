import * as $ from "jquery"
import * as ko from "knockout"

import * as Controllers from "Controllers/IController"

class ProfileController
	implements Controllers.IController
{
	constructor()
	{
		this.Refresh();
	}

	Refresh() : void
	{
		var $this = this;
	}
}

export default () => new ProfileController();