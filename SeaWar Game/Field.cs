using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaWar_Game
{
    public class Field
    {
        private Ship[] Ships4 = new Ship[1];
        private Ship[] Ships3 = new Ship[2];
        private Ship[] Ships2 = new Ship[3];
        private Ship[] Ships1 = new Ship[4];

        public int GetShipCount(int shipSize)
        {
            switch (shipSize)
            {
                case 4:
                    return Ships4.Count(s => s != null);
                case 3:
                    return Ships3.Count(s => s != null);
                case 2:
                    return Ships2.Count(s => s != null);
                case 1:
                    return Ships1.Count(s => s != null);
                default:
                    return 0;
            }
        }

        public void AddShip4(Ship.Coordinate[] coordinates)
        {
            Ships4[0] = new Ship(4);
            Ships4[0].AddCoordinates(coordinates);
        }

        public void AddShip3(Ship.Coordinate[] coordinates)
        {
            int ship3Count = GetShipCount(3);

            Ships3[ship3Count] = new Ship(ship3Count);
            Ships3[ship3Count].AddCoordinates(coordinates);
        }

        public void AddShip2(Ship.Coordinate[] coordinates)
        {
            int ship2Count = GetShipCount(2);

            Ships2[ship2Count] = new Ship(2);
            Ships2[ship2Count].AddCoordinates(coordinates);
        }

        public void AddShip1(Ship.Coordinate[] coordinates)
        {
            int ship1Count = GetShipCount(2);

            Ships1[ship1Count] = new Ship(1);
            Ships1[ship1Count].AddCoordinates(coordinates);
        }

        public bool IsShipAvaiable(Ship.Coordinate coordinate)
        {
            foreach (Ship ship in Ships4)
            {
                if (ship != null)
                {
                    foreach (Ship.Coordinate shipCoordinate in ship.Coordinates)
                    {
                        if (shipCoordinate.Letter == coordinate.Letter && shipCoordinate.Number == coordinate.Number)
                        {
                            return true;
                        }
                    }
                }
            }
            foreach (Ship ship in Ships3)
            {
                if (ship != null)
                {
                    foreach (Ship.Coordinate shipCoordinate in ship.Coordinates)
                    {
                        if (shipCoordinate.Letter == coordinate.Letter && shipCoordinate.Number == coordinate.Number)
                        {
                            return true;
                        }
                    }
                }
            }
            foreach (Ship ship in Ships2)
            {
                if (ship != null)
                {
                    foreach (Ship.Coordinate shipCoordinate in ship.Coordinates)
                    {
                        if (shipCoordinate.Letter == coordinate.Letter && shipCoordinate.Number == coordinate.Number)
                        {
                            return true;
                        }
                    }
                }
            }
            foreach (Ship ship in Ships1)
            {
                if (ship != null)
                {
                    foreach (Ship.Coordinate shipCoordinate in ship.Coordinates)
                    {
                        if (shipCoordinate.Letter == coordinate.Letter && shipCoordinate.Number == coordinate.Number)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
