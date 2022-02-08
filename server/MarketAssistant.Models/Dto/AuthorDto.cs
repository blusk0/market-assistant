using MarketAssistant.Models.Data;

namespace MarketAssistant.Models.Dto
{
    public class AuthorDto : IDto<Author, AuthorDto>
    {
        public AuthorDto()
        {
            FirstName = "";
            LastName = "";
            Books = new List<BookDto>();
            ImageUrl = "";
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<BookDto> Books { get; set; }

        public AuthorDto Adapt(Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = new BookDto().AdaptMany(author.Books)
            };
        }

        public AuthorDto Adapt(Author author, string hostUrl)
        {
            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = new BookDto().AdaptMany(author.Books, hostUrl),
                ImageUrl = $"https://{hostUrl}/images/authors/{author.Id}.jpeg"
            };
        }

        public IEnumerable<AuthorDto> AdaptMany(IEnumerable<Author> authors)
        {
            return authors.Select(Adapt).ToList();
        }

        public IEnumerable<AuthorDto> AdaptMany(IEnumerable<Author> authors, string hostUrl)
        {
            return authors.Select(author => Adapt(author, hostUrl)).ToList();
        }
    }
}
