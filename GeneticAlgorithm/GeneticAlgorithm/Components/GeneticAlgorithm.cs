using GeneticAlgorithm.Interfaces;

namespace GeneticAlgorithm.Components
{
    public class GeneticAlgorithm<ChromosomeType>
    {
        #region Fields

        private Population<ChromosomeType> _currentPopulation = new Population<ChromosomeType>();
        private Population<ChromosomeType> _futurePopulation = new Population<ChromosomeType>();

        #endregion

        #region Properties

        public int? Size { get; set; }
        public double? CrossRate { get; set; }
        public double? MutationRate { get; set; }
        public ICrosser<ChromosomeType> Crosser { get; set; }
        public IElitism<ChromosomeType> Elitism { get; set; }
        public IFactory<ChromosomeType> Factory { get; set; }
        public IFitnessCalculator<ChromosomeType> _FitnessCalculator;
        public IFitnessCalculator<ChromosomeType> FitnessCalculator
        {
            get { return _FitnessCalculator; }
            set { _FitnessCalculator = value; _currentPopulation.FitnessCalculator = value; }
        }
        public IMutator<ChromosomeType> Mutator { get; set; }
        public ISelector<ChromosomeType> Selector { get; set; }

        #endregion

        #region Methods

        public void Build()
        {
            _currentPopulation.Anihilate();
            _futurePopulation.Anihilate();

            for (int i = 0; i < Size.Value; i++)
            {
                _currentPopulation.Introduce(Factory.CreateChromosome());
            }
        }
        public ChromosomeType Run()
        {
            _futurePopulation.Introduce(Elitism.GetElite(_currentPopulation));

            while (_futurePopulation.Size < _currentPopulation.Size)
            {
                var chromosome1 = Selector.Select(_currentPopulation);
                var chromosome2 = Selector.Select(_currentPopulation);

                Crosser.Cross(chromosome1, chromosome2, CrossRate.Value);

                Mutator.Mutate(chromosome1, MutationRate.Value);
                Mutator.Mutate(chromosome2, MutationRate.Value);

                _futurePopulation.Introduce(chromosome1);
                _futurePopulation.Introduce(chromosome2);
            }

            while (_futurePopulation.Size > _currentPopulation.Size)
            {
                _futurePopulation.KillWeakest();
            }

            _currentPopulation.ReplaceWith(_futurePopulation);
            _futurePopulation.Anihilate();

            return _currentPopulation.GetElite();
        }

        #endregion
    }
}