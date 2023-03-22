using System.Drawing;
using System.Windows.Forms;

namespace IssueDemoWithDotnetFramework4._8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerateContollers();
        }

        private void GenerateContollers()
        {
            // panel
            var panelHeight = 50;
            panel = new Panel();
            panel.Size = new Size(Width, panelHeight);
            Controls.Add(panel);
            // split
            split = new SplitContainer();
            split.Location = new Point(0, panelHeight);
            split.Size = new Size(Width, Height - panelHeight);

            Controls.Add(split);
            // richtextbox
            rtb = new RichTextBox { Dock = DockStyle.Fill };
            rtb.WordWrap = false;
            rtb.TextChanged += (o, e) =>
            {
                if (rtb.Rtf != tb.Text)
                {
                    tb.Text = rtb.Rtf;
                }
            };
            split.Panel1.Controls.Add(rtb);
            // textbox
            tb = new TextBox { Multiline = true, Dock = DockStyle.Fill };
            split.Panel2.Controls.Add(tb);
            tb.TextChanged += (o, e) =>
            {
                if (rtb.Rtf != tb.Text)
                {
                    rtb.Rtf = tb.Text;
                }
            };
            //searchbox
            sb = new TextBox { Dock = DockStyle.Fill };
            sb.KeyUp += (o, e) =>
            {
                if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
                {
                    var index = rtb.Text.IndexOf(sb.Text);
                    var line = rtb.GetLineFromCharIndex(index);
                    var text = $"the index of '{sb.Text}' is {index}\nthe line num of '{sb.Text}' is {line}\nrtb.Text:\n{rtb.Text}";

                    MessageBox.Show(text, "MessageBox");
                }
            };
            panel.Controls.Add(sb);
        }


        private Panel panel;
        private SplitContainer split;
        private RichTextBox rtb;
        private TextBox tb;
        private TextBox sb;
    }
}
