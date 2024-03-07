#!/bin/sh
dotnet tool install -g dotnet-reportgenerator-globaltool

dotnet test --collect:"XPlat Code Coverage"
reportgenerator "-reports:./TestResults/**/*.cobertura.xml" "-targetdir:TestResults/" "-reporttypes:HTML;"

start TestResults/index.html