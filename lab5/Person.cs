using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demographic
{
    public class Person
    {
        const double birthProbability = 0.151;
        const int minBirthAge = 18;
        const int maxBirthAge = 45;

        public Person(int age, int gender)
        {
            if (age < 0) throw new Exception("Wrong value of person's age");
            if (gender < (int)GenderStatus.MALE || gender > (int)GenderStatus.FEMALE) 
                throw new Exception("Wrong value of person's gender");
            Age = age;
            Gender = gender;
            LifeStatus = (int)StatusOfLife.ALIVE;
        }

        /// <summary>
        /// Geta and sets age of person.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets and sets gender of person.
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Gets and sets status of life of person.
        /// </summary>
        public int LifeStatus { get; set; }

        /// <summary>
        /// Gets and sets person's probability of death.
        /// </summary>
        public double ProbabilityOfDeath { get; set; }

        public enum GenderStatus
        {
            MALE = 1,
            FEMALE = 2
        };

        public enum StatusOfLife
        {
            ALIVE = 1,
            DEAD = 2
        };

        /// <summary>
        /// Nitifies enfine about child's birth.
        /// </summary>
        public event EventHandler<EventArgs> ChildBirth;

        /// <summary>
        /// Updates an object of Person: checks, if person was dead 
        /// and, if person has female gender, checks was child born or not, calls ChildBirth event, if child was born.
        /// </summary>
        /// <param name="sender">An object, that send YearTick event.</param>
        /// <param name="args">Arguments of YearTick event.</param>
        public void UpdatePerson(object sender, EventArgs args)
        {
            if (Probability.IsEventHappened(ProbabilityOfDeath))
                LifeStatus = (int)StatusOfLife.DEAD;
            else
            {
                if (Gender == (int)GenderStatus.FEMALE && Age >= minBirthAge && Age <= maxBirthAge)
                    if (Probability.IsEventHappened(birthProbability))
                        ChildBirth?.Invoke(this, args);
                Age++;
            }
        }
    }
}
