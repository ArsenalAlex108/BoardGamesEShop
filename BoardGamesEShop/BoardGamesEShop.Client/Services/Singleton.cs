namespace BoardGamesEShop.Client.Services;

public sealed class Singleton<T>(Func<T> getter, Action<T> setter)
{
    private readonly Func<T> _getter = getter ?? throw new ArgumentNullException(nameof(getter));
    private readonly Action<T> _setter = setter ?? throw new ArgumentNullException(nameof(setter));

    public Singleton(T value) : this(() => value, i => value = i) 
    {
    }

    public T Value 
    { 
        get => _getter();
        set => _setter(value); 
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Singleton<T> other) return false;

        return Value!.Equals(other.Value);
    }

    public override int GetHashCode() => Value!.GetHashCode();

    public override string? ToString() => Value?.ToString();
}
