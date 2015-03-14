using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Memo
{
    internal class Memo : TextBox
    {
        private readonly StringBuilder _textBuilder;
        public Memo()
        {
            _textBuilder = new StringBuilder();
            ScrollBars = ScrollBars.Vertical;
            Multiline = true;
            Size = new Size(200, 100);
            ReadOnly = true;
            BackColor = Color.White;
        }

        public void Add(string LineText)
        {
            _textBuilder.AppendLine(LineText);
            Text = _textBuilder.ToString();
        }

        public new void Clear() 
        {
            _textBuilder.Clear();
            base.Clear();
        }
    }
}
