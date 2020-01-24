namespace AdventOfCode.IntcodeComputer
{
    public enum OpCode
    {
        Addition = 1,
        Multiplication = 2,
        Put = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Exit = 99
    }
}