# Introduction 
MauiAppInsights is a .NET MAUI App, written in .NET 8 taking the standard template, modifying it with the MVVM Pattern, and logging to Azure Application Insights.

## References
https://vladislavantonyuk.github.io/articles/Adding-Application-Insights-to-.NET-MAUI-Application/

## Mobile App (MauiAppInsights)
This is based on the Visual Studio .NET MAUI modified to us the MVVM pattern.

# Getting Started
## Mobile App
 - How to contribute to the App
    - Cloning the repository using git clone "https://AzMobileDevOps@dev.azure.com/AzMobileDevOps/ProcessTransformation/_git/AppInsightsPoC"
    - Create a new branch. Branch name should be the card number for which you are amending the code changes with prefix as [U/T/B], U refers to User story, T refers to Task, B refers to Bug. For example: If you are working on User story 163 then branch name should be U0163-[XYZ Details]
 - Software dependencies
    - Visual Studio 2022
    - Android SDK
    - .NET 8
## Azure Application Insights
### Application Insights Setup
 - Login to https://portal.azure.com/
 - Create a new resource, selecting or searching for Application Insights
 - Add details, which likely includes a new resource group for this PoC
 - Once the Application Insights instance is created, navigate to the overview page to copy the Connection String
 - Use this connection string in the BuildApplicationInsights method found in MauiProgram.cs.
    - You may also test this connection string in the PowerShell script, powershellTest.ps1, included in the folder of this project. 
    ```
        # Info: Provide either the connection string or ikey for your Application Insights resource
        $ConnectionString = "your connection string here"
    ```
## How to Test
### Mobile App
 - Run the app in an emulator.
 - click on the button on the MainPage, which will trigger the RelayCommand in the MainPageViewModel.
### Azure
 - Navigate to the Azure Portal
 - Select the Application Insights instance 
 - Select **Transaction search**
 - Click on the **See all data in the last 24 hours** button. After a delay all of the events logged in the mobile app will appear in the list.
    
# Build Strategy
- Clean the solution before initiating a build/re-build.
- Few checks to be done to mitigate common build issues:
    - Make sure only Android target is enabled for the solution. It can be checked here Solution -> Properties -> Application
    - Android Targets
        - Target Android Framework  as Android 13.0 (API Level 33)
        - Minimum Target Android Framework as Android 11.0 (API Level 30)
 
# How to Contribute
1. Get Azure repo access by dropping mail to vinay.karnakanti@techwave.net, Subject : AIT MSS Site Survey mobile code repository access.
1. Raise PR. Once code is reviewed and PR is approved, complete the PR.
1. Delete the work branch and mark respective work item as completed.
