

var cities = new List<City>
{
    new City { Id = 1, Name = "Amsterdam" },
    new City { Id = 2, Name = "Berlin" },
    new City { Id = 3, Name = "Cairo" },
    new City { Id = 4, Name = "Athens" },
    new City { Id = 5, Name = "New York" },
    new City { Id = 6, Name = "London" },
};

var people = new List<Person>
{
    new Person { Id = 1, Name = "Alice", Age = 30, CityId = 1 },
    new Person { Id = 2, Name = "Bob", Age = 24, CityId = 2 },
    new Person { Id = 3, Name = "Charlie", Age = 28, CityId = 3 },
    new Person { Id = 4, Name = "Diana", Age = 5, CityId = 4 },
    new Person { Id = 5, Name = "Eve", Age = 35, CityId = 5 },
    new Person { Id = 6, Name = "Frank", Age = 6, CityId = 4 },
    new Person { Id = 7, Name = "Oscar", Age = 3, CityId = 1 },
};


//class task


// // task 1
// var prs = people.Where(person => person.Age >= 25).ToList();

// var prs2 =
// (
//     from p in people
//     where p.Age >= 25
//     select p
// );

// foreach (var person in prs)
// {
//     System.Console.WriteLine($"{person.Id} {person.Name} {person.Age}");
// }


// // Task 2
// var res = people
//     .OrderBy(p => p.Age)
//     .ThenBy(p => p.Name);

// var res2 =
//     from p in people 
//     orderby p.Age, p.Name
//     select p;

// foreach (var p in res2)
// {
//     Console.WriteLine($"{p.Name} {p.Age}");
// }



// // Task 3

// var res = people
//     .GroupBy(p => p.Name[0]);

// var res2 =
//     from p in people
//     group p by p.Name[0] into g
//     select g;

// foreach (var group in res2)
// {
//     Console.WriteLine(group.Key);
//     foreach (var p in group)
//         Console.WriteLine($"  {p.Name}");
// }


// Task 4

// var res = people
//     .Join(cities, p => p.CityId, c => c.Id, (p, c) => new { p.Name, CityName = c.Name });

// var res1 =
//     from p in people
//     join c in cities on p.CityId equals c.Id
//     select new { p.Name, CityName = c.Name };

// foreach (var person in res1)
// {
//     Console.WriteLine($"{person.Name} - {person.CityName}");
// }






// // Task 5
// char[] vowels = { 'A', 'E', 'I', 'O', 'U' };

// var result5 = people
//     .Where(p => vowels.Contains(Char.ToUpper(p.Name[0])))
//     .Sum(p => p.Age);

// var res1 =
//     (
//         from p in people
//         where vowels.Contains(Char.ToUpper(p.Name[0]))
//         select p.Age
//     ).Sum();

// Console.WriteLine(res1);



// // Task 6

// var res = people
//     .GroupBy(p => p.Name[0])
//     .Select(g => new { Letter = g.Key, Count = g.Count() });

// var res1 =
//     from p in people
//     group p by p.Name[0] into g
//     select new { Letter = g.Key, Count = g.Count() };

// foreach (var group in res1)
// {
//     Console.WriteLine($"{group.Letter}: {group.Count}");
// }




// // Task 7

// var res = people
//     .GroupBy(p => p.CityId)
//     .OrderByDescending(g => g.Count())
//     .Select(g => new { CityId = g.Key, Count = g.Count() })
//     .FirstOrDefault();

// var cityName = cities.FirstOrDefault(c => c.Id == res.CityId).Name;
// Console.WriteLine($"{cityName} {res.Count}");


// // Task 8

// var res = people
//     .Where(p => p.Age >= 2 && p.Age <= 7)
//     .Join(cities.Where(c => c.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)),
//           p => p.CityId,
//           c => c.Id,
//           (p, c) => p);

// var res1 =
//     from p in people
//     where p.Age >= 2 && p.Age <= 7
//     join c in cities on p.CityId equals c.Id
//     where c.Name.StartsWith("A")
//     select p;

// foreach (var child in res1)
// {
//     Console.WriteLine($"{child.Name} ({child.Age} y.o.)");
// }



// hoem task 


// // Task 1

// var res = people
//     .Where(p => p.Name.Length > 4)
//     .Select(p => new { p.Name, Length = p.Name.Length });

// var res1 =
//     from p in people
//     where p.Name.Length > 4
//     select new { p.Name, Length = p.Name.Length };

// foreach (var p in res)
// {
//     Console.WriteLine($"{p.Name}");
// }



// Task 2
// var res = people
//     .GroupBy(p => p.CityId)
//     .Select(g => g.OrderBy(p => p.Age).First());

// var res1 =
//     from p in people
//     group p by p.CityId into g
//     select g.OrderBy(p => p.Age).First();

// foreach (var p in res)
// {
//     var cityName = cities.FirstOrDefault(c => c.Id == p.CityId)?.Name;
//     Console.WriteLine($"{p.Name} {p.Age} {cityName}");
// }



// // Task 3

// var res = cities
//     .Select(c => new
//     {
//         City = c.Name,
//         Residents = people.Where(p => p.CityId == c.Id).ToList(),
//         AverageAge = people.Where(p => p.CityId == c.Id).Any()
//                     ? people.Where(p => p.CityId == c.Id).Average(p => p.Age)
//                     : 0
//     });

// var res1 =
//     from c in cities
//     let residents = people.Where(p => p.CityId == c.Id)
//     select new
//     {
//         City = c.Name,
//         Residents = residents.ToList(),
//         AverageAge = residents.Any() ? residents.Average(p => p.Age) : 0
//     };

// foreach (var city in res)
// {
//     Console.WriteLine($"{city.City} {city.AverageAge:F1}");
//     foreach (var p in city.Residents)
//     {
//         Console.WriteLine($"{p.Name} {p.Age}");
//     }
// }



// // Task 4

// var res = people
//     .Join(cities, p => p.CityId, c => c.Id, (p, c) => new { p.Name, c.Name, c.Id })
//     .GroupBy(x => x.Id)
//     .Select(g => new
//     {
//         CityName = g.First().Name,
//         Residents = g.Select(x => x.Name).ToList()
//     });

// var res1 =
//     from p in people
//     join c in cities on p.CityId equals c.Id
//     group p by c into g
//     select new
//     {
//         CityName = g.Key.Name,
//         Residents = g.Select(p => p.Name).ToList()
//     };

// foreach (var group in res)
// {
//     Console.WriteLine(group.CityName);
//     foreach (var name in group.Residents)
//     {
//         Console.WriteLine(name);
//     }
// }



// // Task 5

// var res = people
//     .Join(cities.Where(c => c.Name.StartsWith("N") || c.Name.StartsWith("L")),
//           p => p.CityId,
//           c => c.Id,
//           (p, c) => new { PersonName = p.Name, CityName = c.Name });

// var res1 =
//     from p in people
//     join c in cities on p.CityId equals c.Id
//     where c.Name.StartsWith("N") || c.Name.StartsWith("L")
//     select new { PersonName = p.Name, CityName = c.Name };

// foreach (var item in res)
// {
//     Console.WriteLine($"{item.PersonName} {item.CityName}");
// }



// Task 6









class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public int CityId { get; set; }
}


class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}