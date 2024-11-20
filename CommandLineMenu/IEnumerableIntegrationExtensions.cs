namespace CommandLineMenu;

/// <summary>
/// Extension methods for <see cref="Menu{T}"/> to integrate with<see cref="IEnumerable{T}"/> .
/// </summary>
public static class IEnumerableIntegrationExtensions
{
    /// <summary>
    /// Creates an <see cref="Menu{T}"/> from a <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of alternatives in the menu</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> source to convert</param>
    /// <returns>A <see cref="Menu{T}"/> that contains the alternatives from the source</returns>
    public static Menu<T> ToMenu<T>(this IEnumerable<T> source)
    {
        return new Menu<T>(source);
    }
}
