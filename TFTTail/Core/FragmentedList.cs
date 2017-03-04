using System.Collections.Generic;

namespace TFT.Tail.Core
{
    public class FragmentedList<T>
    {
        const int FragmentSize = 64 * 1024;
        List<T[]> fragments = new List<T[]>();
        private int cursor = 0;
        T[] currentFragment;

        public int Count => (fragments.Count-1) * FragmentSize + cursor;
        public FragmentedList()
        {
            CreateFragment();
        }

        private void CreateFragment()
        {
            currentFragment = new T[FragmentSize];
            fragments.Add(currentFragment);
            cursor = 0;
        }

        public void Add(T item)
        {
            currentFragment[cursor++] = item;
            if( cursor == FragmentSize )
            {
                CreateFragment();
            }
        }

        public T this[int index]
        {
            get
            {
                var fragmentNum = index / FragmentSize;
                var offset = index % FragmentSize;
                var fragment = fragments[fragmentNum];
                var item = fragment[offset];
                return item;
            }
        }
    }
}
