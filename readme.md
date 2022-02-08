# Market Assistant
The market assistant application is a simple dotnet 6 API and Angular 13 front end that simulates an application that a marketing manager at a publishing company might use.

For the Business Requirements, please see [Market Assistant Business Requiements.pdf](https://github.com/blusk0/market-assistant/blob/main/Market%20Assistant%20Business%20Requirements.pdf)

## Prerequisites
In order to run this application, it is highly recommended that you install
- [The dotnet 6 SDK](https://download.visualstudio.microsoft.com/download/pr/343dc654-80b0-4f2d-b172-8536ba8ef63b/93cc3ab526c198e567f75169d9184d57/dotnet-sdk-6.0.101-win-x64.exe)
- [The latest LTS version of NodeJS](https://nodejs.org/dist/v16.13.2/node-v16.13.2-x64.msi)

## Application Structure
The Angular application is located in the `client` folder, and the dotnet 6 solution is located in the `server` folder.

The `launchSettings.json` file has `https://localhost:7294/` as the URL Root for the Web Application. If you change this for any reason, be sure to update the `URL_ROOT` constant appropriately in `client/src/app/core/constants/core-constants.ts`. 

## Running the Client Application
If your NodeJS version is installed properly, starting the client application should be as simple as navigating to the `client` folder in your terminal of choice, and running `npm i` to install dependencies (first time/if adding a dependency only), followed by `npm start`. This will launch the Angular development server on the standard port, at `http://localhost:4200/`.

## Running the Server Application
If you are using Visual Studio 2022 (previous versions do not work with dotnet 6), simply open the solution file at `server/MarketAssistant.sln`. Visual Studio should restore packages automatically, and you can then launch the web application.

If you prefer to use the dotnet CLI, navigate to the `server` folder, then run `dotnet restore`, followed by `dotnet run --project .\MarketAssistant.Web\MarketAssistant.Web.csproj`.

## Database
This simple test application uses an In Memory Database that is accessed via Entity Framework Core; No database solutions need to be installed to run the application.