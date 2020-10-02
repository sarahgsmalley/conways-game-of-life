using System.Collections.Generic;

namespace GameOfLife
{
    public class LocationOffsetProvider
    {
        public static List<LocationOffset> ProvideCentralCellOffsets()
        {
            return new List<LocationOffset>()
            {
                new LocationOffset { RowOffset = -1, ColumnOffset = -1 },
                new LocationOffset { RowOffset = -1, ColumnOffset = 0 },
                new LocationOffset { RowOffset = -1, ColumnOffset = 1 },
                new LocationOffset { RowOffset = 0, ColumnOffset = -1 },
                new LocationOffset { RowOffset = 0, ColumnOffset = 1 },
                new LocationOffset { RowOffset = 1, ColumnOffset = -1 },
                new LocationOffset { RowOffset = 1, ColumnOffset = 0 },
                new LocationOffset { RowOffset = 1, ColumnOffset = 1 },
            };
        }
    }
}