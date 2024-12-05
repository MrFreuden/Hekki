using Hekki.App.DTO;

namespace Hekki.UI
{
    public class DataGridViewFactory
    {
        public DataGridView CreateGeneralTableGrid()
        {
            var dataGridView1 = new DataGridView()
            {
                Width = 400,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };
            return dataGridView1;
        }

        public DataGridView CreateHeatTableGrid()
        {
            var dgv = new DataGridView
            {
                Width = 300,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Margin = new Padding(10),
            };
            return dgv;

        }
    }
}
