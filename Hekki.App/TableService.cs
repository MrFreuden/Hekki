﻿using Hekki.Domain.Models;

namespace Hekki.App
{
    public class TableService
    {
        public UIGeneralTableDTO BuildGeneralTable(List<Heat> heats, Pilots pilots)
        {
            throw new NotImplementedException();
        }

        public List<UIHeatTableDTO> BuildHeatTable(List<Heat> heats, Pilots pilots)
        {
            throw new NotImplementedException();
        }
    }

    public class UIGeneralTableDTO
    {
        public List<string> Columns { get; set; } = new();
        public List<GeneralTableRowDTO> Rows { get; set; } = new();
    }
    public class GeneralTableRowDTO
    {

    }

    public class UIHeatTableDTO
    {

    }
}
