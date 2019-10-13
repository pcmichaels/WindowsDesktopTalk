using GenerateLargeFiles.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GenerateLargeFiles.Test
{
    public class SerialiserHelperTests
    {
        [Fact]
        public void XmlSerialise_SeriaisesClass()
        {
            // Arrange
            var mainData = new MainData()
            {
                PropertyOne = "test",
                PropertyThree = "test"
            };

            // Act
            string result = SerialiseHelper.Serialize<MainData>(mainData);

            // Assert
            Assert.Contains("<PropertyOne>test</PropertyOne><PropertyThree>test</PropertyThree></MainData>", result);
        }
    }
}
