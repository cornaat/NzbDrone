﻿using FluentMigrator;
using NzbDrone.Core.Datastore.Migration.Framework;

namespace NzbDrone.Core.Datastore.Migration
{
    [Tags("")]
    [Migration(2)]
    public class Remove_tvrage_imdb_unique_constraint : NzbDroneMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Execute.Sql("DROP INDEX IX_Series_TvRageId;");
            Execute.Sql("DROP INDEX IX_Series_ImdbId;");
        }
    }
}