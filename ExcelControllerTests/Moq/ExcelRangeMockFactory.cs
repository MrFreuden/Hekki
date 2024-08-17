using AutoFixture;
using ExcelController.Services.InteropWrappers;
using Moq;

namespace ExcelControllerTests.Moq
{
    public enum ValueType
    {
        None,
        RandomString,
        RandomNumber
    }

    public class ExcelRangeMockFactory
    {
        private Fixture _fixture = new();

        public List<IExcelRange> CreateColumnWithData(int startRow, int column, string columnHeader, int length, ValueType valueType = ValueType.RandomString)
        {
            var header = CreateHeader(startRow++, column, columnHeader).Object;
            var columnData = CreateCellsInColumn(startRow, column, length, valueType).Select(mock => mock.Object).ToList();
            columnData.Insert(0, header);
            return columnData;
        }

        public Mock<IExcelRange> CreateHeader(int row, int column, string columnHeader)
        {
            return CreateCell(row, column, columnHeader);
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

        public List<Mock<IExcelRange>> CreateCellsInColumn(int startRow, int column, int count, ValueType valueType = ValueType.RandomString)
        {
            return Enumerable.Range(startRow, count).Select(row => CreateCell(row, column, GenerateValue(valueType))).ToList();
        }

        private string GenerateValue(ValueType valueType)
        {
            return valueType switch
            {
                ValueType.None => null,
                ValueType.RandomNumber => _fixture.Create<int>().ToString(),
                _ => _fixture.Create<string>(),
            };
        }

        public void SetupSearchRange(Mock<IExcelRange> searchRange, List<Mock<IExcelRange>> ranges)
        {
            for (int i = 0, j = 1; i < ranges.Count; i++, j++)
            {
                var nextRange = (i + 1 < ranges.Count) ? ranges[i + 1].Object : ranges.First().Object;
                searchRange.Setup(x => x.FindNext(ranges[i].Object)).Returns(nextRange);

                if (i == 0)
                {
                    var val = ranges[i].Object.Value2.ToString();
                    searchRange.Setup(x => x.Find(val)).Returns(ranges[i].Object);
                }
            }
        }
    }
}