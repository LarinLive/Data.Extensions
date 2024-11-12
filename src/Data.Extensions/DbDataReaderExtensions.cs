using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace LarinLive.Data.Extensions;

/// <summary>
/// Extension methods for the <see cref="DbDataReader"/> class.
/// </summary>
public static class DbDataReaderExtensions
{
	/// <summary>
	/// Returns a list of the current dataset column definitions
	/// </summary>
	/// <param name="reader">An instance of the <see cref="DbDataReader"/>class whose columns shoud be described.</param>
	/// <returns></returns>
	public static IReadOnlyList<DbColumn> GetColumns(this DbDataReader reader) => reader.GetColumnSchema().ToList();
}
