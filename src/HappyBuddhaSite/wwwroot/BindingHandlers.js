define(["require", "exports", "jquery", "knockout", "Framework/ion-rangeslider/js/ion.rangeSlider", "Framework/datetimepicker/build/jquery.datetimepicker.full"], function (require, exports, $, ko) {
    "use strict";
    var bindingHandlers = ko.bindingHandlers;
    bindingHandlers.controller = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            requirejs([valueAccessor()], function (controller) {
                ko.applyBindingsToDescendants(controller.default(), element);
            });
            return { controlsDescendantBindings: true };
        }
    };
    bindingHandlers["slider"] = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            $(element).ionRangeSlider(valueAccessor());
        }
    };
    bindingHandlers["datetimepicker"] = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            $(element).datetimepicker(valueAccessor());
        }
    };
    ko.bindingHandlers["typeahead"] = {
        init: function (element, valueAccessor, bindingAccessor) {
            var substringMatcher = function (strs) {
                return function findMatches(q, cb, ct) {
                    $.getJSON('/api/lookupuser?Query=' + q, function (data, textStatus, jqXHR) {
                        //ct($.map(data, (element: any, index: number) => element.Value.FirstName));
                        ct(data);
                    });
                };
            };
            var $e = $(element), options = valueAccessor();
            requirejs(["bloodhound", "typeahead", "handlebars"], function (Bloodhound, typeahead, handlebars) {
                $e.typeahead({
                    highlight: false,
                    minLength: 4
                }, {
                    display: function (Item) { return Item.Value.LastName + ", " + Item.Value.FirstName; },
                    source: new Bloodhound({
                        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Value'),
                        queryTokenizer: Bloodhound.tokenizers.whitespace,
                        remote: {
                            url: '/api/lookupuser?Query=%QUERY',
                            wildcard: '%QUERY'
                        }
                    }),
                    templates: {
                        empty: [
                            '<div class="empty-message">',
                            'Unable to find the user you are looking for. Please ensure they have registered in the system.',
                            '</div>'
                        ].join('\n'),
                        suggestion: handlebars.compile([
                            '<p style="padding:4px">',
                            '	<span style="vertical-align:middle; border-width:3px; background-image:url(\'/api/Avatar/{{Value.AvatarId}}\')" class="Avatar-Icon active"></span>',
                            '	<span style="display:inline-block; padding-left:6px;">{{Value.FirstName}} {{Value.LastName}} <span class="text-info font-size-sm">({{Value.Email}})</span></span>',
                            '</p>'
                        ].join('\n')),
                        footer: handlebars.compile('<div class="text-muted font-size-sm" style="padding:4px; border-top:solid 1px #ddd">Searched for "{{query}}"</div>')
                    }
                }).on('typeahead:selected', function (el, datum) {
                    console.dir(datum);
                }).on('typeahead:autocompleted', function (el, datum) {
                    console.dir(datum);
                });
            });
        }
    };
    ko.applyBindings({}, document.getElementsByTagName("html")[0]);
});
//# sourceMappingURL=BindingHandlers.js.map