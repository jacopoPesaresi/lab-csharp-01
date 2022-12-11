namespace Iterators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The static class declares extension methods which use the same naming used by Java 8 with Stream API.
    /// </summary>
    public static class Java8StreamOperations
    {
        /// <summary>
        /// Performs an action for each element of this stream.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="consumer">a non-interfering action to perform on the elements.</param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        public static void ForEach<TAny>(this IEnumerable<TAny> sequence, Action<TAny> consumer)
        {
            /*
            IEnumerator<TAny> mySeq = sequence.GetEnumerator();
            consumer.Invoke(mySeq.Current);
            while (mySeq.MoveNext()){
                consumer.Invoke(mySeq.Current);
            } 
            */
            foreach (TAny item in sequence) 
            {
                consumer(item);
            }
        }

        /// <summary>
        /// Returns an enumerable consisting of the elements of the specified <paramref name="sequence"/>,
        /// additionally performing the provided action on each element as elements are consumed from the sequence.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="consumer">a non-interfering action to perform on the elements as they are consumed.</param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<TAny> Peek<TAny>(this IEnumerable<TAny> sequence, Action<TAny> consumer)
        {
            foreach (TAny item in sequence)
            {
                consumer(item);
                yield return item;
            }
        }

        /// <summary>
        /// Returns a sequence consisting of the results of applying the given function
        /// to the elements of the <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="mapper">a non-interfering, stateless function to apply to each element.</param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <typeparam name="TOther">The element type of the new sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<TOther> Map<TAny, TOther>(this IEnumerable<TAny> sequence, Func<TAny, TOther> mapper)
        {
            /*

            Inizialmente, per fare queste funzioni, ho cercato di farle usando il "Enumerator" dal relativo "Enumerable", 
            e poi modellarlo con questo... ma dopo una serie di errori ho rinunciato e mi sono lasciato ispirare dai foreach
            In alcuni metodi li ho tolti, ma in altri (tra cui questi) lo ho tenuto (secondo me è qui il problema infatti):  
            
            IEnumerator<TAny> mySeq = sequence.GetEnumerator();
            yield return mapper(mySeq.Current);
            while (mySeq.MoveNext()){
                yield return mapper(mySeq.Current);
            } 

            È così sbagliato ricorrere agli enumerator? (anche se, grazie agli foreach, la risposta potrebbe essere banalmente sì
            però non mi capacito perchè così no e invece con i foreach sì)

            */

            foreach(TAny item in sequence)
            {
                yield return mapper(item);
            }
        }

        /// <summary>
        /// Returns a stream consisting of the elements of this stream that match the given predicate.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="predicate">
        /// a non-interfering, stateless predicate to apply to each element to determine if it should be included.
        /// </param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<TAny> Filter<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> predicate)
        {
            foreach(TAny item in sequence)
            {
                if(predicate(item)) yield return item;
            }
        }

        /// <summary>
        /// Returns a new sequence containing a tuple with each element and its index in the original sequence.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<Tuple<int, TAny>> Indexed<TAny>(this IEnumerable<TAny> sequence)
        {
            int counter=0;
            foreach(TAny item in sequence)
            {
                yield return new Tuple<int, TAny>(counter++,item);
            }
            /*
            IEnumerator<TAny> mySeq = sequence.GetEnumerator();
            int counter = 0;
            yield return new Tuple<int, TAny>(counter, mySeq.Current);
            while(mySeq.MoveNext()){
                counter++;
                yield return new Tuple<int, TAny>(counter, mySeq.Current);
            }
            */
        }

        /// <summary>
        /// Performs a reduction on the elements of the <paramref name="sequence"/>, using a <paramref name="reducer"/>
        /// function and returns the reduced value, if any, or <see langword="default"/> if not.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="seed">the base accumulator value.</param>
        /// <param name="reducer">the reducer function.</param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <typeparam name="TOther">the type of the accomulation result.</typeparam>
        /// <returns>the new sequence.</returns>
        public static TOther Reduce<TAny, TOther>(this IEnumerable<TAny> sequence, TOther seed, Func<TOther, TAny, TOther> reducer)
        {
            foreach(TAny item in sequence)
            {
                seed = reducer(seed, item);
            }
            return seed;
        }

        /// <summary>
        /// Returns a sequence containing all elements except the first elements that satisfy the given predicate.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="predicate">
        /// a non-interfering, stateless predicate to apply to the first elements.
        /// </param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<TAny> SkipWhile<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> predicate)
        {
            foreach(TAny item in sequence)
            {
                if (!predicate(item)) yield return item;
            }
        }

        /// <summary>
        /// Returns a sequence consisting of the remaining elements of the <paramref name="sequence"/> after discarding
        /// the first <paramref name="count"/> elements of the sequence.
        /// If this sequence contains fewer elements, then an empty sequence will be returned.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="count">the number of leading elements to skip.</param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<TAny> SkipSome<TAny>(this IEnumerable<TAny> sequence, long count)
        {
            foreach (TAny item in sequence)
            {
                if (count != 0)
                {
                    count--;
                }
                else
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Returns a sequence consisting of a subset of elements taken from the <paramref name="sequence"/>
        /// that match the given predicate.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="predicate">
        /// a non-interfering, stateless predicate to apply to elements to determine the elements to take.
        /// </param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<TAny> TakeWhile<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> predicate)
        {
            foreach (TAny item in sequence)
            {
                if(predicate(item)) yield return item;
            }
        }

        /// <summary>
        /// Returns a sequence consisting of the first <paramref name="count"/> elements
        /// of the <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">the sequence.</param>
        /// <param name="count">the number of leading elements to take.</param>
        /// <typeparam name="TAny">the type of the items in the sequence.</typeparam>
        /// <returns>the new sequence.</returns>
        public static IEnumerable<TAny> TakeSome<TAny>(this IEnumerable<TAny> sequence, long count)
        {
            foreach (TAny item in sequence)
            {
                if(count != 0)
                {
                    count--;
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Returns an infinite sequence of integers.
        /// </summary>
        /// <param name="start">the starting element.</param>
        /// <returns>an infinite sequence of integers.</returns>
        public static IEnumerable<int> Integers(int start)
        {
            //return new IEnumerable<int>;
            yield return start++;
        }

        /// <summary>
        /// Returns an infinite sequence of integers starting from <c>0</c>.
        /// </summary>
        /// <returns>an infinite sequence of integers.</returns>
        public static IEnumerable<int> Integers() => Integers(0);

        /// <summary>
        /// Returns a sequence of <paramref name="count"/> integers starting <paramref name="start"/>.
        /// </summary>
        /// <param name="start">the starting element.</param>
        /// <param name="count">the number of items of the sequence.</param>
        /// <returns>the sequence of integers.</returns>
        public static IEnumerable<int> Range(int start, int count) => Integers(start).TakeSome(count);
    }
}
