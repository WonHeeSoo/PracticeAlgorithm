using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAlgorithm
{
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];
        public int Count = 0; // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인한다
            if (Count >= Capacity)
            {
                // 공간을 다시 늘려서 확보한다
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }
            // 2. 확보된 공간에다가 데이터를 넣어준다
            _data[Count] = item;
            Count++;
        }

        public T this[int index] // 인덱서
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];

            _data[Count - 1] = default(T);
            Count--;
        }
    }

    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 첫번째
        public MyLinkedListNode<T> Tail = null; // 마지막
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>();
            newNode.Data = data;

            // 만약에 아직 노드가 존재하지 않는다면, 새로 추가한 첫번째 노드가 곧 Head이다.
            if (Head == null)
                Head = newNode;

            // 기존의 [마지막 노드]와 [새로 추가되는 노드]를 연결해준다.
            if (Tail != null)
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
            }

            // [새로 추가되는 방]을 [마지막 방]으로 인정한다.
            Tail = newNode;
            Count++;
            return newNode;
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            // [기존의 첫번째 노드의 다음 노드]를 [첫번째 노드]로 인정한다.
            if (Head == node)
                Head = Head.Next;

            // [기존의 마지막 노드의 이전 노드]를 [마지막 노드]로 인정한다.
            if (Tail == node)
                Tail = Tail.Prev;

            if (node.Prev != null)
                node.Prev.Next = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;

            Count--;
        }
    }
    class Board
    {
        public int[] _data = new int[25]; // 배열
        public MyList<int> _data2 = new MyList<int>(); // 동적 배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 연결 리스트
        public void Initalize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}
