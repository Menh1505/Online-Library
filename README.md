# Online Book Store (DOESN'T ACCOMPLISH)
The Online Book Store project aims to develop a web application that serves as a platform for users to browse, search, and purchase books online. The project consists of both frontend and backend components to provide a seamless user experience.

# Install
## Prerequisites
- Clone the eShop repository: https://github.com/Menh1505/Online-Library
- [download SQL server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

#### Windows with Visual Studio
- Install [Visual Studio 2022 version 17.10 or newer](https://visualstudio.microsoft.com/vs/).
  - Select the following workloads:
    - `ASP.NET and web development` workload.
    - `.NET Aspire SDK` component in `Individual components`.
    - Optional: `.NET Multi-platform App UI development` to run client apps

#### Mac, Linux, & Windows without Visual Studio
- Install the latest [.NET 8 SDK](https://dot.net/download?cid=eshop)
- Install the [.NET Aspire workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling?tabs=dotnet-cli%2Cunix#install-net-aspire) with the following commands:
```powershell
dotnet workload update
dotnet workload install aspire
dotnet restore eShop.Web.slnf
```

> Note: These commands may require `sudo`

- Optional: Install [Visual Studio Code with C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started)
- Optional: Install [.NET MAUI Workload](https://learn.microsoft.com/dotnet/maui/get-started/installation?tabs=visual-studio-code)

> Note: When running on Mac with Apple Silicon (M series processor), Rosetta 2 for grpc-tools. 

> Open SqlServer and run [script](/OnlineLibrary.sql)
### Running the solution

> [!WARNING]
> Remember to ensure that change the connection string to your localhost in [appsetting](/appsettings.json)

* (Windows only) Run the application from Visual Studio:
 - Open the `OnlineLibrary.sln` file in Visual Studio
 - Ensure that `OnlineLibrary.csproj` is your startup project
 - Hit Ctrl-F5 to launch Aspire

* Or run the application from your terminal:
```powershell
dotnet run --project OnlineLibrary.csproj
```
> You may need to install ASP.NET Core HTTPS development certificates first, and then close all browser tabs. Learn more at https://aka.ms/aspnet/https-trust-dev-cert

# About Web
## Purpose
- Selling Books Online: Users can explore a wide range of books and make purchases conveniently.
- Maintaining Selling History: The system keeps track of book sales history.
- Adding and Managing Books: Admins can add new books and manage the existing inventory.
- User-Friendly Interface: The website is designed to be user-friendly and intuitive.
  
## Technologies Used
### Front-End Development:
- HTML
- CSS
- JavaScript
### Back-End Development:
- C# 
- dotnet
- entity framework core
- identity framework
### Database:
- SQL server 2022 express
- SQL server manager studio 20
## Admin Access
### Admins have the following privileges:
* Manage Books (CRUD)
* Manage Categories (CRUD)
* Manage Account (CRUD)
* Manage Invoice (CRUD)
- User Access

### Users can perform the following actions:
- Create a new account or register
- Log in
- View available books
- Select books to buy
- Add books to the shopping cart
- Remove books from the shopping cart
- Update book quantities
- View purchased books list
- View transaction history
- Get payment receipts
- Update profile information
- Change or update passwords
- Log out
  
## Screenshots

## Debug and feedback

## Installation
1. Clone this repository.
2. Install required packages using `npm install`.
3. Start the server with `npm start`.

## Contributing
Contributions are welcome! Please follow our contribution guidelines.

## Contact
- facebook: https://www.facebook.com/Menhythien
- gmail: dinhthienmenh1505@gmail.com
  
Feel free to replace the placeholder content with actual details related to your project. Good luck with your online book store web application! 📚🌐
