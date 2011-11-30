using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU.Impl
{
    public enum eMemory { BasicMemory, CachedMemory }

    public class MemoryFactory
    {
        public static IMemory GetInstance(eMemory memoryType)
        {
            switch (memoryType)
            {
                case eMemory.CachedMemory:
                    return null;  // TODO: implement Cached Memory
                default:
                    return new MemoryBasic();

            }

        }
    }
}
