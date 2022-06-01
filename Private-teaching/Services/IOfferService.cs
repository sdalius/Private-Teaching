using Private_teaching.Models.Entities;

namespace Private_teaching.Services
{
    public interface IOfferService
    {
        Task<List<Offers>> GetAllPostedOffers();
        Task<int> PostAnOffer(Offers model);
    }
}
