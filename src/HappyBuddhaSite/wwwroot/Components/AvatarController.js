define(["require", "exports", "jquery", "knockout", "knockout.mapping"], function (require, exports, $, ko) {
    "use strict";
    var AvatarViewModel = (function () {
        function AvatarViewModel() {
            this.Id = ko.observable();
            this.IsSelected = ko.observable(false);
        }
        return AvatarViewModel;
    }());
    var AvatarController = (function () {
        function AvatarController() {
            this.AvatarId = ko.observable();
            this.Items = ko.observableArray();
            this.CanAdd = ko.observable();
            this.Refresh();
        }
        AvatarController.prototype.Refresh = function () {
            var $this = this;
            $.getJSON("/api/Avatar/CanAdd", function (Data) {
                $this.CanAdd(Data.Result);
            });
            $.getJSON("/api/Avatar", function (data) {
                var IsAnythingSelected = false;
                $this.Items.removeAll();
                $.each(data, function (Item) {
                    Item = data[Item];
                    if (Item.IsSelected === null)
                        Item.IsSelected = false;
                    else if (Item.IsSelected === true)
                        IsAnythingSelected = true;
                    var i = new AvatarViewModel();
                    ko.mapping.fromJS(Item, null, i);
                    $this.Items.push(i);
                });
                if (IsAnythingSelected == false) {
                    ko.utils.arrayFirst($this.Items(), function (ListItem) {
                        $this.Select(ListItem);
                        return true;
                    });
                }
            });
        };
        AvatarController.prototype.Upload = function (File) {
            var $this = this;
            var data = new FormData();
            data.append(File.name, File);
            $.ajax({
                type: "POST",
                url: "/api/Avatar",
                contentType: false,
                processData: false,
                data: data,
                success: function (dataRet) {
                    $this.Refresh();
                },
                error: function () {
                    alert("There was error uploading files!");
                }
            });
        };
        AvatarController.prototype.Select = function (TargetItem) {
            var _this = this;
            ko.utils.arrayForEach(this.Items(), function (Item, Index) {
                if (Item == TargetItem) {
                    Item.IsSelected(true);
                    _this.AvatarId(Item.Id());
                }
                else
                    Item.IsSelected(false);
            });
        };
        AvatarController.prototype.New = function (FileInput) {
            FileInput.trigger('click');
        };
        return AvatarController;
    }());
    exports.__esModule = true;
    exports["default"] = function () { return new AvatarController(); };
});
//# sourceMappingURL=AvatarController.js.map