using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LarinLive.Data.Extensions;

/// <summary>
/// Extension methods for the <see cref="DbCommand"/> class.
/// </summary>
public static class DbCommandExtensions1
{
	/// <summary>
	/// Executes the query, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.
	/// </summary>
	/// <typeparam name="T">The expecting type of return value.</typeparam>
	/// <param name="cmd">A command that will be executed.</param>
	/// <returns>The first column of the first row in the result set.</returns>
	public static T? ExecuteScalar<T>(this DbCommand cmd) where T : struct
	{
		var result = cmd.ExecuteScalar();
		if (result is null || result == DBNull.Value)
			return null;
		else
			return (T)result;
	}

	/// <summary>
	/// Executes the query asynchronously, and returns the first column of the first row in the resultset returned by the query. Extra columns or rows are ignored.
	/// </summary>
	/// <typeparam name="T">The expecting type of return value.</typeparam>
	/// <param name="cmd">A command that will be executed.</param>
	/// <param name="ct">An optional cancellation token</param>
	/// <returns>A task that incapsulates the first column of the first row in the result set.</returns>
	public static async Task<T?> ExecuteScalarAsync<T>(this DbCommand cmd, CancellationToken ct = default) where T : struct
	{
		var result = await cmd.ExecuteScalarAsync(ct);
		if (result is null || result == DBNull.Value)
			return null;
		else
			return (T)result;
	}
}
