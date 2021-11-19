using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileOperations;

namespace Demographic
{
    public interface IEngine
    {
        /// <summary>
        /// Gets and sets List of objects of class Person.
        /// </summary>
        List<Person> Collection { get; set; }

        /// <summary>
        /// Notifies every object of class Person from collection, that are subscribed on it, that new year has come.
        /// </summary>
        event EventHandler<EventArgs> YearTick;

        /// <summary>
        /// Gets and sets the first year of modeling.
        /// </summary>
        int FirstYear { get; set; }

        /// <summary>
        /// Gets and sets the current year of modeling.
        /// </summary>
        int CurrentYear { get; set; }

        /// <summary>
        /// Gets and sets the last year of modeling.
        /// </summary>
        int LastYear { get; set; }

        /// <summary>
        /// Gets and sets amount of men's population.
        /// </summary>
        double MenAmount { get; set; }

        /// <summary>
        /// Gets and sets amount of women's population.
        /// </summary>
        double WomenAmount { get; set; }

        /// <summary>
        /// Gets and sets amount of all popultion.
        /// </summary>
        double PopulationAmount { get; set; }

        /// <summary>
        /// Gets and sets amount of births int all population.
        /// </summary>
        int Births { get; set; }

        /// <summary>
        /// Gets and seta amount of deaths in all population.
        /// </summary>
        int Deaths { get; set; }

        /// <summary>
        /// Creates collection with data from file with start ages.
        /// </summary>
        /// <param name="engine">Collection, in which data should be written.</param>
        /// <param name="initialAge">An object of IInitialAgesFiler, that contains name of file with start ages and amount.</param>
        /// <returns>Collection of people with written data.</returns>
        Engine CreateCollectionFromInitialAgeFile(Engine engine, IInitialAgesFiler initialAge);

        /// <summary>
        /// Writes probabilities of death for which element of collection.
        /// </summary>
        /// <param name="engine">Collection, in which probabilities should be written.</param>
        /// <param name="deathRules">An object of IDeathRulesFiler, that contains name of file with death probabilties
        /// for people of different ages and genders.</param>
        /// <returns>Collection of people with written data.</returns>
        Engine GetDeathProbabilities(Engine engine, IDeathRulesFiler deathRules);

        /// <summary>
        /// Creates start collection from files with start ages and probabilities of deaths.
        /// </summary>
        /// <param name="engine">Collection in wich data should be written.</param>
        /// <param name="initialAge">An object of IInitialAgesFiler, that contains name of file with start ages and amount.</param>
        /// <param name="deathRules">An object of IDeathRulesFiler, that contains name of file with death probabilties
        /// for people of different ages and genders.</param>
        /// <returns>Collection of people with written data.</returns>
        Engine CreateMainCollection(Engine engine, IInitialAgesFiler initialAge, IDeathRulesFiler deathRules);

        /// <summary>
        /// Creates an array, that contains amount of births, deaths, men's, women's and all population.
        /// </summary>
        /// <param name="engine">Start collection.</param>
        /// <param name="initialAge">An object of IInitialAgesFiler, that contains name of file with start ages and amount.</param>
        /// <param name="deathRules">An object of IDeathRulesFiler, that contains name of file with death probabilties
        /// for people of different ages and genders.</param>
        /// <returns>Array, that contains ages of people and their probabilities of death 
        /// for people of different ages and genders.</returns>
        double[][] GetCollection(ref IEngine engine, IInitialAgesFiler initialAge, IDeathRulesFiler deathRules);

        /// <summary>
        /// Checks who was born: boy or girl, if ChildBirthEvent was called.
        /// </summary>
        /// <param name="sender">An object, that called ChildBirth event.</param>
        /// <param name="args">Arguments of event.</param>
        void ChildWasBorn(object sender, EventArgs args);

        /// <summary>
        /// Updates collection: subscribes person on YearTick event, if he was born, 
        /// subsribes engine on woman's ChildBirth event, if she turned 18 years old, 
        /// unsubscribes person from YearTick event, if he was dead,
        /// unsubscribes engine from woman's ChildBirth event, if she turned 46 years old.
        /// </summary>
        /// <param name="engine">Collection.</param>
        /// <returns>Updated collection of people.</returns>
        Engine UpdateCollection(Engine engine);

        /// <summary>
        /// Gets amount of all people in collection.
        /// </summary>
        /// <param name="engine">Collection.</param>
        /// <returns>Amount of all people in collection.</returns>
        double GetPopulationAmount(List<Person> engine);

        /// <summary>
        /// Geta amount of men in collection.
        /// </summary>
        /// <param name="engine">Collection.</param>
        /// <returns>Amount of men in collection.</returns>
        int GetMenPopulationAmount(List<Person> engine);

        /// <summary>
        /// Gets amount of women in collection.
        /// </summary>
        /// <param name="engine">Collection.</param>
        /// <returns>Amount of women in collection.</returns>
        int GetWomenPopulationAmount(List<Person> engine);

        /// <summary>
        /// Updates collection, when new year has come: calles YearTick event,
        /// updating collection, changing probabilities of death.
        /// </summary>
        /// <param name="engine">Collection.</param>
        /// <param name="deathRules">An object of IDeathRulesFiler, that contains name of file with death probabilties
        /// for people of different ages and genders.</param>
        /// <returns>Updated collection of people.</returns>
        Engine NewYearCame(Engine engine, IDeathRulesFiler deathRules);

        /// <summary>
        /// Gets men's amount of stated age category.
        /// </summary>
        /// <param name="collection">Collection of people.</param>
        /// <param name="firstAge">The first age of category.</param>
        /// <param name="secondAge">The last age of category.</param>
        /// <returns>Amount of men of stated age category.</returns>
        double GetMenAmountByCategories(List<Person> collection, int firstAge, int secondAge);

        /// <summary>
        /// Gets women's amount of stated age category.
        /// </summary>
        /// <param name="collection">Collection of people.</param>
        /// <param name="firstAge">The first age of category.</param>
        /// <param name="secondAge">The last age of category.</param>
        /// <returns>Amount of women of stated age category.</returns>
        double GetWomenAmountByCategories(List<Person> collection, int firstAge, int secondAge);

        /// <summary>
        /// Gets array with amount of men and women for each age category for end of modeling.
        /// </summary>
        /// <param name="collection">Collection of people.</param>
        /// <param name="categories">Array, that contains border ages of each category.</param>
        /// <returns>Array with amount of men and women for each age category for end of modeling.</returns>
        double[][] GetPopulationAmountByCategories(List<Person> collection, int[,] categories);
    }
}
