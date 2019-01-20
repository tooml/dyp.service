using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace dyp.dyp.tests
{
    [TestClass]
    public class ListShuffleTests
    {
        [TestMethod]
        public void Shuffle_list()
        {
            var test_datas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var result = ListShuffle.Shuffle_list(test_datas.ToArray()).ToList();

            CollectionAssert.AreEquivalent(test_datas, result);
            CollectionAssert.AreNotEqual(test_datas, result);
        }
    }
}
