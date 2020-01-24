#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace AdventOfCode.IntcodeComputer
{
    public class Instruction : IFormattable
    {
        public OpCode OpCode { get; }
        public ParameterMode Parameter1Mode { get; }
        public ParameterMode Parameter2Mode { get; }
        public ParameterMode Parameter3Mode { get; }

        public Instruction(int input)
        {
            var codes = input.ToString().PadLeft(5, '0');

            // Console.WriteLine(codes);
            // Console.WriteLine(codes.Substring(codes.Length - 2));

            var opCodeValue = int.Parse(codes.Substring(codes.Length - 2));
            
            // Console.WriteLine(opCodeValue);

            OpCode = (OpCode) opCodeValue;
            
            // Console.WriteLine(OpCode);

            Parameter3Mode = (ParameterMode) int.Parse(codes[0].ToString());
            Parameter2Mode = (ParameterMode) int.Parse(codes[1].ToString());
            Parameter1Mode = (ParameterMode) int.Parse(codes[2].ToString());
        }
        
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return $"Opcode({OpCode}) A({Parameter3Mode}) B({Parameter2Mode}) C({Parameter1Mode})";
        }
    }
}