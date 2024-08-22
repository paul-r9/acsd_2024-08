using NUnit.Framework;
using System.Collections.Generic;

namespace SpacePort
{
    [TestFixture]
    public class LaunchOrderListingTest
    {
        
        //TODO - Use the Stub Recipe to test that launches are sorted correctly
        [Test]
        public void LaunchesAreSortedByDestination_DestinationsAreUnique()
        {
            // Step 1. Create LaunchInfoProviderStub (that implements ISpacelineLaunchInfoProvider)
            ISpacelineLaunchInfoProvider mockSpacelineLaunchInfo = new LaunchInfoProviderStub();

            // Step 2 & 3 & 4. Create SUT - SpaceportDepartureBoard, using Constructor Injection,
            // Exercising this behavior happens during construction of the System Under Test
            var spaceportDepatureBoard = new SpaceportDepartureBoard(mockSpacelineLaunchInfo);

            // Step 5. Verify the results are sorted correctly
            Assert.AreEqual("ISS", spaceportDepatureBoard.LaunchList[0].Destination);
            Assert.AreEqual("Mars", spaceportDepatureBoard.LaunchList[1].Destination);
        }
    }

    internal class LaunchInfoProviderStub : ISpacelineLaunchInfoProvider
    {
        public LaunchInfoProviderStub() { }

        public List<LaunchInfo> GetCurrentLaunches() {
            var values = new List<LaunchInfo>();
            LaunchInfo value = new LaunchInfo(System.Guid.NewGuid());
            value.Destination = "Mars";
            values.Add(value);
            value = new LaunchInfo(System.Guid.NewGuid());
            value.Destination = "ISS";
            values.Add(value);
            return values;
        }
    }
}