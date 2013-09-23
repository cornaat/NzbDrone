'use strict';
define(
    [
        'app',
        'Series/SeriesCollection'
    ], function (App, SeriesCollection) {
        $.fn.bindSearch = function () {
            $(this).typeahead({
                source   : function () {
                    return SeriesCollection.map(function (model) {
                        return model.get('title');
                    });
                },

                sorter: function (items) {
                    return items.sort();
                },

                updater: function (item) {
                    var series = SeriesCollection.find(function (model) {
                        return model.get('title') === item;
                    });

                    this.$element.blur();
                    App.Router.navigate('/series/{0}'.format(series.get('titleSlug')), { trigger: true });
                }
            });
        };
    });