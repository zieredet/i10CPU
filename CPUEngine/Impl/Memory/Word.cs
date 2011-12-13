using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Memory
{
    public class Word
    {
        protected int memValue;

        public Word() { }

        public Word(int memValue)
            : this()
        {
            this.memValue = memValue;
        }

        public int UValue { get { return memValue; } }

        public Word(int highByte, int lowByte)
            : this()
        {
            memValue = (highByte % 256) * 256 + (lowByte % 256);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Word)) return false;

            Word w = (Word)obj;
            return (w.UValue == UValue);
        }

        public override int GetHashCode()
        {
            return UValue;
        }
    }

}
