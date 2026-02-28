using SchoolWeb.Application.Contracts.Pages;

namespace SchoolWeb.Application.Mapping;

public sealed class FooterMapper : IMapper<FooterContentResponseDto, FooterContentUpdateDto>
{
    public FooterContentUpdateDto Map(FooterContentResponseDto src) => new()
    {
        FooterText = src.FooterText,
        UsefulLinksJson = src.UsefulLinksJson,
        SocialLinksJson = src.SocialLinksJson,
        NewsletterTitle = src.NewsletterTitle,
        NewsletterText = src.NewsletterText
    };
}