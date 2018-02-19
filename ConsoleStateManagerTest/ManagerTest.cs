using System;
using ConsoleStateManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConsoleStateManagerTest
{
    [TestClass]
    public class ManagerTest
    {

        [TestMethod]
        public void GetMessage_VerifyPassThrough_IsMessageFromState()
        {
            //Arrange
            var stateMock = new Mock<IState>();
            var theMessage = "The message";
            stateMock.Setup(m => m.GetMessage()).Returns(theMessage);

            var manager = new Manager(stateMock.Object);

            //Act
            var actualMessage = manager.GetMessage();

            //Assert
            Assert.AreEqual(theMessage, actualMessage);
        }

        [TestMethod]
        public void IsFinished_VerifyPassThrough_IsFinishedFromState()
        {
            //Arrange
            var stateMock = new Mock<IState>();
            var isFinished = false;
            stateMock.Setup(m => m.IsFinished()).Returns(isFinished);

            var manager = new Manager(stateMock.Object);

            //Act
            var actualFinishedState = manager.IsFinished();

            //Assert
            Assert.AreEqual(isFinished, actualFinishedState);
        }

        #region integration tests

        [TestMethod]
        public void IntegrationTest()
        {
            //Arrange
            var state2Mock = new Mock<IState>();
            var messageOfSecondMock = "Message of second mock";
            state2Mock.Setup(m => m.GetMessage()).Returns(messageOfSecondMock);

            var state1Mock = new Mock<IState>();
            var userInputThatLeadsToState2 = "Some text";
            state1Mock.Setup(m => m.GetNewState(userInputThatLeadsToState2)).Returns(state2Mock.Object);

            var manager = new Manager(state1Mock.Object);

            //Act
            manager.HandleUserInput(userInputThatLeadsToState2);
            var actualMessage = manager.GetMessage();

            //Assert
            Assert.AreEqual(messageOfSecondMock, actualMessage);
        }

        #endregion
    }
}
