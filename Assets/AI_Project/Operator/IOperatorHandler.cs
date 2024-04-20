using System.Collections;
using System.Collections.Generic;

internal interface IOperatorHandler<T>
{
    bool IsOperator(T t);
    bool ApplyOperator(T t);
}

internal interface IOperatorHandler<T1, T2>
{
    bool IsOperator(T1 t1, T2 t2);
    bool ApplyOperator(T1 t1, T2 t2);
}

internal interface IOperatorHandler<T1, T2, T3>
{
    bool IsOperator(T1 t1, T2 t2, T3 t3);
    bool ApplyOperator(T1 t1, T2 t2, T3 t3);
}

internal interface IOperatorHandler<T1, T2, T3, T4>
{
    bool IsOperator(T1 t1, T2 t2, T3 t3, T4 t4);
    bool ApplyOperator(T1 t1, T2 t2, T3 t3, T4 t4);
}

internal interface IOperatorHandler<T1, T2, T3, T4, T5>
{
    bool IsOperator(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    bool ApplyOperator(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
}

