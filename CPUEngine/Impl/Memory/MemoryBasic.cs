using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ch.zhaw.HenselerGroup.CPU.Interfaces;
using System.Collections;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Memory
{
    /// <summary>
    /// Memory.
    /// A word needs 2 bytes.
    /// </summary>
    public class MemoryBasic : IMemory
    {
        private int[] mem = null;

        public void Init(int size)
        {
            mem = new int[size];
        }

        public Word GetWord(int address)
        {
            if (mem == null || mem.Length < address - 1 || address < 0) return null;
            return new Word(mem[address], mem[address + 1]);
        }

        // funktioniert leider nicht, da zuviele Einschränkungen
        //public IEnumerator<Word> GetWordEnumerator()
        //{
        //    int max = mem.Length - 1;
        //    for (int i = 0; i < max; i++)
        //    {
        //        yield return new Word(mem[i], mem[i + 1]);
        //    }
        //}

        public IEnumerator GetWordEnumerator()
        {
            List<Word> tempMem = new List<Word>();
            int max = mem.Length - 1;
            for (int i = 0; i < max; i += 2)
                tempMem.Add(new Word(mem[i], mem[i + 1]));
            return tempMem.GetEnumerator();
        }

        public void SetInstruction(int address, int instuction) { mem[address] = instuction; }
        public void SetInstruction(int address, Instruction instruction) { SetWord(address, instruction.InstructionCode); }
        public void SetWord(int address, Word word) { SetWord(address, word.UValue); }
        public void SetWord(int address, int uvalue)
        {
            mem[address] = (int)(uvalue / 256);
            mem[address + 1] = (int)(uvalue % 256);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetWordEnumerator();
        }

        IEnumerator<Word> IEnumerable<Word>.GetEnumerator()
        {
            return new List<Word>().GetEnumerator();
        }
    }
}
