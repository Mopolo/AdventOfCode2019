using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.IntcodeComputer
{
    public class IntcodeComputer
    {
        private Dictionary<int, int> _opcodes;

        public IntcodeComputer()
        {
        }

        public void Load(string input)
        {
            var opcodes = new Dictionary<int, int>();
            var opcodeChars = input.Split(",");

            for (var i = 0; i < opcodeChars.Length; i++)
            {
                opcodes.Add(i, int.Parse(opcodeChars[i]));
            }

            _opcodes = opcodes;
        }

        public int Run(int input)
        {
            // Write(1, 12, ParameterMode.Immediate);
            // Write(2, 2, ParameterMode.Immediate);

            // debug();

            var position = 0;
            var steps = 0;

            do
            {
                var instruction = new Instruction(Read(position, ParameterMode.Immediate));
                
                if (instruction.OpCode == OpCode.Exit)
                {
                    return Read(0, ParameterMode.Immediate);
                }
                
                var result = -1;
                var writePosition = -1;
                var positionParameter1 = position + 1;
                var positionParameter2 = position + 2;
                var positionParameter3 = position + 3;

                switch (instruction.OpCode)
                {
                    case OpCode.Addition:
                        steps = 4;
                        
                        result = Read(positionParameter1, instruction.Parameter1Mode) + Read(positionParameter2, instruction.Parameter2Mode);
                        writePosition = positionParameter3;
                        break;
                    case OpCode.Multiplication:
                        steps = 4;
                        
                        result = Read(positionParameter1, instruction.Parameter1Mode) * Read(positionParameter2, instruction.Parameter2Mode);
                        writePosition = positionParameter3;
                        break;
                    case OpCode.Put:
                        steps = 2;
                        
                        result = input;
                        writePosition = positionParameter1;
                        break;
                    case OpCode.Output:
                        steps = 2;
                        
                        result = Read(positionParameter1, instruction.Parameter1Mode);

                        // return result;

                        if (result != 0)
                        {
                            // Console.WriteLine(result);
                            return result;
                        }
                        
                        break;
                    case OpCode.JumpIfTrue:
                        steps = 3;
                        
                        if (Read(positionParameter1, instruction.Parameter1Mode) != 0)
                        {
                            position = Read(positionParameter2, instruction.Parameter2Mode);
                            steps = 0;
                        }
                        break;
                    case OpCode.JumpIfFalse:
                        steps = 3;
                        
                        if (Read(positionParameter1, instruction.Parameter1Mode) == 0)
                        {
                            position = Read(positionParameter2, instruction.Parameter2Mode);
                            steps = 0;
                        }
                        break;
                    case OpCode.LessThan:
                        steps = 4;
                        result = 0;
                        writePosition = positionParameter3;
                    
                        if (Read(positionParameter1, instruction.Parameter1Mode) < Read(positionParameter2, instruction.Parameter2Mode))
                        {
                            result = 1;
                        }
                        break;
                    case OpCode.Equals:
                        steps = 4;
                        result = 0;
                        writePosition = positionParameter3;
                    
                        if (Read(positionParameter1, instruction.Parameter1Mode) == Read(positionParameter2, instruction.Parameter2Mode))
                        {
                            result = 1;
                        }
                        break;
                }

                if (writePosition > -1)
                {
                    Write(writePosition, result, ParameterMode.Position);
                }

                // debug();
                
                position += steps;
            } while (position < _opcodes.Count);

            return 0;
            // return Read(0, ParameterMode.Immediate);
        }

        private int Read(int position, ParameterMode mode)
        {
            if (mode == ParameterMode.Position)
            {
                position = Read(position, ParameterMode.Immediate);
            }
            
            return _opcodes[position];
        }

        private void Write(int position, int value, ParameterMode mode)
        {
            if (mode == ParameterMode.Position)
            {
                position = Read(position, ParameterMode.Immediate);
            }

            _opcodes[position] = value;
        }

        private void debug()
        {
            foreach (var opcode in _opcodes)
            {
                Console.Write(opcode.Value + ",");
            }

            Console.WriteLine();
        }
    }
}