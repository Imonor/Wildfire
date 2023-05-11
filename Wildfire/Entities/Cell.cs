using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wildfire.Entities
{
    public class Cell
    {
        public State CurrentState { get; set; }

        public Cell(State state)
        {
            CurrentState = state;
        }

        public Cell()
        {
            CurrentState = State.Tree;
        }

    }

    public enum State
    {
        NULL,
        Tree,
        Fire,
        Ash
    }
}
