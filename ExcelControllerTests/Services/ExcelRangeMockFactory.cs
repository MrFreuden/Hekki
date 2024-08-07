using ExcelController.Services.InteropWrappers;
using Moq;

namespace ExcelControllerTests.Services
{
    internal class ExcelRangeMockFactory
    {
        public Mock<IExcelRange> CreateMockRange(string initialAddress, int count)
        {
            var mocks = CreateMockRanges(initialAddress, count);
            var searchedRange = SetupSearchedRange(mocks);

            return searchedRange;
        }

        private List<Mock<IExcelRange>> CreateMockRanges(string initialAddress, int count)
        {
            var mocks = new List<Mock<IExcelRange>>();
            string currentAddress = initialAddress;

            for (int i = 0; i < count; i++)
            {
                var currentMock = new Mock<IExcelRange>();
                currentMock.Setup(range => range.Address).Returns(currentAddress);
                mocks.Add(currentMock);
                currentAddress = GetNewAddress(currentAddress);
            }

            return mocks;
        }

        private Mock<IExcelRange> SetupSearchedRange(List<Mock<IExcelRange>> mocks)
        {
            var searchedRange = new Mock<IExcelRange>();

            for (int i = 0; i < mocks.Count; i++)
            {
                var nextRange = (i < mocks.Count - 1) ? mocks[i + 1].Object : null;
                mocks[i].Setup(range => range.FindNext(It.IsAny<IExcelRange>())).Returns(nextRange);
                searchedRange.Setup(range => range.FindNext(mocks[i].Object)).Returns(nextRange);
            }

            if (mocks.Count > 0)
            {
                searchedRange.Setup(range => range.Find(It.IsAny<string>())).Returns(mocks[0].Object);
            }

            return searchedRange;
        }

        private string GetNewAddress(string address)
        {
            return address.Remove(address.Length - 1) + GetNewNumberRow(address);
        }

        private int GetNewNumberRow(string str)
        {
            var splited = str.Split('$');
            foreach (var item in splited)
            {
                if (int.TryParse(item, out int number))
                {
                    return number + 1;
                }
            }
            throw new ArgumentException("Impossible address");
        }
    }
}