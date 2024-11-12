using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LarinLive.Data.Extensions;

/// <summary>
/// Extension methods for the <see cref="DbDataReader"/> class.
/// </summary>
public static class DbDataReaderExtensions2
{
	/// <summary>
	/// Gets the value of the specified column as the requested type.
	/// </summary>
	/// <typeparam name="T">The type of the value to be returned.</typeparam>
	/// <param name="reader">An instance of the <see cref="DbDataReader"/>class.</param>
	/// <param name="fieldIndex">The zero-based column index.</param>
	/// <returns>The value of the specified column.</returns>
	public static T? GetValue<T>(this DbDataReader reader, int fieldIndex) where T : class =>
		!reader.IsDBNull(fieldIndex) ? reader.GetFieldValue<T>(fieldIndex) : null;

	/// <summary>
	/// Asynchronously gets the value of the specified column as the requested type.
	/// </summary>
	/// <typeparam name="T">The type of the value to be returned.</typeparam>
	/// <param name="reader">An instance of the <see cref="DbDataReader"/>class.</param>
	/// <param name="fieldIndex">The zero-based column index.</param>
	/// <param name="ct">An optional cancellation token.</param>
	/// <returns>The task that incapsulates a value of the specified column.</returns>
	public static async Task<T?> GetValueAsync<T>(this DbDataReader reader, int fieldIndex, CancellationToken ct = default) where T : class =>
		!await reader.IsDBNullAsync(fieldIndex, ct) ? await reader.GetFieldValueAsync<T>(fieldIndex, ct) : null;
}
