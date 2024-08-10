using ExcelController.Services.InteropWrappers;
using Moq;

namespace ExcelControllerTests.Moq
{
    internal class ExcelRangeMockFactory
    {
        public Mock<IExcelRange> CreateMockRange(string initialAddress, int count)
        {
            var mockRanges = CreateMockRanges(initialAddress, count);
            return SetupFindNextBehavior(mockRanges);
        }

        private List<Mock<IExcelRange>> CreateMockRanges(string initialAddress, int count)
        {
            var mocks = new List<Mock<IExcelRange>>();
            string currentAddress = initialAddress;

            for (int i = 0; i < count; i++)
            {
                var mock = new Mock<IExcelRange>();
                mock.Setup(range => range.Address).Returns(currentAddress);
                mocks.Add(mock);
                currentAddress = IncrementAddress(currentAddress);
            }

            return mocks;
        }

        private Mock<IExcelRange> SetupFindNextBehavior(List<Mock<IExcelRange>> mocks)
        {
            var searchedRange = new Mock<IExcelRange>();

            for (int i = 0; i < mocks.Count; i++)
            {
                var nextRange = i < mocks.Count - 1 ? mocks[i + 1].Object : null;
                mocks[i].Setup(range => range.FindNext(It.IsAny<IExcelRange>())).Returns(nextRange);
                searchedRange.Setup(range => range.FindNext(mocks[i].Object)).Returns(nextRange);
            }

            if (mocks.Count > 0)
            {
                searchedRange.Setup(range => range.Find(It.IsAny<string>())).Returns(mocks[0].Object);
            }

            return searchedRange;
        }

        private string IncrementAddress(string address)
        {
            var parts = address.Split('$', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2 || !int.TryParse(parts[1], out int rowNumber))
            {
                throw new ArgumentException("Invalid address format");
            }
            return $"${parts[0]}${rowNumber + 1}";
        }
    }
}