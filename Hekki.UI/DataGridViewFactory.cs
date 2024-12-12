using Hekki.App.DTO;

namespace Hekki.UI
{
    public class DataGridViewFactory
    {
        public DataGridView CreateGeneralTableGrid()
        {
            var screenHeight = Screen.PrimaryScreen.WorkingArea.Height - 70;
            var dataGridView1 = new DataGridView()
            {
                //Width = 700,
                //Height = 800,
                //Anchor = AnchorStyles.Left | AnchorStyles.Right,
                MaximumSize = new Size(700, screenHeight),
                AutoSize = true,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                AllowUserToAddRows = true,
                EditMode = DataGridViewEditMode.EditOnKeystroke,
                AllowUserToOrderColumns = true,
                RowHeadersVisible = false,
                //BackgroundColor = System.Drawing.SystemColors.Control,
                BorderStyle = BorderStyle.None,
                AllowUserToResizeRows = false,
                AllowUserToDeleteRows = true
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
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                AllowUserToResizeRows = false
            };
            return dgv;

        }
    }
}
