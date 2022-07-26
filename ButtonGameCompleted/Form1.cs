namespace ButtonGameCompleted
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateButtons();
        }
        private void CreateButtons()
        {
            List<int> randomIndex = new List<int>();
            List<int> tempList = new List<int>();
            while (randomIndex.Count < 6)
            {
                int random = new Random().Next(25);
                if (!tempList.Contains(random))
                {
                    randomIndex.Add(random);
                }
            }

            for (int i = 0; i < 25; i++)
            {
                Button newButton = new Button();
                newButton.Width = 50;
                newButton.Height = 50;
                newButton.Left = (i % 5) * 50;
                newButton.Top = (i / 5) * 50;
                newButton.Enabled = !randomIndex.Contains(i);
                newButton.Name = Convert.ToString(i);
                newButton.Click += new EventHandler(ButtonClicked);
                Controls.Add(newButton);
            }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button triggeredButton = (Button)sender;
            triggeredButton.Text = CalculateNeighborhood(Convert.ToInt32(triggeredButton.Name));
        }

        private string CalculateNeighborhood(int buttonIndex)
        {
            int neighboorhoodCount = 0;
            List<int> rules = new int[] { -1, 1, -5, 5 }.ToList();

            foreach (int index in rules)
            {
                if ((buttonIndex / 5 == (buttonIndex + index) / 5 || buttonIndex % 5 == (buttonIndex + index) % 5)
                                                    && (buttonIndex + index) >= 0 && (buttonIndex + index) < 25)
                {
                    Button button = (Button)Controls.Find(Convert.ToString(buttonIndex + index), false)[0];
                    neighboorhoodCount += button.Enabled ? 1 : 0;
                }
            }

            return Convert.ToString(neighboorhoodCount);
        }


    }
}