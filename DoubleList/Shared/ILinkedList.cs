namespace Shared;

public interface ILinkedList<T>
{
    bool Contains(T data);
    void InsertOrdered(T data);
    void Remove(T data);
    void RemoveAll(T data);
    void Reverse();
    List<T> GetModes();
    string GetChart();
    string ToString();
    string ToStringReverse();
}