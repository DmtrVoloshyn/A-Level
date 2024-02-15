using System.Collections;

namespace CustomGeneric
{
    public class CustomCollection<T> : IEnumerable<T>
    {
        private T[] arrayInProcessing;
        public int Count => arrayInProcessing.Length;

        public CustomCollection()
        {
            arrayInProcessing = new T[0];
        }

        public void Add(T item)
        {
            Array.Resize(ref arrayInProcessing, arrayInProcessing.Length + 1);
            arrayInProcessing[arrayInProcessing.Length - 1] = item;
        }

        public void SetDefaultAt(int index)
        {
            if (index >= 0 && index < arrayInProcessing.Length)
            {
                arrayInProcessing[index] = default;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range exception.");
            }
        }

        public void Sort()
        {
            Array.Sort(arrayInProcessing);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in arrayInProcessing)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

