namespace Hekki.UI
{
    public class FlowLayoutPanelFactory
    {
        public FlowLayoutPanel GetForGeneral()
        {
            return new FlowLayoutPanel()
            {
                AutoSize = true,
                Location = new Point(12, 12),
                Name = "flowLayoutPanel2",
                Size = new Size(561, 531),
                TabIndex = 1,
            };
        }

        public FlowLayoutPanel GetForHeats()
        {
            return new FlowLayoutPanel()
            {
                AutoSize = true,
                Location = new Point(747, 12),
                Name = "flowLayoutPanel1",
                Size = new Size(561, 284),
                TabIndex = 2,
            };
        }
    }
}
