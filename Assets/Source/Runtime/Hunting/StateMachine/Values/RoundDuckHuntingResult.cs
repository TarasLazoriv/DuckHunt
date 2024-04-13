using System;
using System.Collections.Generic;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IRoundDuckHuntingAddResult : ICommandVoid<bool> { }
    public interface IRoundDuckHuntingReplaceToTheEnd : ICommandVoid<int> { }
    public interface IRoundDuckHuntingClearResults : ICommand { }
    public interface IRoundDuckHuntingResultObservable : IObservable<IEnumerable<bool>> { }
    public interface IRoundDuckHuntingResult : IReadOnlyValueContainer<IEnumerable<bool>> { }
    public interface IRoundDuckHuntingReplace : ICommandVoid<IEnumerable<bool>> { }

    public sealed class RoundDuckHuntingResult : CustomObservable<IEnumerable<bool>>, IRoundDuckHuntingReplace, IRoundDuckHuntingResult, IRoundDuckHuntingReplaceToTheEnd, IRoundDuckHuntingAddResult, IRoundDuckHuntingClearResults, IRoundDuckHuntingResultObservable
    {
        private readonly List<bool> m_duckResults = new List<bool>();

        public void Execute(bool v1)
        {
            m_duckResults.Add(v1);
            NotifyObservers(m_duckResults);
        }

        void ICommand.Execute()
        {
            m_duckResults.Clear();
            NotifyObservers(m_duckResults);
        }

        IEnumerable<bool> IReadOnlyValueContainer<IEnumerable<bool>>.Value => m_duckResults;

        public void Execute(int v1)
        {
            bool element = m_duckResults[v1];
            m_duckResults.RemoveAt(v1);
            Execute(element);
        }

        public void Execute(IEnumerable<bool> v1)
        {
            m_duckResults.Clear();
            m_duckResults.AddRange(v1);
            NotifyObservers(m_duckResults);
        }
    }
}
