using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdvanceQuestion8
{
    public struct CircularEnum<T> where T : Enum
    {
        private T en;
        static Dictionary<int, T> enums = new Dictionary<int, T>();
        static int position = 0;
        public static implicit operator T(CircularEnum<T> temp) => temp.en; 
        public static implicit operator CircularEnum<T>(T temp)
        {

            
            var enumVals = Enum.GetValues(typeof(T));
            foreach(var vals in enumVals)
            {
                enums.Add((int)vals, (T)vals);
            }
            CircularEnum<T> t;
            t.en = temp;
            return t;
        }
        
        static CircularEnum()
        {
        }
        public static CircularEnum<T> operator +(CircularEnum<T> a, int x)
        {
            if (x < 0) return a - (Math.Abs(x));
            position += x;
            if (position >= enums.Count) position -= enums.Count;
            a.en = enums[position];
            return a;
        }
        public static CircularEnum<T> operator -(CircularEnum<T> a, int x) => a + -x;
        public static CircularEnum<T> operator ++(CircularEnum<T> a) => a + 1;
        public static CircularEnum<T> operator --(CircularEnum<T> a) => a + -1;

    }
}
