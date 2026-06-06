using System;
using System.Web.UI;
using RestoApp.Models;
using RestoApp;

namespace RestoApp.ClientsView.Reservationn
{
    public partial class ReservationRequest : System.Web.UI.Page
    {
        private TableRepository _tableRepo = new TableRepository();
        private ReservationRepository _reservationRepo = new ReservationRepository();
        
        // Property to hold current table capacity for validation
        public int CurrentTableCapacity
        {
            get { return ViewState["CurrentTableCapacity"] != null ? (int)ViewState["CurrentTableCapacity"] : 0; }
            set { ViewState["CurrentTableCapacity"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTableDetails();
            }
        }

        private void LoadTableDetails()
        {
            if (int.TryParse(Request.QueryString["table"], out int tableId))
            {
                RestaurantTable table = _tableRepo.GetTableById(tableId);
                if (table != null)
                {
                    lblTableNumber.Text = "Table " + table.TableNumber;
                    lblTableLocation.Text = string.IsNullOrEmpty(table.Location) ? "Main Dining" : table.Location;
                    lblTableCapacity.Text = table.SeatingCapacity.ToString();
                    imgTable.Src = string.IsNullOrEmpty(table.PhotoPath) ? "https://images.unsplash.com/photo-1550966871-3ed3cdb51f3a?auto=format&fit=crop&w=400&q=80" : table.PhotoPath;
                    
                    CurrentTableCapacity = table.SeatingCapacity;
                    txtNumberOfGuests.Attributes["max"] = table.SeatingCapacity.ToString();

                    // Pre-fill date to today if available
                    txtReservationDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                    txtReservationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtReservationTime.Text = "19:00"; // Default 7 PM
                }
                else
                {
                    ShowError("The selected table could not be found.");
                    pnlForm.Visible = false;
                }
            }
            else
            {
                ShowError("No table was selected for reservation.");
                pnlForm.Visible = false;
            }
        }

        protected void btnSubmitReservation_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;

            if (!int.TryParse(Request.QueryString["table"], out int tableId))
            {
                ShowError("Invalid table selection.");
                return;
            }

            if (!int.TryParse(txtNumberOfGuests.Text, out int guests) || guests <= 0)
            {
                ShowError("Please enter a valid number of guests.");
                return;
            }

            if (guests > CurrentTableCapacity)
            {
                ShowError($"This table can only accommodate up to {CurrentTableCapacity} guests.");
                return;
            }

            if (!DateTime.TryParse($"{txtReservationDate.Text} {txtReservationTime.Text}", out DateTime requestedTime))
            {
                ShowError("Please enter a valid date and time.");
                return;
            }

            if (requestedTime < DateTime.Now)
            {
                ShowError("Reservation time cannot be in the past.");
                return;
            }

            // Check Availability (2 hours default duration)
            bool isAvailable = _reservationRepo.IsTableAvailable(tableId, requestedTime);
            if (!isAvailable)
            {
                ShowError("Sorry, this table is already booked near that time. Please try a different time or date.");
                return;
            }

            // Create model
            Reservation res = new Reservation
            {
                TableId = tableId,
                GuestName = txtGuestName.Text.Trim(),
                GuestEmail = txtGuestEmail.Text.Trim(),
                GuestPhone = txtGuestPhone.Text.Trim(),
                ReservationDate = requestedTime,
                EndTime = requestedTime.AddHours(2), // Standard 2 hour booking
                NumberOfGuests = guests,
                Notes = txtNotes.Text.Trim(),
                Status = "Pending",
                CreatedAt = DateTime.Now
            };

            int newResId = _reservationRepo.CreateReservation(res);

            if (newResId > 0)
            {
                // Success
                pnlForm.Visible = false;
                pnlSuccess.Visible = true;
                lblSuccess.Text = $"Thank you, {res.GuestName}! Your reservation for {guests} guests on {requestedTime:f} has been submitted (ID: {newResId}).";
            }
            else
            {
                ShowError("An error occurred while processing your reservation. Please try again.");
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            pnlError.Visible = true;
        }
    }
}