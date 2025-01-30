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
            var fakeMyProgram = A.Fake<MyGridProgram>(x => x.Strict());
            A.CallTo(() => fakeMyProgram.GridTerminalSystem).Returns(A.Fake<IMyGridTerminalSystem>());
            var instance = new Program();
            instance.Main("", UpdateType.None);
            Assert.Pass();
        }
    }
}