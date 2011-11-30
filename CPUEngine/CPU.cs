using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Impl.Commands;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU
{
    public class CPU
    {
        private IMemory mem = null;
        private RegisterSet registerSet = null;


        public CPU()
        {
            mem = new MemoryBasic();
            mem.Init(Config.MEM_SIZE);

            registerSet= new RegisterSet();
        }

        public string[] ReadPgm(string fullFilename)
        {
            FileInfo file = new FileInfo(fullFilename);
            if (!file.Exists) throw new FileNotFoundException(String.Format("File {0} not found or no permission", fullFilename));
            
            if (!fullFilename.ToLower().EndsWith(".cpu"))
                throw new CPUException("filetyp not supported");

            return File.ReadAllLines(fullFilename);
        }

        public void LoadMemory(string[] codelines, int startAddress)
        {
            foreach (String codeline in codelines)
            {
                string opcode = null;
                int i1 = codeline.IndexOf(';');
                if (i1 == 0) continue;
                else if (i1 > 0) opcode = codeline.Substring(0, i1 - 1).Trim();
                else opcode = codeline.Trim();

                ICommand cmd = CommandFactory.GetCommand(opcode);
                if (cmd == null) continue;

                cmd.Parse(codeline);
                mem.SetInstruction(startAddress, cmd.Decode());
                startAddress += cmd.CommandLength;
            }
        }
    }
}
