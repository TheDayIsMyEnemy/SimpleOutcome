# Simple Operation Result

## Example

```csharp
// Create a new successful Result with an optional message
var operationOne = Result.Success().WithMessage("Operation successfully completed.");

// Create a new failure Result, provide custom data, and chain multiple messages
var operationTwo = Result
    .Failure(new ImaginaryTaskObject())
    .WithMessage("{0} operation failed", nameof(ImaginaryTaskObject))
    .WithMessage("Previous operation status: {0}", operationOne.ToString());

// Retrieve the instance of ImaginaryTaskObject from the result
var data = operationTwo.Data;

// Create a new successful Result and add a list of informative messages
Result
    .Success()
    .WithListOf($"{nameof(operationOne)} Status: {operationOne.IsSuccess}",
                $"{nameof(operationTwo)} Data: {data.ToString()}");

```
