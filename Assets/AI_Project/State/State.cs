using Assets.AI_Project;
using System.Collections;
using System.Collections.Generic;

public abstract class State : IDeepCloneable<State>
{
    public abstract bool IsState { get; }
    public abstract bool IsGoalState { get; }

    public abstract State DeepClone();
    public abstract override bool Equals(object obj);
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


}
