define(["require", "exports", "knockout"], function (require, exports, ko) {
    "use strict";
    var App = (function () {
        function App() {
            this.Model = ko.observable({
                Title: ""
            });
        }
        return App;
    }());
    exports.__esModule = true;
    exports["default"] = function () { return new App(); };
});
//# sourceMappingURL=Application.js.map