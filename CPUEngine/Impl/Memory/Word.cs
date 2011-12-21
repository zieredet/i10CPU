using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Memory
{
    /// <summary>
    /// Base Class for a Memory Item. 
    /// Memory stores just Word with 2Bytes 
    /// </summary>
    public class Word
    {
        protected int memValue;

        public Word() { }

        public Word(int memValue)
            : this()
        {
            this.memValue = memValue;
        }

        /// <summary>
        /// returns the effektiv value stored
        /// </summary>
        public int UValue { get { return memValue; } }

        public Word(int highByte, int lowByte)
            : this()
        {
            memValue = (highByte % 256) * 256 + (lowByte % 256);
        }

        /// <summary>
        /// compaires 2 Words
        /// </summary>
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
