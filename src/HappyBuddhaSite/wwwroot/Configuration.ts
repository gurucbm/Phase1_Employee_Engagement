
requirejs.config(
	{
		baseUrl: "/",
		paths: {
			"knockout"			: "Framework/knockout/knockout-latest"
		,	"knockout.mapping"	: "Framework/knockout/knockout.mapping"
		,	"jquery"			: "Framework/jquery.min"
		,	"jquery-mousewheel"	: "Framework/jquery.mousewheel"
		,	"nprogress"			: "Framework/nprogress/nprogress"
		,	"bloodhound"		: "Framework/typeahead.js/bloodhound"
		,	"typeahead"			: "Framework/typeahead.js/typeahead.jquery"
		,	"handlebars"		: "Framework/handlebars/handlebars"
		}
	,	shim: {
			"knockout.mapping": [
				"knockout"
			]
		}
	}
);

requirejs(["BindingHandlers", "jquery", "nprogress", "knockout"]);