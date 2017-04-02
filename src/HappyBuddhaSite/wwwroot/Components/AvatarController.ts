import * as $ from "jquery"
import * as ko from "knockout"
import * as NProgress from "nprogress"
import "knockout.mapping"

import * as Controllers from "Controllers/IController"

class AvatarViewModel
{
	Id: KnockoutObservable<String>;
	IsSelected: KnockoutObservable<Boolean>;

	constructor()
	{
		this.Id = ko.observable<String>();

		this.IsSelected = ko.observable(false);
	}
}

class AvatarController
	implements Controllers.IController
{
	Items: KnockoutObservableArray<AvatarViewModel>;

	AvatarId: KnockoutObservable<String>;

	CanAdd: KnockoutObservable<Boolean>;

	constructor()
	{
		this.AvatarId = ko.observable<String>();

		this.Items = ko.observableArray<AvatarViewModel>();
		
		this.CanAdd = ko.observable<Boolean>();

		this.Refresh();
	}

	Refresh() : void
	{
		var $this = this;

		$.getJSON(
			"/api/Avatar/CanAdd"
		,	function (Data)
			{
				$this.CanAdd(Data.Result);
			}
		);

		$.getJSON(
			"/api/Avatar"
		,	function(data)
			{
				var IsAnythingSelected : Boolean = false;

				$this.Items.removeAll();

				$.each(
					data
				,	(Item) =>
					{
						Item = data[Item];

						if (Item.IsSelected === null)

							Item.IsSelected = false;

						else if (Item.IsSelected === true)

							IsAnythingSelected = true;

						var i = new AvatarViewModel();

						ko.mapping.fromJS(Item, null, i);

						$this.Items.push(i);
					}
				);

				if (IsAnythingSelected == false)
				{
					ko.utils.arrayFirst(
						$this.Items()
					,	(ListItem: AvatarViewModel) =>
						{
							$this.Select(ListItem);

							return true;
						}
					);
				}
			}
		);
	}

	Upload(File: any) : void
	{
		var $this = this;

        var data = new FormData();

		data.append(File.name, File);

		$.ajax(
			{
				type: "POST",
				url: "/api/Avatar",
				contentType: false,
				processData: false,
				data: data,
				success: (dataRet) =>
				{
					$this.Refresh();
				},
				error: () =>
				{
					alert("There was error uploading files!");
				}
			}
		);
	}

	Select(TargetItem) : void
	{
		ko.utils.arrayForEach(
			this.Items()
		,	(Item, Index) =>
			{
				if (Item == TargetItem)
				{
					Item.IsSelected(true);

					this.AvatarId(Item.Id());
				}
				else Item.IsSelected(false);
			}
		);
	}

	New(FileInput: any) : void
	{
		FileInput.trigger('click');
	}
}

export default () => new AvatarController();