using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaWar_Game
{
    public class Ship
    {
        private int _size;
        private int _health;

        private Coordinate[] coordinates;

        public Coordinate[] Coordinates
        {
            get { return coordinates; }
        }

        public Ship(int size)
        {
            _size = size;
            _health = size;

            coordinates = new Coordinate[size];
        }

        public void AddCoordinates(Coordinate[] coordinate)
        {
            for (int i = 0; i < _size; i++)
            {
                this.coordinates[i] = coordinate[i];
            }
        }

        public class Coordinate
        {
            public char Letter { get; set; }
            public int Number { get; set; }

            public bool Damaged { get; set; } = false;
            public Coordinate(char letter, int number)
            {
                Letter = letter;
                Number = number;
            }

            public override string ToString()
            {
                return $"{Letter}{Number}";
            }
        }
    }
}
