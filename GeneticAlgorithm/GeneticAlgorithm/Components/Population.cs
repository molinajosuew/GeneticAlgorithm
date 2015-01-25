using GeneticAlgorithm.Interfaces;
using System;
using System.Collections.Generic;

namespace GeneticAlgorithm.Components
{
    public class Population<ChromosomeType>
    {
        #region Fields

        private bool _isSorted = false;
        private List<ChromosomeType> _pool = new List<ChromosomeType>();

        #endregion

        #region Properties

        public ChromosomeType this[int index]
        {
            get { return _pool[index]; }
            set { _pool[index] = value; }
        }
        public IFitnessCalculator<ChromosomeType> FitnessCalculator { get; set; }
        public int Size
        {
            get { return _pool.Count; }
        }

        #endregion

        #region Methods

        public void Introduce(params ChromosomeType[] chromosomes)
        {
            foreach (var chromosome in chromosomes)
            {
                _pool.Add(chromosome);
            }

            _isSorted = false;
        }
        public void Anihilate()
        {
            _pool.Clear();
            _isSorted = false;
        }
        public ChromosomeType GetElite()
        {
            Sort();
            return _pool[_pool.Count - 1];
        }
        public void ReplaceWith(Population<ChromosomeType> population)
        {
            for (int i = 0; i < population.Size; i++)
            {
                _pool[i] = population[i];
            }

            _isSorted = false;
        }
        public void KillWeakest()
        {
            _pool.RemoveAt(0);
        }
        public void Sort()
        {
            if (_isSorted)
            {
                return;
            }

            if (FitnessCalculator == null)
            {
                throw new Exception("The population has no fitness calculator.");
            }

            _pool.Sort(delegate(ChromosomeType a, ChromosomeType b)
            {
                return FitnessCalculator.Fitness(a).CompareTo(FitnessCalculator.Fitness(b));
            });

            _isSorted = true;
        }

        #endregion
    }
}