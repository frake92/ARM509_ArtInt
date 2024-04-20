using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class GiveGetBacktrack : SolverBase
    {
        static Random rnd = new Random();

        int limit;
        bool isMemorisable;

        public GiveGetBacktrack(int limit, bool isMemorisable)
        {
            this.limit = limit;
            this.isMemorisable = isMemorisable;
        }
        public GiveGetBacktrack() : this(0, false) { }
        public GiveGetBacktrack(int limit) : this(limit, false) { }
        public GiveGetBacktrack(bool isMemorisable) : this(0, isMemorisable) { }

        public override Node Search()
        {
            return Search(StartNode);
        }
        public Node Search(Node actual)
        {
        int depth = actual.Depth;
            if (limit > 0 && depth >= limit) return null;

            Node parent = null;
            if (isMemorisable)
                parent = actual.Parent;
            while (parent != null)
            {
                if (actual.Equals(parent))
                    return null;
                parent = parent.Parent;
            }

            if (actual.IsTerminal)
                return actual;

            foreach (GiveGetAction fruit1 in Enum.GetValues(typeof(GiveGetAction)))
            {
                foreach (GiveGetAction fruit2 in Enum.GetValues(typeof(GiveGetAction)))
                {
                    Node newNode = new Node(actual);
                    if (newNode.State.ApplyOperator(fruit1, fruit2))
                    {
                        Node terminal = Search(newNode);
                        if (terminal != null)
                            return terminal;
                    }
                }

            }
            

            return null;
        }

        public override string ToString()
        {
            return $"";
        }
    }

