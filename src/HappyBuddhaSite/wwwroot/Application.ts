import * as Controllers from "Controllers/IController"
import * as ko from "knockout"

class App
	implements Controllers.IController
{
	Model: KnockoutObservable<any>

	constructor()
	{
		this.Model = ko.observable(
			{
				Title: ""
			}
		);
	}
}

export default () => new App();