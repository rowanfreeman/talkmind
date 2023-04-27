namespace TalkMind.Api.Features.Converse.DomainEvents;

public sealed record SpeechErrorDomainEvent(string ConnectionId, string Message) { }