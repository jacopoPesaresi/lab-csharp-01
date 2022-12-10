namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        //private IDictionary< Tuple<TKey1, TKey2>, TValue> _myMap;
        private IDictionary< Tuple<TKey1, TKey2>, TValue> _myMap;
        public Map2D () 
        {
            //_myMap = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
            _myMap = new Dictionary< Tuple<TKey1, TKey2>, TValue>();
        }
        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        { 
            get => _myMap.Count;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => _myMap[new Tuple<TKey1, TKey2>(key1, key2)];
            set => _myMap[new Tuple<TKey1, TKey2>(key1, key2)] = value;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            IList<Tuple<TKey2, TValue>> tmp = new List<Tuple<TKey2, TValue>>();
            foreach ( KeyValuePair<Tuple<TKey1, TKey2>, TValue> pair in _myMap)
            {
                if(pair.Key.Item1.Equals(key1))
                {
                    tmp.Add(new Tuple<TKey2, TValue>(pair.Key.Item2, pair.Value));
                }
            }
            return tmp;
            /*
            IList<Tuple<TKey2, TValue>> tmp = new List<Tuple<TKey2, TValue>>();
            foreach ( KeyValuePair<TKey2,TValue> pair in _myMap[key1])
            {
                tmp.Add(new Tuple<TKey2, TValue>(pair.Key, pair.Value));
            }
            return tmp;
            */
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            IList<Tuple<TKey1, TValue>> tmp = new List<Tuple<TKey1, TValue>>();
            foreach ( KeyValuePair<Tuple<TKey1, TKey2>, TValue> pair in _myMap)
            {
                if(pair.Key.Item2.Equals(key2))
                {
                    tmp.Add(new Tuple<TKey1, TValue>(pair.Key.Item1, pair.Value));
                }
            }
            return tmp;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            IList<Tuple<TKey1, TKey2, TValue>> tmp = new List<Tuple<TKey1, TKey2, TValue>>();
            foreach ( KeyValuePair<Tuple<TKey1, TKey2>, TValue> pair in _myMap)
            {
                tmp.Add(new Tuple<TKey1, TKey2, TValue>(pair.Key.Item1, pair.Key.Item2, pair.Value));
            }
            return tmp;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (TKey1 Fkey in keys1)
            {
                foreach ( TKey2 Skey in keys2)
                {
                    this[Fkey, Skey] = generator(Fkey,Skey);
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            // TODO: improve
            //return base.Equals(other);
            IList<Tuple<TKey1, TKey2, TValue>> ThisMap = this.GetElements();
            IList<Tuple<TKey1, TKey2, TValue>> OtherMap = other.GetElements();
            return ThisMap.Equals(OtherMap);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            // TODO: improve
            return base.Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            // TODO: improve
            return base.GetHashCode();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            string tmp = "";
            ISet<TKey1> Keys1 = new HashSet<TKey1>();
            foreach ( KeyValuePair<Tuple<TKey1, TKey2>, TValue> pair in _myMap)
            {
                Keys1.Add(pair.Key.Item1);
            }
            foreach ( TKey1 key in Keys1)
            {
                tmp.Concat($"With key1, {key} there are \n {this.GetRow(key).ToString()} \n");
            }
            // TODO: improve
            return tmp;
        }
    }
}
