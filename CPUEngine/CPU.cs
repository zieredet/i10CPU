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
           
            registerSet = new RegisterSet();
        }

        /// <summary>
        /// This method runs the program from specified start address
        /// </summary>
        /// <param name="startAddress">The Adress where the program starts</param>
        public void Run(int startAddress)
        {

            for (int i = 0; i < 3; i++) // To-Do: Value 3 only for testing... 
			{
                ICommand command = CommandFactory.GetCommand(Memory.GetWord(startAddress));
                command.Execute(mem, registerSet);
                startAddress += command.CommandLength;
                    // Stefan has to fix this issue...
			}     

        }

        public string[] ReadPgm(string fullFilename)
        {
            if (!fullFilename.ToLower().EndsWith(".cpu"))
                throw new CPUException("filetyp not supported");

            FileInfo file = new FileInfo(fullFilename);
            if (!file.Exists) throw new FileNotFoundException(String.Format("File {0} not found or no permission", fullFilename));

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

        public IMemory Memory { get { return mem; } }

        public int GetRegisterValue(int registerNr)
        {
            return registerSet.GetRegisterVal(registerNr);
        }
        public int GetRegisterUValue(int registerNr)
        {
            return registerSet.GetRegisterUVal(registerNr);
        }
    }
}
