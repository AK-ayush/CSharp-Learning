using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public interface IBook
    {
        event GradeAddedDelegate GradeAdded;
        string Name {get; set;}
        void AddGrades(double grade);
        Stats GetStatistics();
    }
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrades(double grade);
        public abstract Stats GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrades(double grade)
        {
            
            if (grade >= 0 && grade <= 100)
            {   
                using(var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    if(GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid grade!");
            }
        }

        public override Stats GetStatistics()
        {
            var result = new Stats();
            try
            {
                var grades = File.ReadAllLines($"{Name}.txt");
                if(grades.Length == 0)
                {
                    return result;
                }
                foreach (var item in grades)
                {
                    try
                    {
                        var grade = double.Parse(item);
                        result.AddGrade(grade);
                    }
                    catch (FormatException ex)
                    {                        
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {                
                Console.WriteLine(ex.Message);
                return result;
            }
            return result;
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public void AddGrades(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrades(90);
                    break;
                case 'B':
                    AddGrades(80);
                    break;
                case 'C':
                    AddGrades(70);
                    break;
                default:
                    AddGrades(0);
                    break;
            }
        }
        public override void AddGrades(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                // ... add the event listener
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException("invalid grade");
            }
        }
        public override Stats GetStatistics()
        {
            var result = new Stats();
            if (grades.Count < 1)
            {
                return result;
            }

            foreach (var grade in grades)
            {
                result.AddGrade(grade);

            }
            return result;
        }

        private List<double> grades;
        public override event GradeAddedDelegate GradeAdded;
    }
}