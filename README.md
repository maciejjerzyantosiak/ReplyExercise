# Reply Exercise - recruitment project
## Introduction
Welcome to the Reply recruitment project, dedicated to automation testing with a focus on ensuring the flawless operation of CRM System Web application. 
    
# Running the Project locally on windows
## Prerequisites:
.NET 6.0.x, 7.0.x or 8.0.x is installed.

  1. Run **dotnet build ReplyExercise.sln**
  2. Run **dotnet test ReplyExercise.sln**

## Default browser is Chrome.

Project can also run on selenium server. To run on selenium server, user has to change config file.
  1. key: **defaultBrowser** to: **remote**
  2. key: **seleniumServerUrl** to: **valid selenium server url**

## Github actions are configured, so build and tests are executed on every push.
Link to builds: https://github.com/maciejjerzyantosiak/ReplyExercise/actions
