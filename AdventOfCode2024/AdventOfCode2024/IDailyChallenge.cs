namespace AdventOfCode2024;

public interface IDailyChallenge<TInput>
{
     TInput ParseInput(string input);
}