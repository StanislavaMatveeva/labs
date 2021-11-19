using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileOperations;
using System.IO;
using System.Threading;

namespace Demographic 
{
    public class Engine : IEngine
    {
        List<Person> PeopleCollection;
        const int firstYear = 1970;
        const int lastYear = 2021;
        const double boyProbabilityOfBirth = 0.45;
        const double boyProbabilityOfDeath = 0.0167;
        const double girlProbabilityOfDeath = 0.0199;
        public const int allPopulationAmountIndex = 0;
        public const int menAmountIndex = 1;
        public const int womenAmountIndex = 2;
        public const int birthsAmountIndex = 3;
        public const int deathsAmountIndex = 4;
        public const int amountOfCategories = 4;

        public List<Person> Collection
        {
            get { return PeopleCollection; }
            set { PeopleCollection = value; }
        }

        public Engine (List<Person> newCollection)
        {
            Collection = newCollection;
            FirstYear = firstYear;
            CurrentYear = firstYear; 
            LastYear = lastYear;
        }

        public int FirstYear { get; set; }

        public int CurrentYear { get; set; }

        public int LastYear { get; set; }

        public double MenAmount { get; set; }

        public double WomenAmount { get; set; }

        public double PopulationAmount { get; set; }

        public int Births { get; set; }

        public int Deaths { get; set; }

        public event EventHandler<EventArgs> YearTick;

        public Engine CreateCollectionFromInitialAgeFile(Engine engine, IInitialAgesFiler initialAge)
        {
            if (engine == null)
                throw new Exception("This engine is empty");
            var data = initialAge.GetDataFromFile();
            var ages = initialAge.GetAgesFromInitialAgeFile(data);
            var amount = initialAge.GetAmount(data);
            int j = 0;
            int k = 0;
            for (int i = 0; i < ages.Length; i++)
            {
                k = 0;
                amount[i] *= engine.PopulationAmount / 20000;
                while (k < amount[i])
                {
                    engine.Collection.Add(new Person(ages[i], (int)Person.GenderStatus.MALE));
                    engine.YearTick += engine.Collection[i + j].UpdatePerson;
                    engine.Collection.Add(new Person(ages[i], (int)Person.GenderStatus.FEMALE));
                    engine.YearTick += engine.Collection[i + j + 1].UpdatePerson;
                    engine.Collection[i + j + 1].ChildBirth += engine.ChildWasBorn;
                    k++;
                    j += 2;
                }
                j -= 1;
            }
            return engine;
        }

        public Engine CreateMainCollection(Engine engine, IInitialAgesFiler initialAge, IDeathRulesFiler deathRules)
        {
            if (engine == null) throw new Exception("This collection is empty");
            if (initialAge.FileName == null) throw new Exception("Empty name of file with initial ages");
            if (deathRules.FileName == null) throw new Exception("Empty name of file with death rules");
            engine = CreateCollectionFromInitialAgeFile(engine, initialAge);
            engine = GetDeathProbabilities(engine, deathRules);
            return engine;
        }

        public void ChildWasBorn(object sender, EventArgs args)
        {
            if (Probability.IsEventHappened(boyProbabilityOfBirth))
                Collection.Add(new Person(0, (int)Person.GenderStatus.MALE)
                { ProbabilityOfDeath = boyProbabilityOfDeath });
            else
                Collection.Add(new Person(0, (int)Person.GenderStatus.FEMALE)
                { ProbabilityOfDeath = girlProbabilityOfDeath });
            Births++;
        }

        public Engine GetDeathProbabilities(Engine engine, IDeathRulesFiler deathRules)
        {
            if (engine == null) throw new Exception("This engine is empty");
            if (engine.Collection == null) throw new Exception("This collection is empty");
            if (deathRules.FileName == null) throw new Exception("Empty name of file with death rules");
            var data = deathRules.GetDataFromFile();
            var probMenArray = deathRules.GetDeathProbabilityForMen(data);
            var probWomenArray = deathRules.GetDeathProbabilityForWomen(data);
            var deathAges = deathRules.GetAgesFromDeathRulesFile(data);
            engine.Collection = engine.Collection.OrderBy(p => p.Age).ToList();
            int i = 0;
            foreach (var person in engine.Collection)
            {
                var tmp = engine.Collection.Where(p => p.Age <= deathAges[i][1]
                && p.Age >= deathAges[i][0]);
                foreach (var p in tmp)
                {
                    if (p.Gender == (int)Person.GenderStatus.MALE)
                        p.ProbabilityOfDeath = probMenArray[i];
                    else
                        p.ProbabilityOfDeath = probWomenArray[i];
                }
                i++;
                if (i == deathAges.Length)
                    break;
            }
            engine.Collection = engine.Collection.OrderBy(p => p.Gender).ToList();
            return engine;
        }

        public Engine UpdateCollection(Engine engine)
        {
            if (engine == null) throw new Exception("This engine is empty");
            if (engine.Collection == null) throw new Exception("This collection is empty");
            int i = 1;
            engine.Collection = engine.Collection.OrderBy(p => p.Age).OrderBy(p => p.Gender).ToList();
            foreach (var person in engine.Collection)
            {
                if (person.LifeStatus == (int)Person.StatusOfLife.DEAD)
                {
                    engine.YearTick -= person.UpdatePerson;
                    if (person.Gender == (int)Person.GenderStatus.FEMALE)
                        person.ChildBirth -= engine.ChildWasBorn;
                    engine.Deaths++;
                }
                else if (person.Age == 0)
                {
                    engine.YearTick += person.UpdatePerson;
                    if (person.Gender == (int)Person.GenderStatus.FEMALE)
                        person.ChildBirth += engine.ChildWasBorn;
                }
                i++;
            }
            engine.Collection = engine.Collection.Where(p => p.LifeStatus == (int)Person.StatusOfLife.ALIVE).ToList();
            return engine;
        }

        public double GetPopulationAmount(List<Person> collection)
        {
            if (collection == null) throw new Exception("This collection is empty");
            return collection.Count() * 10;
        }

        public int GetMenPopulationAmount(List<Person> collection)
        {
            if (collection == null) throw new Exception("This collection is empty");
            return collection.Count(p => p.Gender == (int)Person.GenderStatus.MALE) * 10;
        }

        public int GetWomenPopulationAmount(List<Person> collection)
        {
            if (collection == null) throw new Exception("This collection is empty");
            return collection.Count(p => p.Gender == (int)Person.GenderStatus.FEMALE) * 10;
        }

        public Engine NewYearCame(Engine engine, IDeathRulesFiler deathRules)
        {
            if (engine == null) throw new Exception("This engine is empty");
            if (engine.Collection == null) throw new Exception("This collection is empty");
            var args = new EventArgs();
            engine.CurrentYear++;
            engine.Births = 0;
            engine.Deaths = 0;
            engine.YearTick?.Invoke(this, args);
            engine = UpdateCollection(engine);
            engine = GetDeathProbabilities(engine, deathRules);
            engine.MenAmount = GetMenPopulationAmount(engine.Collection);
            engine.WomenAmount = GetWomenPopulationAmount(engine.Collection);
            engine.PopulationAmount = engine.MenAmount + engine.WomenAmount;
            return engine;
        }

        public double[][] GetCollection(ref IEngine engine, IInitialAgesFiler initialAge, IDeathRulesFiler deathRules)
        {
            if (engine == null) throw new Exception("This engine is empty");
            if (engine.FirstYear == 0 || engine.LastYear == 0 || engine.CurrentYear == 0 || engine.PopulationAmount == 0) 
                throw new Exception("Incorrect start data in engine");
            if (initialAge.FileName == null) throw new Exception("Empty name of file with initial ages");
            if (deathRules.FileName == null) throw new Exception("Empty name of file with death rules");
            engine = CreateMainCollection((Engine)engine, initialAge, deathRules);
            engine.MenAmount = engine.PopulationAmount / 2;
            engine.WomenAmount = engine.PopulationAmount / 2;
            var population = new double[engine.LastYear - engine.FirstYear + 1][];
            int i = 0;
            if (engine.CurrentYear != firstYear)
            {
                var k = firstYear;
                var startYear = engine.CurrentYear;
                engine.CurrentYear = firstYear;
                while (k < startYear)
                {
                    engine = NewYearCame((Engine)engine, deathRules);
                    k++;
                }
            }
            while (i < population.Length)
            {
                population[i] = new double[5];
                population[i][allPopulationAmountIndex] = Math.Round(engine.PopulationAmount, 0);
                population[i][menAmountIndex] = Math.Round(engine.MenAmount, 0);
                population[i][womenAmountIndex] = Math.Round(engine.WomenAmount, 0);
                population[i][birthsAmountIndex] = engine.Births;
                population[i][deathsAmountIndex] = engine.Deaths;
                engine = NewYearCame((Engine)engine, deathRules);
                i++;
            }
            return population;
        }

        public double GetMenAmountByCategories(List<Person> collection, int firstAge, int secondAge)
        {
            if (collection == null) throw new Exception("This collection is empty");
            if (firstAge < 0 || secondAge <= 0 || secondAge < firstAge) throw new Exception("Wrong value of years");
            return collection.Count(p => p.Gender == (int)Person.GenderStatus.MALE && p.Age >= firstAge
            && p.Age <= secondAge) * 10;
        }

        public double GetWomenAmountByCategories(List<Person> collection, int firstAge, int secondAge)
        {
            if (collection == null) throw new Exception("This collection is empty");
            if (firstAge < 0 || secondAge <= 0 || secondAge < firstAge) throw new Exception("Wrong value of years");
            return collection.Count(p => p.Gender == (int)Person.GenderStatus.FEMALE && p.Age >= firstAge
            && p.Age <= secondAge) * 10;
        }

        public double[][] GetPopulationAmountByCategories(List<Person> collection, int[,] categories)
        {
            if (collection == null) throw new Exception("This collection is empty");
            if (categories == null) throw new Exception("Array of ages categories is empty");
            var population = new double[amountOfCategories][];
            for (int i = 0; i < amountOfCategories; i++)
            {
                population[i] = new double[2];
                population[i][0] = GetMenAmountByCategories(collection, categories[i,0], categories[i,1]);
                population[i][1] = GetWomenAmountByCategories(collection, categories[i, 0], categories[i, 1]);
            }
            return population;
        }
    }
}
