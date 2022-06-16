namespace SzkolenieTechniczne.Projekt.Domain.Command.Edit
{
    public sealed class EditMovieCommand : ICommand
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int ScenarioTime { get; set; }
    }
}