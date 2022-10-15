namespace Candidates.Application.Commands.Base
{
    public abstract class DeleteCommand
    {
        public int Id { get; set; }

        public DeleteCommand(int id)
        {
            Id = id;
        }       
    }
}
