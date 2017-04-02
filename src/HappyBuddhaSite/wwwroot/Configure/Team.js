define(["require", "exports", "jquery", "knockout", "nprogress", "knockout.mapping"], function (require, exports, $, ko, NProgress) {
    "use strict";
    var EnumValue = (function () {
        function EnumValue(Id, Title) {
            this.Id = Id;
            this.Title = Title;
        }
        return EnumValue;
    }());
    var TeamViewModel_Mapping = {
        ignore: [
            "LeadOptions",
            "DirectorOptions",
            "VicePresidentOptions",
            "CloseEntryOptions",
            "CycleOptions"
        ]
    };
    var TeamViewModel = (function () {
        function TeamViewModel() {
            this.Id = ko.observable();
            this.Name = ko.observable();
            this.Cycle = ko.observable(new EnumValue(1, "Weekly"));
            this.CycleOptions = ko.observableArray([
                this.Cycle(),
                new EnumValue(2, "Bi-Weekly"),
                new EnumValue(3, "Monthly")
            ]);
            this.CloseEntryDays = ko.observable(new EnumValue(1, "3"));
            this.CloseEntryOptions = ko.observableArray([
                this.CloseEntryDays(),
                new EnumValue(2, "4"),
                new EnumValue(3, "5"),
                new EnumValue(4, "6"),
                new EnumValue(5, "7")
            ]);
            this.Lead = ko.observable();
            this.Director = ko.observable();
            this.VicePresident = ko.observable();
            this.LeadOptions = ko.observableArray();
            this.DirectorOptions = ko.observableArray();
            this.VicePresidentOptions = ko.observableArray();
            this.CurrentCycle = new Date();
            this.NextCycle = new Date();
            this.UsePreviousReview = false;
        }
        return TeamViewModel;
    }());
    ;
    var ConfigureTeamController = (function () {
        function ConfigureTeamController() {
            this.Items = ko.observableArray();
            var $this = this;
            $.getJSON("/api/Team", function (data) {
                if (data.length == 0)
                    $this.AddNew();
                else {
                    var ViewModel = new TeamViewModel();
                    ko.mapping.fromJS(data[0], TeamViewModel_Mapping, ViewModel);
                    $this.Items.push(ViewModel);
                }
            });
        }
        ConfigureTeamController.prototype.AddNew = function () {
            this.Items.push(new TeamViewModel());
        };
        ConfigureTeamController.prototype.Submit = function (Item) {
            NProgress.start();
            $.ajax({
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                },
                type: "POST",
                url: "/api/Team",
                data: ko.mapping.toJSON(Item, TeamViewModel_Mapping),
                dataType: "json",
                success: function (data) {
                    NProgress.done();
                },
                error: function (data) {
                    NProgress.done();
                }
            });
        };
        return ConfigureTeamController;
    }());
    exports.__esModule = true;
    exports["default"] = function () { return new ConfigureTeamController(); };
});
//# sourceMappingURL=Team.js.map