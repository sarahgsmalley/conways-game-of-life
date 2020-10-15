using System;
namespace GameOfLife
{
    public class Dimension : IEquatable<Dimension>
    {
        public Dimension(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        public int RowCount { get; }
        public int ColumnCount { get; }

        public bool Equals(Dimension other)
        {
            return other.RowCount == RowCount && other.ColumnCount == ColumnCount;
        }
    }
}