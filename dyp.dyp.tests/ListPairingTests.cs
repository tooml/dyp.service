using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace dyp.dyp.tests
{
    [TestClass]
    public class ListPairingTests
    {
        [TestMethod]
        public void Get_pairs_with_even_list()
        {
            var test_datas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var result = ListPairing.Pairing_list(test_datas).ToList();

            Assert.AreEqual(4, result.Count());

            Assert.AreEqual(1, result.ElementAt(0).Item1);
            Assert.AreEqual(2, result.ElementAt(0).Item2);

            Assert.AreEqual(5, result.ElementAt(2).Item1);
            Assert.AreEqual(6, result.ElementAt(2).Item2);
        }
    }
}
