using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wildfire.Entities
{
    public class Forest
    {
        public int Height { get; private set; }
        public int Length { get; private set; }

        public Cell[,] Cells { get; private set; }

        public Forest(int height, int length, List<Coords> fireCells)
        {
            if (height <= 0 || length <= 0)
            {
                Height = 0;
                Length = 0;
                Cells = new Cell[1, 1];
                return;
            }


            Height = height;
            Length = length;

            Cells = new Cell[height, length];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }

            foreach (var coord in fireCells)
            {
                if(coord.H >= 0 && coord.H < Height && coord.L >= 0 && coord.L < Length)
                    Cells[coord.H, coord.L].CurrentState = State.Fire;
            }
        }

        public Forest()
        {
            Height = 0;
            Length = 0;
            Cells = new Cell[1, 1];
        }

        public State CheckCellState(Coords coords)
        {
            if (coords.H < 0 || coords.L < 0 || coords.H >= Height || coords.L >= Length)
                return State.NULL;
            return Cells[coords.H, coords.L].CurrentState;
        }

        public void AshCell(Coords coords)
        {
            if (coords.H < 0 || coords.L < 0 || coords.H >= Height || coords.L >= Length)
                return;

            if (Cells[coords.H, coords.L].CurrentState == State.Fire)
                Cells[coords.H, coords.L].CurrentState = State.Ash;
        }

        public void FireCell(Coords coords)
        {
            if (coords.H < 0 || coords.L < 0 || coords.H >= Height || coords.L >= Length)
                return;

            if (Cells[coords.H, coords.L].CurrentState == State.Tree)
                Cells[coords.H, coords.L].CurrentState = State.Fire;
        }

        public override string ToString()
        {
            var stringToReturn = "";
            for (int i = 0; i < Height; i++)
            {
                var row = "";
                for (int j = 0; j < Length; j++)
                {
                    var cellState = Cells[i, j].CurrentState;
                    if (cellState == State.Ash)
                        row += "A ";
                    else if (cellState == State.Fire)
                        row += "F ";
                    else
                        row += "T ";
                }
                stringToReturn += row + "\n";
            }

            return stringToReturn;
        }

    }
}
