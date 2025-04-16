// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
decimal amount = 1000000.90m;
Console.WriteLine(amount.ToString("n0"));

//File.WriteAllText("test.txt", "Hello World Testing!");
//var result = File.ReadAllText("test.txt");
//Console.WriteLine(result);

//int[] str = { 1, 2, 3, 4, 5 };
//var result = str.FirstOrDefault();
//var result2 = str.Sum();

//int a = 1;

//if (a == 1)
//{
//    throw new Exception("heehee");
//}
////try
////{
////    if (a == 1)
////    {
////        throw new Exception("heehee");
////    }
////}
////catch (Exception ex)
////{
////    Console.WriteLine("Something was wrong.");
////}

////Console.ReadLine();

////Resume resume = new Resume(); // instance
//Resume resume = new Resume("Mg Mg", 16);
////resume.Name = "Mg Mg";
////resume.Age = 18;
//resume.SetAge(18);
////var result = resume.Is18Year();
////resume.Is18 = true;
//Console.WriteLine(resume.Name);
//Console.WriteLine(resume.Age);
//Console.WriteLine(resume.Is18);
////Console.WriteLine(result);

//Resume resume2 = new Resume("Ma Ma", 25);
////resume2.Name = "Ma Ma";
////resume.Age = 25;

//Dog dog = new Dog();
//dog.Bark();
//dog.Eat();

IResume resume = new ResumeV2("mgmg", 19);
resume = new Resume("mgmg", 19);

public interface IResume
{

}

public class Resume : IResume
{
    //public Resume()
    //{
    //    Name = "None";
    //}

    public Resume(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; private set; }
    public bool Is18
    {
        get { return Age > 18; }
    }
    public void SetAge(int age)
    {
        Console.WriteLine($"Before {Age}");
        Age = age;
        Console.WriteLine($"After {Age}");
    }
    //public bool Is18Year()
    //{
    //    bool result = Age > 18;
    //    return result;
    //}
}

public class ResumeV2 : IResume
{
    //public Resume()
    //{
    //    Name = "None";
    //}

    public ResumeV2(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; private set; }
    public bool Is18
    {
        get { return Age > 18; }
    }
    public void SetAge(int age)
    {
        Console.WriteLine($"Before {Age}");
        Age = age;
        Console.WriteLine($"After {Age}");
    }
    //public bool Is18Year()
    //{
    //    bool result = Age > 18;
    //    return result;
    //}
}

//public class AAResume : Resume
//{
//    public AAResume(string name, int age) : base(name, age)
//    {
//    }
//}

//public class Animal
//{
//    public void Eat()
//    {
//        Console.WriteLine("Animal is eating.");
//    }
//}

//public class Dog : Animal
//{
//    public void Bark()
//    {
//        Console.WriteLine("Dog is barking.");
//    }
//}

//public interface ITransfer
//{
//    void Create();
//    void Read();
//    void Update();
//    void Delete();
//}

//public class Kpay : ITransfer
//{
//    public void Create()
//    {
//        throw new NotImplementedException();
//    }

//    public void Delete()
//    {
//        throw new NotImplementedException();
//    }

//    public void Read()
//    {
//        throw new NotImplementedException();
//    }

//    public void Update()
//    {
//        throw new NotImplementedException();
//    }
//}