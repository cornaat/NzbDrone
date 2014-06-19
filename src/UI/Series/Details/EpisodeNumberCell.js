 'use strict';

define(
    [
        'marionette',
        'Cells/NzbDroneCell'
    ], function (Marionette, NzbDroneCell) {
        return NzbDroneCell.extend({

            className: 'episode-number-cell',
            template : 'Series/Details/EpisodeNumberCellTemplate',

            render: function () {

                this.$el.empty();

                this.$el.html(this.model.get('episodeNumber'));

                if ((this.model.has('sceneSeasonNumber') && this.model.get('sceneSeasonNumber') > 0 ) ||
                    (this.model.has('sceneEpisodeNumber') && this.model.get('sceneEpisodeNumber') > 0 ) ||
                    this.model.has('sceneAbsoluteEpisodeNumber'))
                {
                    this.templateFunction = Marionette.TemplateCache.get(this.template);

                    var html = this.templateFunction(this.model.toJSON());

                    this.$el.popover({
                        content  : html,
                        html     : true,
                        trigger  : 'hover',
                        title    : 'Scene Information',
                        placement: 'right',
                        container: this.$el
                    });
                }

                this.delegateEvents();
                return this;
            }
        });
    });
