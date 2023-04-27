using Microsoft.AspNetCore.SignalR;
using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TalkMind.Api.DomainEvents;
using TalkMind.Api.Features.Converse.DomainEvents;
using TalkMind.Api.Features.Converse.Factories;
using TalkMind.Api.Features.Converse.Hubs;
using TalkMind.Api.Features.Converse.Proxies;
using TalkMind.Api.Features.Converse.Services;
using TalkMind.Api.Features.OpenAi;

namespace TalkMind.Api.Test.Features.Converse.Hubs;

[TestClass]
public class ConverseHubTests
{
    [TestMethod]
    public async Task Empty_Audio_String_Should_Return_Error()
    {
        var service = Mock.Of<ISpeechRecognitionService>();
        var logger = Mock.Of<ILogger<ConverseHub>>();
        var eventBus = new Mock<IEventBus>();
        var context = Mock.Of<HubCallerContext>();

        var hub = new ConverseHub(service, logger, eventBus.Object);
        hub.Context = context;
        await hub.Converse(string.Empty);

        eventBus.Verify(x => x.Publish(It.IsAny<SpeechErrorDomainEvent>()), Times.Once);
    }

    [TestMethod]
    public async Task Invalid_Base64_Audio_Should_Return_Error()
    {
        var service = Mock.Of<ISpeechRecognitionService>();
        var logger = Mock.Of<ILogger<ConverseHub>>();
        var context = Mock.Of<HubCallerContext>();
        var eventBus = new Mock<IEventBus>();

        var hub = new ConverseHub(service, logger, eventBus.Object);
        hub.Context = context;
        await hub.Converse("abc");

        eventBus.Verify(x => x.Publish(It.IsAny<SpeechErrorDomainEvent>()), Times.Once);
    }

    [TestMethod]
    public async Task Valid_Audio_Raises_Speech_Recognised_Domain_Event()
    {
        var service = new Mock<ISpeechRecognitionService>();
        var openAiApi = Mock.Of<IOpenAiApi>();
        var logger = Mock.Of<ILogger<ConverseHub>>();
        var context = Mock.Of<HubCallerContext>();
        var result = new Mock<ISpeechRecognitionResultProxy>();
        var eventBus = new Mock<IEventBus>();

        result.SetupGet(x => x.Reason).Returns(ResultReason.RecognizedSpeech);

        service
            .Setup(
                x =>
                    x.Recognise(
                        It.IsAny<IPullAudioInputStreamFactory>(),
                        It.IsAny<CancellationToken>()
                    )
            )
            .ReturnsAsync(result.Object);

        var hub = new ConverseHub(service.Object, logger, eventBus.Object);
        hub.Context = context;
        await hub.Converse(
            "GkXfowEAAAAAAAAfQoaBAUL3gQFC8oEEQvOBCEKChHdlYm1Ch4ECQoWBAhhTgGcB/////////xFNm3QBAAAAAAAAABVJqWYBAAAAAAAASSrXsYMPQkBEiYgAAAAAAAAAAE2AmFFUbXV4aW5nQXBwTGliV2ViTS0wLjAuMVdBmVFUd3JpdGluZ0FwcExpYldlYk0tMC4wLjEWVK5rAQAAAAAAAGCuAQAAAAAAAFfXgQJzxYTIdSdfg4ECVqqEAGMuoFa7hATEtACGhkFfT1BVU2Oik09wdXNIZWFkAQE4AYC7AAAAAAAlhoiET1BVU+EBAAAAAAAADbWIQOdwAAAAAACfgQEfQ7Z1Af/////////ngQajEAAAB4IAAAD4//6jEAAAB4IAFAD4//4="
        );

        eventBus.Verify(x => x.Publish(It.IsAny<SpeechRecognisedDomainEvent>()), Times.Once);
    }
}