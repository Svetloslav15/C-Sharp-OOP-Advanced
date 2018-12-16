namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void ShouldMakeInstancesCorrectly()
        {
            IAssembler assembler = new VehicleAssembler();
            Assert.DoesNotThrow(() => new Revenger("Test", 100, 100, 100, 100, 100, assembler));
            Assert.DoesNotThrow(() => new Vanguard("Test2", 100, 100, 100, 100, 100, assembler));
        }

        [Test]
        public void TestAddPartCorrectly()
        {
            IAssembler assembler = new VehicleAssembler();
            Revenger revenger = new Revenger("Test", 100, 100, 100, 100, 100, assembler);
            ArsenalPart arsenalPart = new ArsenalPart("Arsenal", 23, 50, 5);
            EndurancePart endurancePart = new EndurancePart("Endurance", 23, 50, 5);
            ShellPart shellPart = new ShellPart("Shell", 23, 50, 5);
            Assert.DoesNotThrow(() => revenger.AddArsenalPart(arsenalPart));
            Assert.DoesNotThrow(() => revenger.AddEndurancePart(endurancePart));
            Assert.DoesNotThrow(() => revenger.AddShellPart(shellPart));

            string actualResult = revenger.ToString();
            string expectedResult = "Revenger - Test\r\nTotal Weight: 169.000\r\nTotal Price: 250.000\r\nAttack: 105\r\nDefense: 105\r\nHitPoints: 105\r\nParts: Arsenal, Endurance, Shell";
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}