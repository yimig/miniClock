using System.Collections;

namespace miniClock.Utils
{
    internal class BreakQueue<T> : IEnumerable
    {
        public BreakQueue(int length)
        {
            Length = length;
            QArray = new T[length];
        }

        private T[] QArray { get; set; }
        public int Length { get; }

        public T this[int index] => QArray[index];

        public IEnumerator GetEnumerator()
        {
            return QArray.GetEnumerator();
        }

        public void Enqueue(T elem)
        {
            for (var i = QArray.Length - 2; i >= 0; i--) QArray[i + 1] = QArray[i];

            QArray[0] = elem;
        }

        public void Clear()
        {
            QArray = new T[Length];
        }
    }
}