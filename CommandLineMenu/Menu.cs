using System.Collections;
using System.Collections.ObjectModel;

namespace CommandLineMenu;

/// <summary>
/// Represents a strongly typed list of alternatives that can be prompted for selection by the user in the <see cref="Console"/>. 
/// Alternatives can be accessed by index. Provides methods to search, sort, and manipulate lists.
/// </summary>
/// <typeparam name="T">The type of alternatives in the menu.</typeparam>
public class Menu<T> : IEnumerable<T>, ICollection<T>
{
    private List<T> _alternatives;

    /// <summary>
    /// Gets or sets the alternative at the specified index.
    /// </summary>
    /// <param name="index">Zero-based index of the alternative.</param>
    /// <returns>Alternative at the specified <paramref name="index"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public virtual T this[int index]
    {
        get => _alternatives[index];
        set => _alternatives[index] = value;
    }

    /// <summary>
    /// Intializes a new instance of the <see cref="Menu{T}"/> class that is empty.
    /// </summary>
    public Menu()
    {
        _alternatives = new();
    }

    /// <summary>
    /// Intializes a new instance of the <see cref="Menu{T}"/> class that contains alternatices copied from the specified collection.
    /// </summary>
    /// <param name="alternatives">The collection whose elements are copied to the Menu.</param>
    public Menu(IEnumerable<T> alternatives)
    {
        _alternatives = alternatives.ToList();
    }

    /// <summary>
    /// Adds an alternative to the end of the <see cref="Menu{T}"/>.
    /// </summary>
    /// <param name="alternative">The alternative to be added to the end of the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    public virtual void Add(T alternative)
    {
        _alternatives.Add(alternative);
    }

    /// <summary>
    /// Adds the elements of the specified collection to the end of the <see cref="Menu{T}"/>.
    /// </summary>
    /// <param name="alternatives">The collection whose elements should be added to the end of the <see cref="Menu{T}"/>. 
    /// The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
    public virtual void AddRange(IEnumerable<T> alternatives)
    {
        _alternatives.AddRange(alternatives);
    }

    /// <summary>
    /// Inserts an alternative into the <see cref="Menu{T}"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="alternative"/> should be inserted</param>
    /// <param name="alternative">The alternative to insert. The value can be null for reference types.</param>
    public virtual void Insert(int index, T alternative)
    {
        _alternatives.Insert(index, alternative);
    }

    /// <summary>
    /// Removes the first occurrence of a specific alternative from the <see cref="Menu{T}"/>.
    /// </summary>
    /// <param name="alternative">The alternative to remove from the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <returns><see langword="true"/> if <paramref name="alternative"/> is successfully removed; otherwise, <see langword="false" />. 
    /// This method also returns false if <paramref name="alternative"/> was not found in the <see cref="Menu{T}"/></returns>
    public virtual bool Remove(T alternative)
    {
        return _alternatives.Remove(alternative);
    }

    /// <summary>
    /// Removes the alternative at the specified index of the <see cref="Menu{T}"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the alternative to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException" />
    public virtual void RemoveAt(int index)
    {
        _alternatives.RemoveAt(index);
    }

    /// <summary>
    /// Moves an alternative in the <see cref="Menu{T}" /> from one position to another.
    /// </summary>
    /// <param name="oldIndex">The zero-based index of the alternative to move.</param>
    /// <param name="newIndex">The zero-based index where to move the alternative too.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public virtual void Move(int oldIndex, int newIndex)
    {
        if (oldIndex < 0 || oldIndex >= _alternatives.Count)
            throw new ArgumentOutOfRangeException(nameof(oldIndex));

        if (newIndex < 0 || newIndex >= _alternatives.Count)
            throw new ArgumentOutOfRangeException(nameof(newIndex));

        var alternative = _alternatives[oldIndex];
        _alternatives.RemoveAt(oldIndex);
        _alternatives.Insert(newIndex, alternative);
    }

    /// <summary>
    /// Moves the first occurrence of an alternative in the <see cref="Menu{T}" /> from to a new position.
    /// </summary>
    /// <param name="alternative">Alternative to move</param>
    /// <param name="newIndex">The zero-based index where to move the <paramref name="alternative"/> too.</param>
    /// <returns><see langword="true"/> if <paramref name="alternative"/> is successfully moved; otherwise, <see langword="false" />. 
    /// This method also returns false if <paramref name="alternative"/> was not found in the <see cref="Menu{T}"/></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public virtual bool Move(T alternative, int newIndex)
    {
        if (newIndex < 0 || newIndex >= _alternatives.Count)
            throw new ArgumentOutOfRangeException(nameof(newIndex));

        if (!_alternatives.Contains(alternative))
            return false;

        var oldIndex = _alternatives.IndexOf(alternative);
        Move(oldIndex, newIndex);
        return true;
    }

    /// <summary>
    /// Searches for the specified alternative and returns the zero-based index of the first occurrence within the entire <see cref="Menu{T}"/>.
    /// </summary>
    /// <param name="alternative">The alternative to locate in the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <returns>The zero-based index of the first occurrence of <paramref name="alternative"/> within the entire <see cref="Menu{T}"/>, if found; otherwise, -1.</returns>
    public virtual int IndexOf(T alternative)
    {
        return _alternatives.IndexOf(alternative);
    }

    /// <summary>
    /// Searches for the specified alternative and returns the zero-based index of the first occurrence within the range 
    /// of alternatives in the <see cref="Menu{T}"/> that extends from the specified index to the last alternative.
    /// </summary>
    /// <param name="alternative">The alternative to locate in the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty Menu.</param>
    /// <returns>The zero-based index of the first occurrence of <paramref name="alternative"/> within the range of alternatives in the <see cref="Menu{T}"/> 
    /// that extends from <paramref name="index"/> to the last alternative, if found; otherwise, -1</returns>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public virtual int IndexOf(T alternative, int index)
    {
        return _alternatives.IndexOf(alternative, index);
    }

    /// <summary>
    /// Searches for the specified alternative and returns the zero-based index of the first occurrence within the range of alternatives 
    /// in the <see cref="Menu{T}"/> that starts at the specified index and contains the specified number of alternatives.
    /// </summary>
    /// <param name="alternative">The alternative to locate in the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty Menu.</param>
    /// <param name="count">The number of alternatives in the section to search.</param>
    /// <returns>The zero-based index of the first occurrence of <paramref name="alternative"/> within the range of alternatives in the 
    /// <see cref="Menu{T}" /> that starts at <paramref name="index"/> and contains <paramref name="count"/> number of alternatives, if found; 
    /// otherwise, -1.</returns>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public virtual int IndexOf(T alternative, int index, int count)
    {
        return _alternatives.IndexOf(alternative, index, count);
    }

    /// <summary>
    /// Searches for the specified alternative and returns the zero-based index of the last occurrence within the entire <see cref="Menu{T}"/>.
    /// </summary>
    /// <param name="alternative">The alternative to locate in the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <returns>The zero-based index of the last occurrence of <paramref name="alternative"/> within the entire <see cref="Menu{T}"/>, if found; otherwise, -1.</returns>
    public virtual int LastIndexOf(T alternative)
    {
        return _alternatives.LastIndexOf(alternative);
    }

    /// <summary>
    /// Searches for the specified alternative and returns the zero-based index of the last occurrence within the range of alternatives in the <see cref="Menu{T}"/>
    /// that extends from the first alternative to the specified index.
    /// </summary>
    /// <param name="alternative">The alternative to locate in the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <param name="index">The zero-based starting index of the backward search.</param>
    /// <returns>The zero-based index of the last occurrence of <paramref name="alternative"/> within the range of alternatives in the <see cref="Menu{T}"/> 
    /// that extends from the first element to <paramref name="index"/>, if found; otherwise, -1.</returns>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public virtual int LastIndexOf(T alternative, int index)
    {
        return _alternatives.LastIndexOf(alternative, index);
    }

    /// <summary>
    /// Searches for the specified alternative and returns the zero-based index of the last occurrence within the range of alternatives in the <see cref="Menu{T}" /> 
    /// that contains the specified number of alternatives and ends at the specified index.
    /// </summary>
    /// <param name="alternative">The alternative to locate in the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <param name="index">The zero-based starting index of the backward search.</param>
    /// <param name="count">The number of elements in the section to search.</param>
    /// <returns>The zero-based index of the last occurence of <paramref name="alternative"/> within the range of alternatives in the <see cref="Menu{T}"/> 
    /// that contains <paramref name="count"/> number of alternatives and ends at <paramref name="index"/>, if found; otherwise, -1.</returns>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public virtual int LastIndexOf(T alternative, int index, int count)
    {
        return _alternatives.LastIndexOf(alternative, index, count);
    }

    /// <summary>
    /// Removes all alternatives from the <see cref="Menu{T}"/>.
    /// </summary>
    public virtual void Clear()
    {
        _alternatives.Clear();
    }

    /// <summary>
    /// Gets the number of alternatives contained in the <see cref="Menu{T}"/>.
    /// </summary>
    /// <returns>The number of alternatives contained in the <see cref="Menu{T}"/>.</returns>
    public virtual int Count => _alternatives.Count;

    /// <summary>
    /// Determines whether an alternative is in the <see cref="Menu{T}"/>.
    /// </summary>
    /// <param name="alternative">The alternative to locate in the <see cref="Menu{T}"/>. The value can be null for reference types.</param>
    /// <returns><see langword="true"/> if <paramref name="alternative"/> is found in the <see cref="Menu{T}"/>;
    /// otherwise, <see langword="false"/>.</returns>
    public virtual bool Contains(T alternative)
    {
        return _alternatives.Contains(alternative);
    }

    /// <summary>
    /// Copies the entire <see cref="Menu{T}" /> to a compatible one-dimensional array, starting at the specified index of the target array.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the alternatives copied from <see cref="Menu{T}"/>. 
    /// The <see cref="Array"/> must have zero-based indexing.</param>
    /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ArgumentOutOfRangeException" />
    /// <exception cref="ArgumentException" />"
    public virtual void CopyTo(T[] array, int arrayIndex)
    {
        _alternatives.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Sorts the elements in the entire <see cref="Menu{T}"/> using the default comparer.
    /// </summary>
    /// <exception cref="InvalidOperationException" />
    public virtual void Sort()
    {
        _alternatives.Sort();
    }

    /// <summary>
    /// Sorts the elements in the entire <see cref="Menu{T}"/> using the specified <see cref="IComparer{T}"/>.
    /// </summary>
    /// <param name="comparer">The <see cref="IComparer{T}"/> implementation to use when comparing elements, 
    /// or null to use the default comparer <see cref="Comparer{T}.Default"/>.</param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentException" />"
    public virtual void Sort(IComparer<T> comparer)
    {
        _alternatives.Sort(comparer);
    }

    /// <summary>
    /// Sorts the elements in the entire <see cref="Menu{T}"/> using the specified <see cref="Comparison{T}"/>.
    /// </summary>
    /// <param name="comparison">The <see cref="Comparison{T}"/> to use when comparing elements.</param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentException" />"
    public virtual void Sort(Comparison<T> comparison)
    {
        _alternatives.Sort(comparison);
    }

    /// <summary>
    /// Gets a value indicating whether the <see cref="Menu{T}"/> is read-only.
    /// </summary>
    /// <returns><see langword="true"/> if the <see cref="Menu{T}"/> is read-only; otherwise, <see langword="false"/>. 
    /// In the base class of of <see cref="Menu{T}"/>, this property always returns <see langword="false"/></returns>
    public virtual bool IsReadOnly => false;

    /// <summary>
    /// Returns an enumerator that iterates through the <see cref="Menu{T}"/>.
    /// </summary>
    /// <returns>An <see cref="IEnumerator"/> for the <see cref="Menu{T}"/></returns>
    public virtual IEnumerator<T> GetEnumerator()
    {
        return _alternatives.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_alternatives).GetEnumerator();
    }

    /// <summary>
    /// Shows a menu with the alternatives and prompts the user to select an option until a valid option is selected.
    /// </summary>
    /// <returns>Alternative that was selected.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the menu contains no alternatives</exception>
    public T ShowMenu()
    {
        if (_alternatives.Count == 0)
        {
            throw new InvalidOperationException("No alternatives to show");
        }

        for (int i = 0; i < _alternatives.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_alternatives[i]}");
        }
        Console.WriteLine();

        var selection = string.Empty;
        var index = -1;
        do
        {
            Console.CursorTop -= 1;
            ConsoleHelper.ClearLine();
            Console.Write($"Select an option ({1}-{_alternatives.Count}): ");
            selection = Console.ReadLine();
        } while (!int.TryParse(selection, out index) || index < 1 || index > _alternatives.Count);

        return _alternatives[index - 1];
    }
}
