using AutoMapper;
namespace Checkout.Application.Common.Mappings
{
    /// <summary>
    /// Map from interface
    /// </summary>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Mapping.
        /// </summary>
        /// <param name="profile">Automapper profile.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
