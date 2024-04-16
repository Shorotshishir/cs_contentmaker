# Content Maker

A simple tool to make generic content definition from any number of files. This tool will take directory path as a parameter and generate a json file as output where all files in that directory will be defined in a generic way.

## Tech

- dotnet 8
- linux

## How to build

This tool was made in linux environment, switch the `-r` flag based on OS. [Official rid Reference](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog)

```cli
dotnet publish -r linux-x64 --self-contained
```

rename the built file to contentmaker for easier access

## How to Add to path

- open file browser as superuser
- copy the `contentmaker` to `usr/local/bin/`
- restart terminal if already open

## How to Use

command below will make a "content_data.json" on the current directory

```cli
contentmaker .
```
