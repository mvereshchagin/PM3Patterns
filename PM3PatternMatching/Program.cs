using System.IO.Pipes;
using PM3PatternMatching.Data;

var animals = new Animal[]
{
    new Zebra()
    {
        Name = "Василий",
        Description = "Вредный и ленивый",
        Age = 22,
    },
    new Lion()
    {
        Name = "Эдуард",
        Description = "Очень добрый",
        Age = 10,
    },
    new Zebra()
    {
        Name = "Дарья",
        Description = "Спортивная",
        Age = 3,
    },
    new Zebra()
    {
        Name = "Наталья",
        Description = "Спортивная",
        Age = 11,
    },
    new Turtle()
    {
        Name = "Ян",
        Description = "Любит спать",
        Age = 30
    },
    new Turtle()
    {
        Name = "Олеся",
        Description = "Спортивная",
        Age = 5
    }
};

var zoo = new Zoo()
{   
    Animals = animals.ToList()
};

TypePattern();
PropertyPattern();
TuplePattern();
TuplePropertyPattern();
ListPattern();

#region functions

void TypePattern()
{
    foreach (var animal in zoo.Animals)
    {
        if(animal is Zebra zebra)
            Console.WriteLine(zebra);
        
        Console.WriteLine(GetGermanName(animal));
    }
}

string GetGermanName(Animal animal) => animal switch
{
    Zebra => "Zebra",
    Lion => "Lowe",
    Turtle => "Schildkrote",
    _ => "Tier",
};

void PropertyPattern()
{
    Console.WriteLine("==================================================");
    foreach (var animal in zoo.Animals)
    {
        if (animal is Animal { Description: "Спортивная"})
        {
            Console.WriteLine(animal);
        }
    }
    
    Console.WriteLine("==================================================");
    foreach (var animal in zoo.Animals)
    {
        var desc = GetFullDescription(animal);
        Console.WriteLine(desc);
    }
}

string GetFullDescription(Animal animal) => animal.Description switch
{
    "Спортивная" => $"{animal.Description}: подходит для соревнований",
    "Ленивая" => $"{animal.Description}: нужно ткнуть палкой",
    null => "Нет описания",
    _ => animal.Description,
};

string GetFullDescription2(Animal animal) => animal switch
{
    {Description: "Спортивная"} => "Любое животное с Description: Спортивная",
    Zebra {Name: "Дарья"} => "Любая зебра с Name: Дарья",
    Lion {Name: "Петя"} => "Лююой лев с Name: Петя",
    Lion {IsDangerous: false} => "Люой лев с IsDangerous: false",
    Lion => "Любой лев",
    null => "Если null",
    _ => "Default (Если не подошли все остальные)",
};

string GetFullDescription2Long(Animal animal)
{
    switch (animal)
    {
        case {Description: "Спортивная"}:
            return "Любое животное с Description: Спортивная";
        case Zebra {Name: "Дарья"}:
            return "Любая зебра с Name: Дарья";
        case Lion {Name: "Петя"}:
            return "Лююой лев с Name: Петя";
        case Lion {IsDangerous: false}:
            return "Люой лев с IsDangerous: false";
        case Lion:
            return "Любой лев";
        case null:
            return "Если null";
        default:
            return "Default (Если не подошли все остальные)";
    }
}

void TuplePattern()
{
    Console.WriteLine("========================================================");
    foreach (var animal in zoo.Animals)
    {
        var str = GetName(animal);
        Console.WriteLine($"{animal} - {str}");
    }
}

void TuplePropertyPattern()
{
    Console.WriteLine("============================================");
    foreach (var animal in zoo.Animals)
    {
        var desc = GetName2(animal);
        Console.WriteLine($"{animal} - {desc}");
    }
    
    Console.WriteLine("============================================");
    foreach (var animal in zoo.Animals)
    {
        if (animal is ("Дарья", _, _, _, _))
        {
            
        }
    }
    
    Console.WriteLine("============================================");
    foreach (var animal in zoo.Animals)
    {

        var desc = GetFullDescriptionByAge(animal);
        Console.WriteLine(desc);
    }
}

string GetName(Animal animal) => (animal.Name, animal.Description) switch
{
    ("Дарья", "Спортивная") => "Лююое животное с Name: Дарья и Description: Спортивная",
    ("Дарья", _) => "Люое животное с Name: Дарья",
    (_, "Спортивная") => "Люое животное с Description: Спортивная",
    _ => "Если ни один паттерн не подошел",
};


string GetName2(Animal animal) => animal switch
{
    ("Дарья", "Парнокопытные", _, _, _) => "Любая парнокопытная Дарья",
    (_, _, _, _, true) => "Любое опасное животное",
    (_, _, "Забра", _, _) => "Любая зебра",
    _ => "Ни один паттерн не подошел",
};

string GetName3(Animal animal) => animal.Name switch
{
    "Дарья" when animal.Description is "Спортивная" => "Люая спортивная Дарья",
    "Дарья" => "Любая Дарья",
    "Петя" => "Люой Петя",
    "Ян" => "Люой Ян",
    _ => "Не подходит ничего",
};

bool IsAdult(Animal animal) => animal.Age switch
{
    < 18 => false,
    _ => true
};

string GetFullDescriptionByAge(Animal animal)
{
    string ageDesc = animal.Age switch
    {
        <= 3 => "Животному меньше либо рано 3 года",
        > 5 and < 10 => "Животному больше 5, но меньше 10 лет",
        > 12 => "Животному больше 12 лет",
        _ => "Не подошел ни один паттерн",
    };

    return $"{animal}: {ageDesc}";
}

void ListPattern()
{
    var numbers = new int[] { 12, 34, 45, 22, 11, 85, 35, 62, 91, 12, 57, 30, 16};

    if (numbers is [1, 2, 3])
    {
        
    }
}

string GetNumberDescription(int[] numbers) => numbers switch
{
    [12, 34, 23] => "Список из чисел: 12, 34, 23",
    [45, 22, 91, 16] => "Список из чисел: 45, 22, 91, 16",
    [35] => "Список 35",
    [] => "Пустой список",
    _ => "Ни один паттерн не подошел",
};
#endregion


