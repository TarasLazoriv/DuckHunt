using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public abstract class DefaultMonoExecutor : BaseMonoExecutor<ICommandVoid<Action>, Action> { }
}