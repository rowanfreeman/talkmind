namespace TalkMind.Api.Common;

public interface IFunctor<T>
{
    IFunctor<TResult> Map<TResult>(Func<T, TResult> selector);
}
