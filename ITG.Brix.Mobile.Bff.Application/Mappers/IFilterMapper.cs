using ITG.Brix.Mobile.Bff.Application.Models.Local;

namespace ITG.Brix.Mobile.Bff.Application.Mappers
{
    public interface IFilterMapper
    {
        string ToEscaped(NarrowerModel narrowerModel, string operant);
    }
}
