namespace TranslatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnTranslate_Click(object sender, EventArgs e)
        {
            Translator translator = new Translator(textBox1.Text);

            string[] Results = await translator.Translate();

            if (Results != null)
            {
                textBox2.Text = string.Join('.' + "\n\n", Results);
            }
            else
            {
                MessageBox.Show("Error");
            }
            //string[] Test = translator.SplitTextToSentences();
            //textBox2.Text = string.Join(Environment.NewLine, Test);

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}