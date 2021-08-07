using System;

namespace GradeBook
{
    public class Stats
    {
        public double Average
        {
            get{
                return Sum/runningCount;
            }
        }
        public double High;
        public double Low;
        public char LetterGrade 
        {
            get{
                return GetLetterGradeFromGrade(Average);
            }
        }
        public double Sum;
        public Stats()
        {
            Sum = 0;
            High = double.MinValue;
            Low = double.MaxValue;
            runningCount = 0;
        }
        public void AddGrade(double grade)
        {
            Sum += grade;
            High = Math.Max(High, grade);
            Low = Math.Min(Low, grade);
            ++runningCount; 
        }
        private char GetLetterGradeFromGrade(double gradeDouble)
        {
            char letterGrade = 'F';
            switch (gradeDouble)
            {
                case var grade when grade >= 90:
                    letterGrade = 'A';
                    break;
                case var grade when grade >= 80:
                    letterGrade = 'B';
                    break;
                case var grade when grade >= 70:
                    letterGrade = 'C';
                    break;
                case var grade when grade >= 60:
                    letterGrade = 'D';
                    break;
                default:
                    letterGrade = 'F';
                    break;
            }
            return letterGrade;
        }
        private int runningCount;
    }
}