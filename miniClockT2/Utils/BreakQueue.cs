using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniClockT2.Utils
{
    class BreakQueue<T> : IEnumerable
    {
        private T[] QArray { get; set; }
        public int Length { get; }

        public T this[int index] => QArray[index];

        public BreakQueue(int length)
        {
            Length = length;
            QArray = new T[length];
        }

        public void Enqueue(T elem)
        {
            for (int i = QArray.Length - 2; i >= 0; i--)
            {
                QArray[i + 1] = QArray[i];
            }

            QArray[0] = elem;
        }

        public void Clear()
        {
            QArray = new T[Length];
        }

        public IEnumerator GetEnumerator()
        {
            return QArray.GetEnumerator();
        }
    }
}
