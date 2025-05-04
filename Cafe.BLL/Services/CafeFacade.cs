using Cafe.BLL.Services;
using Cafe.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cafe.BLL.Facades
{
    public class CafeFacade
    {
        private readonly ReservationService _reservationService;
        private readonly RoomService _roomService;
        private readonly UserService _userService;

        public CafeFacade(ReservationService reservationService, RoomService roomService, UserService userService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
            _userService = userService;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _roomService.GetAllRoomsAsync();
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime date)
        {
            return await _roomService.GetAvailableRoomsAsync(date);
        }

        public async Task CreateReservationAsync(
            string customerName,
            DateTime date,
            bool isEventPackage,
            string? additionalDetails,
            List<(int RoomId, int ActivityId)> rooms)
        {
            await _reservationService.CreateReservationAsync(customerName, date, isEventPackage, additionalDetails, rooms);
        }

        public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(string customerName)
        {
            return await _reservationService.GetUserReservationsAsync(customerName);
        }

        public async Task<List<DateTime>> GetBookedDatesAsync()
        {
            return await _reservationService.GetBookedDatesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            await _reservationService.DeleteReservationAsync(reservationId);
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _userService.LoginAsync(username, password);
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            return await _userService.RegisterAsync(username, password);
        }
    }
}