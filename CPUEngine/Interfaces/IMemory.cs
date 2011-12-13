using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU.Interfaces
{
    public interface IMemory
    {
        void Init(int size);

        Word GetWord(int address);
        void SetWord(int address, Word word);

        void SetInstruction(int address, int instuction);
        void SetInstruction(int address, Instruction instruction);
    }





}
