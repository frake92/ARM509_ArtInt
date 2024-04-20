using Assembly_CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Assets.AI_Project
{
    public class Node
    {
        GiveGetState state;
        int depth;
        Node parent;

        public Node()
        {
            this.state = new GiveGetState();
            this.depth = 0;
            this.parent = null;
        }
        public Node(Node parent)
        {
            this.parent = parent;
            this.state = (GiveGetState)parent.state.DeepClone();
            this.depth = parent.depth + 1;
        }

        public int Depth { get { return this.depth; } }
        public Node Parent { get { return this.parent; } }
        public GiveGetState State { get { return this.state; } }
        public bool IsTerminal { get { return this.state.IsGoalState; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj is not Node) return false;

            Node other = obj as Node;
            return this.state.Equals(other.state);
        }
        public override int GetHashCode()
        {
            return this.state.GetHashCode();
        }

        public List<Node> GetAllChildren()
        {
            List<Node> children = new List<Node>();

            foreach (GiveGetAction dir in Enum.GetValues(typeof(GiveGetAction)))
            {
                Node child = new Node(this);
                if (child.State.ApplyOperator(dir))
                    children.Add(child);
            }

            return children;
        }
    }
}
