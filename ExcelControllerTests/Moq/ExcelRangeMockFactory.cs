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
        
        //public List<IExcelRange> CreateCellsInOneRow(int startRow, int startColumn, string name, int count)
        //{
        //    return Enumerable.Range(startColumn, count).Select(column => CreateCell(startRow, column, name).Object).ToList();
        //}

        //public List<IExcelRange> CreateCellsInOneColumn(int startRow, int column, int count)
        //{
        //    return Enumerable.Range(startRow, count).Select(row => CreateCell(row, column, _fixture.Create<string>()).Object).ToList();
        //}

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

        public List<IExcelRange> CreateColumnsWithData(int startRow, int column, string columnHeader, int length, int count, ValueType valueType = ValueType.RandomString)
        {
            //TODO: убрать 4
            var headers = CreateHeaders(startRow, column, columnHeader, count, 4).Select(mock => mock.Object).ToList();
            var columnData = CreateCellsInColumn(startRow, column, length, valueType).Select(mock => mock.Object).ToList();
            return headers.Concat(columnData).ToList();
        }

        public IExcelRange CreateOneColumnWithData(int startRow, int column, string columnHeader, int length, int count, ValueType valueType = ValueType.RandomString)
        {
            return CreateColumnsWithData(startRow, column, columnHeader, length, count, valueType).First();
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