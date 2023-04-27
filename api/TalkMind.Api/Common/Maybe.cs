namespace TalkMind.Api.Common;

public sealed class Maybe<T> : IMonad<T>
{
    private readonly T? _item;

    public Maybe()
    { }

    internal Maybe(T item) => _item = item;

    internal static Maybe<T> Nothing => new Maybe<T>();

    internal static Maybe<T> Just(T item) => new Maybe<T>(item);

    internal TResult Match<TResult>(TResult nothing, Func<T, TResult> just) =>
        _item is not null ? just(_item) : nothing;

    public IMonad<TResult> Bind<TResult>(Func<T, IMonad<TResult>> selector) =>
        _item is not null ? selector(_item) : new Maybe<TResult>();

    IFunctor<TResult> IFunctor<T>.Map<TResult>(Func<T, TResult> selector) =>
        _item is not null ? new Maybe<TResult>(selector(_item)) : new Maybe<TResult>();
}