using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.AI_Project
{
    public interface IDeepCloneable<T>
    {
        T DeepClone();
    }
}
