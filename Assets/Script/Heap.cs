using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heap<T> : IEnumerable<T> where T : IComparable<T>
{
    // 같으면 0
    // 크면 1
    // 작으면 -1

    public List<T> values = new List<T>();

    public void Push(T value)
    {
        values.Add(value);

        int now = values.Count - 1;
        
        while(true)
        {
            int parent = (now - 1) / 2;

            if (values[now].CompareTo(values[parent]) >= 0) break;

            T temp = values[now];
            values[now] = values[parent];
            values[parent] = temp;

            now = parent;
        }
    }

    public T Pop()
    {
        T data = values[0];

        int lastIndex = values.Count - 1;
        values[0] = values[lastIndex];
        values.RemoveAt(lastIndex);
        lastIndex--;

        int next = 0;
        while (true)
        {
            int now = next;
            int left = (now * 2) + 1;
            int right = (now * 2) + 2;

            if (left <= lastIndex && values[left].CompareTo(values[now]) < 0)
                now = left;
            if(right <= lastIndex && values[right].CompareTo(values[now]) < 0)
                now = right;
            if (now == next) break;

            T temp = values[next];
            values[next] = values[now];
            values[now] = temp;

            next = now; 
        }

        return data;
    }

    public int Count {  get { return values.Count; } }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var value in values)
        {
            yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
