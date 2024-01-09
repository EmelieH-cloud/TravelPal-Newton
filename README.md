MainWindow
Purpose
Splash screen with the option to log in with a username and password or create a new user.

Functionality

Large label "TravelPal" with Arial font.
Input fields to enter a username and password.
"Sign In" button to log in and close the MainWindow.
If the password or username is incorrect, display a warning message.
"Register" button to create a new user and close the MainWindow.
RegisterWindow
Purpose
Ability to create a new user with a username, password, and country.

Functionality

Input fields to enter a username and password.
ComboBox to choose the user's country.
"Register" button to create a user, go back to MainWindow, and close RegisterWindow.
If the username is already taken, display a warning message.
TravelsWindow
Purpose
Add, remove, and overview travels.

Functionality

When this page opens, the previous page should close.
Display the logged-in user's username.
"User" button to open UserDetailsWindow.
"Add Travel" button to open the AddTravelWindow.
List to overview all added travels with minimal information (destination country).
"Details" button to open the TravelDetailsWindow for a specific selected travel.
"Remove" button to delete a specific selected travel.
If no travel is selected and the user presses "Details" or "Remove," show a warning that they must first select a travel.
Admin-User should see/remove all travels added by all users.
Info button to pop up a small window explaining how to use the app and information about TravelPal as a company.
"Sign Out" button to log out, close TravelsWindow, and return to MainWindow.
TravelDetailsWindow
Purpose
View a detailed description of a travel and the ability to edit it.

Functionality

Details of a travel displayed in locked input fields (city, destination country, number of travelers, type of trip, and additional details like meeting details or all-inclusive).
Start and end date of the travel and total duration in days.
Ability to "unlock" input fields by clicking an "Edit" button, then fill in new details for the travel and save them by clicking "Save."
If all new details are correctly filled, overwrite the travel, close TravelDetailsWindow, and open TravelsWindow.
AddTravelWindow
Purpose
Ability to create a new travel with a packing list.

Functionality

Input fields to fill in all details for the new travel (city, country, and number of travelers).
ComboBox to choose the country for the travel.
ComboBox to choose "Work Trip" or "Vacation."
If "Vacation" is chosen, display a CheckBox for "All Inclusive."
If "Work Trip" is chosen, display an input field to add "Meeting Details."
All input fields must be filled to save the travel; otherwise, show a warning.
List containing a packing list for the new travel.
Input fields to fill in the name of a new travel item to add to the packing list.
"Add Item" button to add an item to the new travel's packing list, including quantity.
CheckBox to choose whether the added item is a "Travel Document."
If "Travel Document" is checked, display another CheckBox with the text "Required" instead of the quantity input box.
If the travel is to a non-EU country and the user resides in the EU, automatically add a "Passport" (with required set to true) to the packing list.
If the travel is to another EU country and the user resides in the EU, automatically add a "Passport" (with required set to false) to the packing list.
If the user resides outside the EU, regardless of the destination country, automatically add a passport (with required set to true) to the packing list.
