using ManageNote.Domain.Enum;

namespace ManageNote.Domain.Response
{
    public interface IBaseResponse<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        T Data { get; }
    }
}
