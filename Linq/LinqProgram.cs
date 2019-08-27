using System;
using System.Linq;

namespace Linq {
    public class LinqProgram {
        public static void QueryStringArray() {
            new string[] {"K 9", "Brian Griffin",
            "Scooby Doo", "Old Yeller", "Rin Tin Tin",
            "Benji", "Charlie B. Barkin", "Lassie",
            "Snoopy"}
                .Where(x => x.Contains(" "))
                .OrderByDescending(x => x)
                .ForEach(x => Console.WriteLine(x));
        }

        public static void QueryIntArray() {
            new int []{ 5, 10, 15, 20, 25, 30, 35 }
                .Where(x => x > 20)
                .OrderBy(x => x)
                .ForEach(Console.WriteLine);
        }

        public static void QueryAnimalData() {
            Animal[] animals = {
                new Animal{Name = "German Shepherd", Height = 25, Weight = 77, AnimalID = 1},
                new Animal{Name = "Chihuahua", Height = 7, Weight = 4.4, AnimalID = 2},
                new Animal{Name = "Saint Bernard", Height = 30, Weight = 200, AnimalID = 3},
                new Animal{Name = "Pug", Height = 12, Weight = 16, AnimalID = 1},
                new Animal{Name = "Beagle", Height = 15, Weight = 23, AnimalID = 2}
            };

            Owner[] owners = {
                new Owner{Name = "Doug Parks", OwnerID = 1},
                new Owner{Name = "Sally Smith", OwnerID = 2},
                new Owner{Name = "Paul Brooks", OwnerID = 3}
            };

            animals.OfType<Animal>()
                .Where(x => x.Weight <= 90)
                .OrderBy(x => x.Name)
                .ForEach(x => Console.WriteLine("{0} weighs {1}lbs", x.Name, x.Weight));

            animals
                .Where(x => x.Weight > 90 && x.Height > 25)
                .OrderBy(x => x.Name)
                .ForEach(x => Console.WriteLine("A {0} weighs {1}lbs", x.Name, x.Weight));

            animals
                .Select(a => new { a.Name, a.Height })
                .ToArray()
                .ForEach(Console.WriteLine);

            animals.Join(
                owners,
                animal => animal.AnimalID,
                owner => owner.OwnerID,
                (animal, owner) => new { OwnerName = owner.Name, AnimalName = animal.Name })
                .ForEach(x => Console.WriteLine("{0} owns {1}", x.OwnerName, x.AnimalName));


            // Create a group inner join
            // Get all animals and put them in a
            // newly created owner group if their
            // IDs match the owners ID 
            var groupJoin =
                from owner in owners
                orderby owner.OwnerID
                join animal in animals on owner.OwnerID
                equals animal.AnimalID into ownerGroup
                select new {
                    Owner = owner.Name,
                    Animals = from owner2 in ownerGroup
                              orderby owner2.Name
                              select owner2
                };

            int totalAnimals = 0;

            foreach (var ownerGroup in groupJoin) {
                Console.WriteLine(ownerGroup.Owner);
                foreach (var animal in ownerGroup.Animals) {
                    totalAnimals++;
                    Console.WriteLine("* {0}", animal.Name);
                }
            }
        }
    }
}

