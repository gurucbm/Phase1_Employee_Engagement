define(["require", "exports", "knockout"], function (require, exports, ko) {
    "use strict";
    var MenuItem = (function () {
        function MenuItem(Title, Href, Icon) {
            var _this = this;
            this.Title = Title;
            this.Href = Href;
            this.Icon = Icon;
            this.IsActive = ko.computed(function () { return window.location.pathname == _this.Href; });
        }
        return MenuItem;
    }());
    var SideNavbarController = (function () {
        function SideNavbarController() {
            this.Items = ko.observableArray([
                new MenuItem("Dashboard", "/", "dashboard"),
                new MenuItem("Reviews", "/Reviews/Members", "star-half-full"),
                new MenuItem("Team", "/Configure/Team", "group"),
                new MenuItem("Reports", "/Reports", "bar-chart"),
                new MenuItem("UserAdministration", "/Administer/Users", "gears")
            ]);
        }
        return SideNavbarController;
    }());
    exports.__esModule = true;
    exports["default"] = function () { return new SideNavbarController(); };
});
//# sourceMappingURL=Navbar.js.map