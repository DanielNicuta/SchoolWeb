using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class ContactMapper : IMapper<ContactPageResponseDto, ContactPageUpdateDto>
{
    public ContactPageUpdateDto Map(ContactPageResponseDto src) => new()
    {
        Title = src.Title,
        Subtitle = src.Subtitle,

        Address = src.Address,
        Phone = src.Phone,
        Email = src.Email,

        MapEmbedUrl = src.MapEmbedUrl,
        InfoHtml = src.InfoHtml,

        SeoTitle = src.SeoTitle,
        SeoDescription = src.SeoDescription,
        OgImageUrl = src.OgImageUrl
    };
}