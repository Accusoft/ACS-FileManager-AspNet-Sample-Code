# Accusoft Services File Manager Sample - AspNet

This is a sample application demonstrating how to use the Accusoft Services file manager in .NET using C#.

## Overview

This sample application uses .NET vNext, but the code for the request should be compatible with older versions of .NET.

## Configuration

The sample application requires an Accusoft Services API key in order to generate an OAuth token.
You can obtain an API key by signing up at http://www.accusoft.com/products/accusoft-cloud-services/portal/.

## Setup

Install dnvm (.NET Version Manager), dnx (.NET Execution Environment), dnu (.NET Development Utilities), and Kestrel (cross-platform .NET HttpServer).
Verify that these commands work in a terminal:
```
dnvm list
dnu list
dnx --version
```

## Usage

To run the sample application, navigate to the project directory and run:

```
dnu restore
dnx web
```

Now you can visit http://localhost:5000 to see the file manager in action.

## Troubleshooting

When you run:
```
dnu restore
```
and then
```
dnu list
```
make sure none are listed in red with "Unresolved" at the end.
