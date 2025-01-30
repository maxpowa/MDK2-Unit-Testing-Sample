using System;
using System.Collections.Generic;
using IngameScript;
using NUnit.Framework;
using FakeItEasy;
using Sandbox.Game.Entities.Cube;
using Sandbox.ModAPI.Ingame;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var fakeConnector = A.Fake<MyShipConnector>();
            A.CallToSet(() => fakeConnector.Enabled).DoesNothing();
            var fakeTerminalSystem = A.Fake<IMyGridTerminalSystem>(x => x.Strict());
            A.CallTo(() =>
                    fakeTerminalSystem.GetBlocksOfType(A<List<IMyShipConnector>>._, A<Func<IMyShipConnector, bool>>._))
                .Invokes((List<IMyShipConnector> connectors, Func<IMyShipConnector, bool> collect) => connectors.Add(
                    fakeConnector
                ));
            var instance = new Program();
            instance.DoWork(fakeTerminalSystem);
            A.CallTo(() => fakeConnector.Enabled).MustHaveHappened();
            Assert.That(fakeConnector.Enabled, Is.True);
        }
    }
}