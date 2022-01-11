using TravelExperience.MVC.ViewModels;

namespace TravelExperience.MVC.Controllers.HelperClasses
{
    public class ErrorHandler
    {
        /// <summary>
        /// Object to store error messages for Accommodations
        /// </summary>
        public class AccommodationErrorMSG
        {
            public string City { get; set; }
            public string Address { get; set; }
            public string Country { get; set; }
            public string NumberOfGuests { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
        }
        /// <summary>
        /// Validates the information given. If something is wrong it returns a string with what is needed
        /// </summary>
        public void ValidateNewAccommodationsInput(AccommodationFormViewModel viewModel)
        {
            if (viewModel.Accommodation.AvailableFromDate == System.DateTime.MinValue ||
                viewModel.Accommodation.AvailableFromDate < System.DateTime.Today)
                viewModel.ErrorMsgForFields.StartDate = "Valid start date is required";
            if (viewModel.Accommodation.AvailableToDate == System.DateTime.MinValue ||
                viewModel.Accommodation.AvailableToDate <= System.DateTime.Today)
                viewModel.ErrorMsgForFields.EndDate = "Valid end date is required";
            if (viewModel.Accommodation.Title == null)
                viewModel.ErrorMsgForFields.Title = "Title is required";
            if (viewModel.Accommodation.Description == null)
                viewModel.ErrorMsgForFields.Description = "Description is required";
            if (viewModel.Accommodation.PricePerNight <= 0)
            {
                viewModel.ErrorMsgForFields.Price = "Price per night Required";
                viewModel.ErrorMessageTop.Add(viewModel.ErrorMsgForFields.Price);
            }
            if (viewModel.Accommodation.MaxCapacity <= 0)
            {
                viewModel.ErrorMsgForFields.NumberOfGuests = "Number of guests 1 or more required";
                viewModel.ErrorMessageTop.Add(viewModel.ErrorMsgForFields.NumberOfGuests);
            }
            if (viewModel.Accommodation.Location == null)
            {
                if (viewModel.Accommodation.Location.City == null)
                    viewModel.ErrorMsgForFields.City = "City is required";
                if (viewModel.Accommodation.Location.Address == null)
                    viewModel.ErrorMsgForFields.Address = "Address is required";
                if (viewModel.Accommodation.Location.Country == null)
                    viewModel.ErrorMsgForFields.Country = "Country is required";
            }
            if (viewModel.ErrorMsgForFields.Address != null || viewModel.ErrorMsgForFields.City != null || viewModel.ErrorMsgForFields.Country != null)
                viewModel.ErrorMessageTop.Add("Address, city and country are required");
            if (viewModel.ErrorMsgForFields.Description != null || viewModel.ErrorMsgForFields.Title != null)
                viewModel.ErrorMessageTop.Add("Title and description are required");
            if (viewModel.ErrorMsgForFields.StartDate != null | viewModel.ErrorMsgForFields.EndDate != null)
                viewModel.ErrorMessageTop.Add("Valid start and end date are required");
        }
    }
 
}