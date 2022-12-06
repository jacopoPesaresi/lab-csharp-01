namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] _seeds;

        private string[] _names;

        public IList<string> Seeds 
        {
            get => _seeds.ToList();
            set => _seeds = value.ToArray();
        }

        public IList<string> Names
        {
            get => _names.ToList();
            set => _names = value.ToArray();
        }
       
        // TODO improve
        public int GetDeckSize() => _names.Length * _seeds.Length;

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (Names == null || Seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, _names.Length)
                .SelectMany(i => Enumerable
                    .Repeat(i, _seeds.Length)
                    .Zip(
                        Enumerable.Range(0, _seeds.Length),
                        (n, s) => Tuple.Create(_names[n], _seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}
