using Hekki.App.DTO;

namespace Hekki.UI
{
    public class DataGridViewFactory
    {
        public DataGridView CreateGeneralTableGrid()
        {
            var dataGridView1 = new DataGridView()
            {
                Width = 700,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = true,
                EditMode = DataGridViewEditMode.EditOnKeystroke,
                AllowUserToOrderColumns = true,
       
            };
            return dataGridView1;
        }

        public DataGridView CreateHeatTableGrid()
        {
            var dgv = new DataGridView
            {
                Width = 300,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Margin = new Padding(10),
                AllowUserToAddRows = false
            };
            return dgv;

        }
    }
}
