using System.Linq;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using Vuighe.Common.Extensions;

namespace Vuighe.Model.Utils
{
    public static class TsVectorIndexHelper
    {
        public static IQueryable<T> MatchSearchQuery<T>(this IQueryable<T> queryable, string query, string columnName = "SearchVector")
        {
            return queryable.Where(t => EF.Property<NpgsqlTsVector>(t, columnName)
                .Matches(EF.Functions.ToTsQuery(query.ToTsQueryCompat())));
        }
    }
}