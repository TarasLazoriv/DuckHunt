using System;
using System.Collections;
using LazerLabs.Commands;

namespace DuckHunt
{
    public abstract class CoroutineMonoExecutor : BaseMonoExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>
    {

    }
}