using Assets.AI_Project;
using System.Collections;
using System.Collections.Generic;

public abstract class SolverBase
{
    private Node startNode;
    public SolverBase()
    {
        this.startNode = new Node();
    }

    public Node StartNode { get { return startNode; } }

    public Stack<Node> GetSolution(Node terminalNode)
    {
        if (terminalNode == null)
            return null;

        Stack<Node> solution = new Stack<Node>();
        Node node = terminalNode;
        while (node != null)
        {
            solution.Push(node);
            node = node.Parent;
        }

        return solution;
    }

    public abstract Node Search();
    public abstract override string ToString();
}
