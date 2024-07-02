using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubeventory
{
    internal class Card
    {
        public Image cardImg;
        public Point cardPosition = new Point();
        public Rectangle cardSpace;
        public int height, width;

        public Card(string fileName)
        {
            cardImg = Image.FromFile(fileName);
            height = 200;
            width = 100;
            cardSpace = new Rectangle(cardPosition.X, cardPosition.Y, width, height);
        }
    }

    internal class Cube
    {
        public Image cubeImg;
        public Point cubePosition = new Point();
        public Rectangle cubeSpace;
        public int height, width;
        Boolean[][] boxMap;

        public Cube(string fileName, Boolean[][] boxMapIn)
        {
            boxMap = boxMapIn;
            cubeImg = Image.FromFile(fileName);
            height = boxMap.Length * 50;
            width = boxMap[0].Length * 50;
            cubeSpace = new Rectangle(cubePosition.X, cubePosition.Y, width, height);
        }
    }
}
