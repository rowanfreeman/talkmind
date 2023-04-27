namespace TalkMind.Api.Common;

public interface IMonad<T> : IFunctor<T>
{
    IMonad<TResult> Bind<TResult>(Func<T, IMonad<TResult>> selector);
}
