using System;
using System.Collections;
using LazerLabs.Commands;

namespace LazerLabs.Commands
{
    public abstract class CoroutineMonoExecutor : BaseMonoExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>
    {

    }
}