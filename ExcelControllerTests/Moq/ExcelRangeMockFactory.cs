using AutoFixture;
using ExcelController.Services.InteropWrappers;
using Moq;

namespace ExcelControllerTests.Moq
{
    public class ExcelRangeMockFactory
    {
        private Fixture _fixture = new();
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

        private string IncrementAddress(string address)
        {
            var parts = address.Split('$', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2 || !int.TryParse(parts[1], out int rowNumber))
            {
                throw new ArgumentException("Invalid address format");
            }
            return $"${parts[0]}${rowNumber + 1}";
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

        public List<IExcelRange> CreateCellsInOneRow(int startRow, int startColumn, string name, int count)
        {
            return Enumerable.Range(startColumn, count).Select(column => CreateCell(startRow, column, name).Object).ToList();
        }




        public List<IExcelRange> CreateCellsInOneColumn(int startRow, int column, int count)
        {
            return Enumerable.Range(startRow, count).Select(row => CreateCell(row, column, _fixture.Create<string>()).Object).ToList();
        }

        public Mock<IExcelRange> CreateCell(int row, int column, string value)
        {
            var mock = new Mock<IExcelRange>();
            var address = BuildAddress(row, column);
            mock.Setup(x => x.Row).Returns(row);
            mock.Setup(x => x.Column).Returns(column);
            mock.Setup(x => x.Value2).Returns(value);
            mock.Setup(x => x.Address).Returns(address);
            return mock;
        }

        private string BuildAddress(int row, int column)
        {
            var columnAsString = GetExcelColumnName(column);
            return $"${columnAsString}${row}";
        }

        private string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }

        public List<IExcelRange> CreateColumnsWithData(int startRow, int column, string columnHeader, int length, int count)
        {
            var headers = CreateHeaders(startRow, column, columnHeader, count, 4).Select(mock => mock.Object).ToList();
            var columnData = CreateCellsInColumn(startRow, column, length).Select(mock => mock.Object).ToList();
            return headers.Concat(columnData).ToList();
        }
        public List<Mock<IExcelRange>> CreateCellsInColumn(int startRow, int column, int count)
        {
            return Enumerable.Range(startRow, count).Select(row => CreateCell(row, column, _fixture.Create<string>())).ToList();
        }
        public List<Mock<IExcelRange>> CreateHeaders(int row, int column, string columnHeader, int count, int offset)
        {
            var mocks = new List<Mock<IExcelRange>>();
            for (int i = 0; i < count; i++)
            {
                mocks.Add(CreateCell(row, column, columnHeader));
                column += offset;
            }
            return mocks;
        }

        public Mock<IExcelRange> GetSearchRange(List<Mock<IExcelRange>> ranges)
        {
            var searchRange = new Mock<IExcelRange>();
            SetupFind(searchRange, ranges);
            return searchRange;
        }

        private void SetupFind(Mock<IExcelRange> searchRange, List<Mock<IExcelRange>> ranges)
        {
            for (int i = 0, j = 1; i < ranges.Count; i++, j++)
            {
                if (j == ranges.Count)
                {
                    searchRange.Setup(x => x.FindNext(ranges[i].Object)).Returns(ranges.First().Object);
                }
                else
                {
                    searchRange.Setup(x => x.FindNext(ranges[i].Object)).Returns(ranges[j].Object);
                }

                if (i == 0)
                {
                    var val = ranges[i].Object.Value2.ToString();
                    searchRange.Setup(x => x.Find(val)).Returns(ranges[i].Object);
                }
            }
        }
    }
}