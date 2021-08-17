using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eonix2.Helpers
{
    public enum RequestLevel
    {
        NoFilter,
        Nom,
        Prenom,
        NomPrenom
    }

    internal static class RequestLevelAggregator
    {
        public static RequestLevel GetRequestLevel(string? nom, string? prenom)
        {
            int count = 0;

            if (nom != null) count += 1;
            if (prenom != null) count += 2;

            var level = count switch
            {
                0 => RequestLevel.NoFilter,
                1 => RequestLevel.Nom,
                2 => RequestLevel.Prenom,
                3 => RequestLevel.NomPrenom,
                _ => throw new NotImplementedException()
            };

            return level;
        }
    }
}