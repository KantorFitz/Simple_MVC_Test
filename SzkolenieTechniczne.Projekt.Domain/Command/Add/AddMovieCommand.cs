namespace SzkolenieTechniczne.Projekt.Domain.Command.Add
{
    public sealed class AddMovieCommand : ICommand
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int SeanceTime { get; set; }
    }
}