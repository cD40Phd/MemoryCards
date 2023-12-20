using MemoryLibrary;
namespace MemoryGameWinFormsApp
{
    public partial class MainForm : Form, IPaybleInterface
    {
        LogicMemory logic;
        public int clickCounterWin = 10000000;

        public MainForm()
        {
            InitializeComponent();
            logic = new LogicMemory(this);
            logic.CreateGame();
        }

        private void Exit_MainForm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RulsGame_MainForm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Как играть в игру Мемори?\r\nПравила игры очень просты. На столе раскладывается четное количество парных карточек, рубашками наверх. Цель игры — как можно быстрее закончить ее, собрав максимальное количество пар, щелкая левой кнопкой мыши по две карточки сразу. Открыв карточки с разными картинками, их оставляют в игре.", "Правила игры");
        }

        private void About_author_MAinForm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Игра Мемори создана в обучающих целях.\r\nMoй блог: http://dmitryshipovalenko.tilda.ws", "Об авторе");
        }

        private void pictureBox15_MouseClick(object sender, MouseEventArgs e)
        {
            int numberPicture = int.Parse(((PictureBox)sender).Tag.ToString());

            logic.ClikPicture(numberPicture);


        }

        public void LoadPicture(int numerPicture, int image)
        {
            GetPicturebox(numerPicture).Image = GetImage(image);
        }

        public PictureBox GetPicturebox(int numerPicture)
        {
            switch (numerPicture)
            {
                case 0: return picture0_MainForm_pictureBox;
                case 1: return picture1_MainForm_pictureBox;
                case 2: return picture2_MainForm_pictureBox;
                case 3: return picture3_MainForm_pictureBox;
                case 4: return picture4_MainForm_pictureBox;
                case 5: return picture5_MainForm_pictureBox;
                case 6: return picture6_MainForm_pictureBox;
                case 7: return picture7_MainForm_pictureBox;
                case 8: return picture8_MainForm_pictureBox;
                case 9: return picture9_MainForm_pictureBox;
                case 10: return picture10_MainForm_pictureBox;
                case 11: return picture11_MainForm_pictureBox;
                case 12: return picture12_MainForm_pictureBox;
                case 13: return picture13_MainForm_pictureBox;
                case 14: return picture14_MainForm_pictureBox;
                case 15: return picture15_MainForm_pictureBox;
                default: return null;

            }
        }

        public Image GetImage(int image)
        {
            switch (image)
            {
                case -1: return Properties.Resources.image;
                case 0: return Properties.Resources.image0;
                case 1: return Properties.Resources.image1;
                case 2: return Properties.Resources.image2;
                case 3: return Properties.Resources.image3;
                case 4: return Properties.Resources.image4;
                case 5: return Properties.Resources.image5;
                case 6: return Properties.Resources.image6;
                case 7: return Properties.Resources.image7;
                case 8: return Properties.Resources.image8;
                default: return Properties.Resources.image;

            }
        }

        private void New_Game_MainForm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNumerClic(0);
            logic.CreateGame();

            //startGame();
        }

        public void ShowCard(int numerPicture, int card)
        {
            LoadPicture(numerPicture, card);
            GetPicturebox(numerPicture).Cursor = Cursors.Arrow;
        }

        public void HideCard(int numerPicture)
        {
            LoadPicture(numerPicture, -1);
            GetPicturebox(numerPicture).Cursor = Cursors.Hand;
        }

        public void ShowWinner(int clickCounter)
        {
            if (clickCounter < clickCounterWin)
            {
                clickCounterWin = clickCounter;
            }

            MessageBox.Show($"Вы победили!\nКоличество сделанных ходов {clickCounter}\nВаш рекорд {clickCounterWin}", "Поздравляем");
            //MessageBox.Show($"Вы победили!", "Поздравляем");

        }

        public void ShowNumerClic(int clickCounter)
        {
            clickCounter_MainForm_label.Text = clickCounter.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
