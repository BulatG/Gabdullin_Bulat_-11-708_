using System.Collections.Generic;
using System;

namespace yield
{
    public static class MovingAverageTask
    {
        public class QueueItem<T>
        {
            public T Value { get; set; }
            public QueueItem<T> Next { get; set; }
        }

        public class Queue<T>
        {
            QueueItem<T> head;
            QueueItem<T> tail;

            public void Enqueue(T value)
            {
                if (head == null)
                    tail = head = new QueueItem<T> { Value = value, Next = null };
                else
                {
                    var item = new QueueItem<T> { Value = value, Next = null };
                    tail.Next = item;
                    tail = item;
                }
            }

            public T Dequeue()
            {
                if (head == null) throw new InvalidOperationException();
                var result = head.Value;
                head = head.Next;
                if (head == null)
                    tail = null;
                return result;
            }
        }

        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var n = 1;
            var prevElem = 0.0;
            var queue = new Queue<double>();

            foreach (var elem in data)
            {
                if (n > windowWidth)
                {
                    prevElem += elem.OriginalY - queue.Dequeue();
                    elem.AvgSmoothedY = prevElem / windowWidth;

                }
                else
                {
                    prevElem += elem.OriginalY;
                    elem.AvgSmoothedY = prevElem / n;
                }
                yield return elem;
                queue.Enqueue(elem.OriginalY);
                n++;
            }
        }
    }
}
