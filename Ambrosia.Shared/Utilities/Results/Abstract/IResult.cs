using Ambrosia.Shared.Utilities.Results.ComplexTypes;

namespace Ambrosia.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
