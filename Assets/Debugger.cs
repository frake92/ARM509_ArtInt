
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

namespace Assets
{
    
    public class Debugger : MonoBehaviour
    {
        void Debug_Help()
        {
            SolverBase solver = new GiveGetBreadthFirst();
            Stack<Node> solution = solver.GetSolution(solver.Search());

            while (solution.Count != 0)
            {
                Debug.Log(solution.Pop().ToString());
            }

        }
        private void Start()
        {
            Debug_Help();
        }

    }
}
