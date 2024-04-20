using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GiveGetDepthFirst : SolverBase
{
    Stack<Node> openNodes;
    List<Node> closedNodes;
    private bool checkCircle;

    public GiveGetDepthFirst(bool checkCircle = true)
    {
        this.openNodes = new Stack<Node>();
        this.openNodes.Push(base.StartNode);
        this.closedNodes = new List<Node>();
        this.checkCircle = checkCircle;
    }

    public override Node Search()
    {
        return checkCircle ?
            SearchWithCircleCheck() :
            SearchWithoutCircleCheck();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }

    private Node SearchWithCircleCheck()
    {
        while (openNodes.Count != 0)
        {
            Node openNode = openNodes.Pop();
            List<Node> children = openNode.GetAllChildren();
            foreach (Node node in children)
            {
                if (node.IsTerminal)
                    return node;

                if (!closedNodes.Contains(node) && !openNodes.Contains(node))
                    openNodes.Push(node);
            }
            closedNodes.Add(openNode);
        }

        return null;
    }
    private Node SearchWithoutCircleCheck()
    {
        while (openNodes.Count != 0)
        {
            Node openNode = openNodes.Pop();
            List<Node> children = openNode.GetAllChildren();
            foreach (Node node in children)
            {
                if (node.IsTerminal)
                    return node;

                openNodes.Push(node);
            }
        }

        return null;
    }
}

