
namespace Cubeventory
{
    public partial class Form1 : Form
    {

        List<Card> cards = new List<Card>();
        Card selectedCard = null;
        int index;
        int xPos = 5;
        List<String> imageLocations = new List<String>();
        int cardNumber = -1;
        int totalCards = 0;
        int lineAnimation = 0;


        List<Cube> cubes = new List<Cube>();
        Cube selectedCube = null;
        int indexCube;
        List<String> cubeLocations = new List<String>();
        int cubeNumber = -1;
        int totalCubes = 0;


        public Form1()
        {
            InitializeComponent();
            initializeCards();
        }

        private void initializeCards()
        {
            imageLocations = Directory.GetFiles("cards", "*.png").ToList();
            totalCards = imageLocations.Count;

            comboBox1.DataSource = imageLocations;
        }

        private void makeCards(String imageLocation)
        {
            cardNumber++;
            xPos += 55;
            Card newCard = new Card(imageLocation);
            newCard.cardPosition.X = xPos;
            newCard.cardPosition.Y = 300;
            newCard.cardSpace.X = newCard.cardPosition.X;
            newCard.cardSpace.Y = newCard.cardPosition.Y;
            cards.Add(newCard);
        }

        private void initializeCubes()
        {
            cubeLocations = Directory.GetFiles("cubes", "*.png").ToList();

            comboBox1.DataSource = imageLocations;
        }

        private void makeCubes(String imageLocation)
        {
            Directory.GetFile("cubes", "*.png")


            Cube newCube = new Cube(imageLocation, );
            newCard.cardPosition.X = xPos;
            newCard.cardPosition.Y = 300;
            newCard.cardSpace.X = newCard.cardPosition.X;
            newCard.cardSpace.Y = newCard.cardPosition.Y;
            cards.Add(newCard);
        }

        private void drawGrid(PaintEventArgs e)
        {
            Pen boxPen = new Pen(Color.RebeccaPurple);
            int n = 25;
            int grid = (int)Math.Sqrt(n);
            int x = 0, y = 0;
            int yCounter = 0;
            int xCounter = 0;
            for (int i = 0; i < n; i++)
            {
                

                if (i % grid == 0)
                {
                    y = yCounter * 50;
                    yCounter++;
                    xCounter = 0;
                }
                else
                {
                    xCounter++;
                }

                x = xCounter * 50;
                

                e.Graphics.DrawRectangle(boxPen, new Rectangle(x + 300, y + 50, 50, 50));

                /*myGeometricObject[i].Location = new System.Drawing.Point(x, y);
                myGeometricObject[i].Size = new System.Drawing.Size(50, 50);
                this.Controls.Add(myGeometricObject[i]);*/
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point(e.X, e.Y);

            foreach (Card card in cards)
            {
                if (selectedCard == null)
                {
                    if (card.cardSpace.Contains(mousePosition))
                    {
                        selectedCard = card;
                        index = cards.IndexOf(card);
                        label1.Text = index.ToString();
                    }

                }
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedCard != null)
            {
                selectedCard.cardPosition.X = e.X - (selectedCard.width / 2);
                selectedCard.cardPosition.Y = e.Y - (selectedCard.height / 2);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedCard != null && selectedCard.cardPosition.X > 300) {
                selectedCard.cardPosition.X = (50 * ((selectedCard.cardPosition.X - 300) / 50)) + 300;
                selectedCard.cardPosition.Y = (50 * ((selectedCard.cardPosition.Y) / 50));
            }
            //selectedCard.dragging = false;
            selectedCard = null;
            lineAnimation = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid(e);
            foreach (Card card in cards)
            {
                e.Graphics.DrawImage(card.cardImg, card.cardPosition.X, card.cardPosition.Y, card.width, card.height);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Card card in cards)
            {
                card.cardSpace.X = card.cardPosition.X;
                card.cardSpace.Y = card.cardPosition.Y;
            }

            if (selectedCard != null && lineAnimation < 10)
            {
                lineAnimation++;
            }

            this.Invalidate();
        }

        private void addCardButton_Click(object sender, EventArgs e)
        {
            makeCards(imageLocations[comboBox1.SelectedIndex]);
        }
    }
}
