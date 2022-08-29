using Satyre.Basic;

namespace Satyre;

public interface IEntryPoint : IDisposable
{
}

internal class EntryPoint : BasicDisposable, IEntryPoint
{
}