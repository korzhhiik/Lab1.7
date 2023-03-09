namespace Task1
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var studentsByGrade = new StudentProcessor().GetStudentsByGrade();
                Console.WriteLine(string.Join(Environment.NewLine, studentsByGrade));
            }
            catch (IOException e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }

    class StudentProcessor
    {
        public IEnumerable<Student> GetStudentsByGrade()
        {
            const string path = "MOCK_DATA (1).csv";
            using var reader = new StreamReader(path);
            return reader.ReadToEnd()
                .Split(Environment.NewLine)
                .Select(line => line.Split(","))
                .Select(studentsArray => new Student(studentsArray[0], int.Parse(studentsArray[1]), int.Parse(studentsArray[2])))
                .OrderBy(student => student.Grade)
                .ToList();
        }
    }

    class Student
    {
        private string Name { get; }
        private int Age { get; }
        public int Grade { get; }

        public Student(string name, int age, int grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
        

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Grade: {Grade}";
        }
    }
}
