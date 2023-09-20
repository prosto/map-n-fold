using static Alvys.MapAndFold.CollectionHelpers;

namespace Alvys.MapAndFold.Tests
{
    [TestFixture]
    public class CollectionHelpersTest
    {
        private List<int> numberList;
        private List<int> emptyList;

        [SetUp]
        protected void SetUp()
        {
            numberList = new List<int> { 1, 2, 3 };
            emptyList = new List<int>();
        }


        [Test]
        public void Fold_NumberSum()
        {
            var result = Fold(numberList, 0, (sum, x) => sum + x);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Fold_StrConcat()
        {
            var result = Fold(numberList, "", (str, x) => str + x.ToString());

            Assert.That(result, Is.EqualTo("123"));
        }

        [Test]
        public void Fold_EmptyList()
        {
            var initial = 10;

            var result = Fold(emptyList, initial, (_, _) => 1111);

            Assert.That(result, Is.EqualTo(initial));
        }

        [Test]
        public void Map_NumberAdd()
        {
            var result = Map(numberList, (x) => x + 1);

            Assert.That(result, Is.EqualTo(new int[] { 2, 3, 4 }));
        }

        [Test]
        public void Map_ToString()
        {
            var result = Map(numberList, x => x.ToString());

            Assert.That(result, Is.EqualTo(new string[] { "1", "2", "3" }));
        }

        [Test]
        public void Map_EmptyList()
        {
            var result = Map(emptyList, x => 10);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Map2_NumberAdd()
        {
            var result = Map2(numberList, (x) => x + 1);

            Assert.That(result, Is.EqualTo(new int[] { 2, 3, 4 }));
        }

        [Test]
        public void Map2_ToString()
        {
            var result = Map2(numberList, x => x.ToString());

            Assert.That(result, Is.EqualTo(new string[] { "1", "2", "3" }));
        }

        [Test]
        public void Map2_EmptyList()
        {
            var result = Map2(emptyList, x => 10);

            Assert.That(result, Is.Empty);
        }
    }
}

