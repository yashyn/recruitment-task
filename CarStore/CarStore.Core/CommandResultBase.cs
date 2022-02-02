namespace CarStore.Core
{
    public class CommandResultBase
    {
        public CommandResultBase(CommandResultType type = CommandResultType.Success)
        {
            Type = type;
        }

        public CommandResultType Type { get; }
    }

    public class CommandResultBase<TData> : CommandResultBase
    {
        public CommandResultBase(TData data,
            CommandResultType type = CommandResultType.Success) : base(type)
        {
            Data = data;
        }

        public TData Data { get; }
    }
}
