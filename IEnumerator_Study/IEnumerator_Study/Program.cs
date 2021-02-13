using System;
using System.Collections;
/*
迭代器学习
C#1.0中，使用foreach可以遍历一个集合中的元素
只有实现了IEnumrable接口才可以使用foreach

interface IEnumerable
{
    IEnumerator GetEnumerator();
}

interface IEnumerator
{
    object Current();
    bool MoveNext();
    void Reset();
}

C#2.0中利用了yield关键字来简化了迭代器的实现
 */

namespace IEnumStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //C#1.0版本的迭代器，需要自己写IEnumerator
            Console.WriteLine("----C#1.0----");
            Friends_Old fs = new Friends_Old();
            foreach (var VARIABLE in fs)
            {
                var f = VARIABLE as FriendBase;
                Console.WriteLine(f.Name);
            }
            //C#2.0版本的迭代器，在GetIEnumerator()函数里面直接yield return就可以了
            Console.WriteLine("----C#2.0----");
            Friends_New fs_n = new Friends_New();
            foreach (var VARIABLE in fs_n)
            {
                var f = VARIABLE as FriendBase;
                Console.WriteLine(f.Name);
            }
        }
        
    }

    class FriendBase
    {
        public string Name { get; set; }

        public FriendBase(string name)
        {
            Name = name;
        }
    }

    class Friends_New : IEnumerable
    {
        private FriendBase[] _friends;
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _friends.Length; i++)
            {
                yield return _friends[i];
            }
        }
        public Friends_New()
        {
            _friends = new[]
            {
                new FriendBase("张1"),
                new FriendBase("李2"),
                new FriendBase("王3"),
                new FriendBase("赵4"),
            };
        }
    }
    class Friends_Old : IEnumerable
    {
        private FriendBase[] _friends;

        private Friends_Iterator _friendsIterator;
        
        public FriendBase this[int index]
        {
            get
            {
                return _friends[index];
            }
        }

        public int Count()
        {
            return _friends.Length;
        }
        
        
        public IEnumerator GetEnumerator()
        {
            if ( _friendsIterator == null )
            {
                _friendsIterator = new Friends_Iterator(this);
            }
            return _friendsIterator;
        }

        public Friends_Old()
        {
            _friends = new[]
            {
                new FriendBase("张一"),
                new FriendBase("李二"),
                new FriendBase("王三"),
                new FriendBase("赵四"),
            };
        }
    }

    class Friends_Iterator : IEnumerator
    {
        private int idx;
        private FriendBase _current;
        private readonly Friends_Old _friendsOld; 
        public object Current {
            get
            {
                return _current;
            }
        }
        public void Reset()
        {
            idx = 0;
        }

        public bool MoveNext()
        {
            if (idx < _friendsOld.Count())
            {
                _current = _friendsOld[idx++];
                return true;
            }
            else
            {
                return false;
            }
        }

        public Friends_Iterator(Friends_Old friendsOld)
        {
            _friendsOld = friendsOld;
            idx = 0;
            _current = _friendsOld[idx];
        }
    }
}