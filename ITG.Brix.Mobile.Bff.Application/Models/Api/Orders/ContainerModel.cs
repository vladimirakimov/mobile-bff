namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class ContainerModel
    {
        public string Number { get; set; }
        public string Location { get; set; }
        public string StackLocation { get; set; }

        public FreeUntilOnTerminalModel FreeUntilOnTerminal { get; set; }
    }
}
