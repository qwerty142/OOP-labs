using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination.DestinationAdapter;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination.DestinationTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.PopularMessengers;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorporateMessageDistributionSystemTests
{
    [Fact]
    public void WhenAUserReceivesMessageSavedAsUnread()
    {
        // Given
        var user = new User();
        IDestination destinationUser = new DestinationUser(user);
        var destinationProxyUser = new DestinationWithPriority(destinationUser, 0);
        var topic = new Topic("current test topic", destinationProxyUser);
        var message = new Message("title", "Hello", 10000000);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message);

        // Then
        if (user.Messages != null)
            Assert.False(user.Messages[0].ReadStatus);
    }

    [Fact]
    public void WhenTryMarkMessageUnreadAsReadChangeStatus()
    {
        // Given
        var user = new User();
        IDestination destinationUser = new DestinationUser(user);
        var destinationProxyUser = new DestinationWithPriority(destinationUser, 0);
        var topic = new Topic("current test topic", destinationProxyUser);
        var message = new Message("title", "Hello", 10000000);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message);
        user.ChangeMessageStatus(message);

        // Then
        if (user.Messages != null)
            Assert.True(user.Messages[0].ReadStatus);
    }

    [Fact]
    public void WhenTryMarMessageReadStatusAsReadErrorShouldReturned()
    {
        // Given
        var user = new User();
        IDestination destinationUser = new DestinationUser(user);
        var destinationProxyUser = new DestinationWithPriority(destinationUser, 0);
        var topic = new Topic("current test topic", destinationProxyUser);
        var message = new Message("title", "Hello", 10000000);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message);
        user.ChangeMessageStatus(message);

        // Then
        if (user.Messages != null)
            Assert.Throws<ArgumentException>(() => user.ChangeMessageStatus(message));
    }

    [Fact]
    public void BecauseOfLowPriorityMessageCantGo()
    {
        // Given
        var message = new Mock<IMessage>();
        message.SetupGet(p => p.Priority).Returns(-10000);
        var destination = new Mock<IDestination>();
        var destinationProxy = new DestinationWithPriority(destination.Object, 100000);
        var topic = new Topic("Topic", destinationProxy);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message.Object);

        // Then
        destination.Verify(mock => mock.SendMessage(message.Object), Times.Never);
    }

    [Fact]
    public void LoggingRecipientConfiguredLogShouldWrittenWhenMessageArrives()
    {
        // Given
        var message = new Mock<IMessage>();
        var destination = new Mock<IDestination>();
        var logger = new Mock<ILogger>();
        var loggerAdapter = new LoggerDecorator(destination.Object, logger.Object);
        var topic = new Topic("Topic", loggerAdapter);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message.Object);

        // Then
        logger.Verify(mock => mock.WriteMessage(message.Object.Body), Times.Once);
    }

    [Fact]
    public void WhenSendingMessageToMessengerImplementationProduceExpectedValue()
    {
        // Given
        var message = new Mock<IMessage>();
        var mess = new Mock<IMessenger>();
        var messenger = new DestinationMessenger(mess.Object);
        var topic = new Topic("Topic", messenger);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message.Object);

        // Then
        mess.Verify(mock => mock.WriteMessage(message.Object.Body), Times.Once);
    }

    [Fact]
    public void WhenSendingMessageToDisplayImplementationProduceExpectedValue()
    {
        // Given
        var message = new Mock<IMessage>();
        var logger = new Mock<ILogger>();
        var disp = new Mock<IDisplay>();
        var messenger = new DestinationDisplay(disp.Object);
        var topic = new Topic("Topic", messenger);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message.Object);

        // Then
        disp.Verify(mock => mock.WriteMessage(message.Object.Body), Times.Once);
    }

    [Fact]
    public void CheckSendingMessageOfTelegram()
    {
        // Given
        var message = new Mock<IMessage>();
        var telegram = new Mock<ITelegram>();
        IMessenger messenger = new TelegramAdapter(telegram.Object, "login", "password");
        var dest = new DestinationMessenger(messenger);
        var topic = new Topic("Topic", dest);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message.Object);

        // Then
        telegram.Verify(mock => mock.SendToChat("login", "password", message.Object.Body), Times.Once);
    }

    [Fact]
    public void CheckSendingMessageOfDiscord()
    {
        // Given
        var message = new Mock<IMessage>();
        var discord = new Mock<IDiscord>();
        IMessenger messenger = new DiscordAdapter(discord.Object, "key", 123);
        var dest = new DestinationMessenger(messenger);
        var topic = new Topic("Topic", dest);
        var facade = new FacadeTopic();
        facade.AddTopic(topic);

        // When
        facade.SendMessage(topic.Name, message.Object);

        // Then
        discord.Verify(mock => mock.ReceiveMessageToChat("key", 123, message.Object.Body), Times.Once);
    }
}