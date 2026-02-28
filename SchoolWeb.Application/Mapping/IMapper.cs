namespace SchoolWeb.Application.Mapping;

public interface IMapper<in TSource, out TDestination>
{
    TDestination Map(TSource source);
}