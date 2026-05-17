using Abc.Data;
using Common;
using Gym.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Infra
{
    public interface IRepo<T> where T : BaseEntity
    {
        Task<T?> GetAsync(Guid id);
        Task<int> CountAsync(Query q);
        Task<IEnumerable<T>> GetAsync(Query q);
        Task<T> CreateAsync(T e);
        Task<T> UpdateAsync(T e);
        Task DeleteAsync(Guid id);
    }
    public interface IPersonsRepo : IRepo<Person> { }
    public interface IGymMembersRepo : IRepo<GymMember> { }
    public interface ITrainersRepo : IRepo<Trainer> { }
    public interface IMembershipsRepo : IRepo<Membership> { }
    public interface IVisitsRepo : IRepo<Visit> { }
    public interface ILocationsRepo : IRepo<Location> { }
    public interface IRoomsRepo : IRepo<Room> { }
    public interface ILocationRoomsRepo : IRepo<LocationRooms> { }
    public interface IBookingsRepo : IRepo<Booking> { }
    public interface IRoomBookingsRepo : IRepo<RoomBookings> { }

}
