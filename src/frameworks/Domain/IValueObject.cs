namespace Domain;

public interface IValueObject<T> where T : IValueObject<T>
{
	int GetHashCode();

	bool Equals(T other);

	bool Equals(object other);
}
