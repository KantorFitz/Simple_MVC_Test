namespace SzkolenieTechniczne.Projekt.Domain.Command.Delete
{
    public sealed class DeleteMovieCommand : ICommand
    {
        public Guid Id { get; set; }
        
        public DeleteMovieCommand(Guid guid)
        {
            Id = guid;
        }
    }
}