namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void superButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я супермегакнопка, і цього мене не позбавиш!");
        }

        private void transparency_Click(object sender, EventArgs e)
        {
            Opacity = 1.5 - Opacity;
        }

        private void color_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.LightGray)
                BackColor = Color.Yellow;
            else
                BackColor = Color.LightGray;
        }

        private void helloWorld_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello Home. World заблокований з міркувань карантину");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                superButton.Click += transparency_Click;
            else
                superButton.Click -= transparency_Click;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                superButton.Click += color_Click;
            else
                superButton.Click -= color_Click;
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                superButton.Click += helloWorld_Click;
            else
                superButton.Click -= helloWorld_Click;
        }

    }
}
