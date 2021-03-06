﻿using System;
using System.Text.RegularExpressions;
using NzbDrone.Core.Datastore;

namespace NzbDrone.Core.HealthCheck
{
    public class HealthCheck : ModelBase
    {
        private static readonly Regex CleanFragmentRegex = new Regex("[^a-z ]", RegexOptions.Compiled);

        public Type Source { get; set; }
        public HealthCheckResult Type { get; set; }
        public String Message { get; set; }
        public Uri WikiUrl { get; set; }

        public HealthCheck(Type source)
        {
            Source = source;
            Type = HealthCheckResult.Ok;
        }

        public HealthCheck(Type source, HealthCheckResult type, String message, String wikiFragment = null)
        {
            Source = source;
            Type = type;
            Message = message;
            WikiUrl = MakeWikiUrl(wikiFragment ?? MakeWikiFragment(message));
        }

        private static String MakeWikiFragment(String message)
        {
            return "#" + CleanFragmentRegex.Replace(message.ToLower(), String.Empty).Replace(' ', '-');
        }

        private static Uri MakeWikiUrl(String fragment)
        {
            var rootUri = new Uri("https://github.com/NzbDrone/NzbDrone/wiki/Health-checks");
            var fragmentUri = new Uri(fragment, UriKind.Relative);

            return new Uri(rootUri, fragmentUri);
        }
    }

    public enum HealthCheckResult
    {
        Ok = 0,
        Warning = 1,
        Error = 2
    }
}
