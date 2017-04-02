import * as $ from "jquery"
import * as ko from "knockout"
import * as NProgress from "nprogress"
import "knockout.mapping"

import * as Controllers from "Controllers/IController"

class EnumValue
{
	Id: Number;
	Title: String;

	constructor(Id: Number, Title: String)
	{
		this.Id = Id;

		this.Title = Title;
	}
}

var TeamViewModel_Mapping = {
	ignore: [
		"LeadOptions"
	,	"DirectorOptions"
	,	"VicePresidentOptions"
	,	"CloseEntryOptions"
	,	"CycleOptions"
	]
};

class TeamViewModel
{
	Id: KnockoutObservable<String>;

	Name: KnockoutObservable<String>;

	CycleOptions: KnockoutObservableArray<EnumValue>;
	Cycle: KnockoutObservable<EnumValue>;

	CloseEntryOptions: KnockoutObservableArray<EnumValue>;
	CloseEntryDays: KnockoutObservable<EnumValue>;

	LeadOptions: KnockoutObservableArray<EnumValue>;
	Lead: KnockoutObservable<EnumValue>;

	DirectorOptions: KnockoutObservableArray<EnumValue>;
	Director: KnockoutObservable<EnumValue>;

	VicePresidentOptions: KnockoutObservableArray<EnumValue>;
	VicePresident: KnockoutObservable<EnumValue>;

	CurrentCycle: Date;
	NextCycle: Date;

	UsePreviousReview: Boolean;

	constructor()
	{
		this.Id = ko.observable<String>();

		this.Name = ko.observable<String>();

		this.Cycle = ko.observable<EnumValue>(new EnumValue(1, "Weekly"));
		this.CycleOptions = ko.observableArray<EnumValue>(
			[
				this.Cycle()
			,	new EnumValue(2, "Bi-Weekly")
			,	new EnumValue(3, "Monthly")
			]
		);

		this.CloseEntryDays = ko.observable<EnumValue>(new EnumValue(1, "3"));
		this.CloseEntryOptions = ko.observableArray<EnumValue>(
			[
				this.CloseEntryDays()
			,	new EnumValue(2, "4")
			,	new EnumValue(3, "5")
			,	new EnumValue(4, "6")
			,	new EnumValue(5, "7")
			]
		);

		this.Lead = ko.observable<EnumValue>();
		this.Director = ko.observable<EnumValue>();
		this.VicePresident = ko.observable<EnumValue>();

		this.LeadOptions = ko.observableArray<EnumValue>();
		this.DirectorOptions = ko.observableArray<EnumValue>();
		this.VicePresidentOptions = ko.observableArray<EnumValue>();

		this.CurrentCycle = new Date();

		this.NextCycle = new Date();

		this.UsePreviousReview = false;
	}
};

class ConfigureTeamController
	implements Controllers.IController
{
	Items: KnockoutObservableArray<TeamViewModel>;

	constructor()
	{
		this.Items = ko.observableArray<TeamViewModel>();

		var $this = this;

		$.getJSON(
			"/api/Team"
		,	function(data)
			{
				if (data.length == 0)

					$this.AddNew();

				else
				{
					var ViewModel = new TeamViewModel();

					ko.mapping.fromJS(data[0], TeamViewModel_Mapping, ViewModel);

					$this.Items.push(ViewModel);
				}
			}
		);
	}

	AddNew(): void
	{
		this.Items.push(
			new TeamViewModel()
		);
	}

	Submit(Item) : void
	{
		NProgress.start();

		$.ajax(
			{
				headers: { 
					"Accept": "application/json"
				,	"Content-Type": "application/json"
				}
			,	type: "POST"
			,	url: "/api/Team"
			,	data: ko.mapping.toJSON(Item, TeamViewModel_Mapping)
			,	dataType: "json"
			,	success: function(data)
				{
					NProgress.done();
				}
			,	error: function(data)
				{
					NProgress.done();
				}
			}
		);
	}
}

export default () => new ConfigureTeamController();