using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WpfApp1
{
    public class TestScannFIles
    {
        //[UnitOfWork_StateUnderTest_ExpectedBehavior]
        [Fact]
        public void FindFiles_EmptyPathAsParam_ExceptionsThrown()
        {
            Assert.Throws<System.ArgumentException>(testScan);

        }

        void testScan() {
            ScannGames scan = new ScannGames();
            scan.Findfile(String.Empty, string.Empty);
        }

        //[Fact]
        //public void FindFiles_EmptyPathAsParam_ExceptionsThrown()

    }


}
