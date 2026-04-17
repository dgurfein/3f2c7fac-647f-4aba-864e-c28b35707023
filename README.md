# GurfeinD.ArrayProcessor
A modular .NET 8 command-line Array Processor that supports pluggable use-case
---

## Table of Contents
- [Description](#description)
- [Use Cases](#use-cases)
- [Installation](#installation)
- [Usage](#usage)
- [Testing](#Testing)

---
## Description
- The solution was built as a command line tool (Array processor) so it can be executed as a program.
- A second approach with a standalone static function is also available, but can only be executed via the test project at this stage.
- The two approaches using different algorithm:
- The Array Processor is using a recursive approach where the function is a simple scan of the array from start to end. In practice both are the same, recursive approach a bit more elegant, simple traditional scan is easier to read. Performances expected to be identical.
- The Array Processor is generic command line tool that receives a use case name and input, it processes the input as per the use case and prints the result. In this case there is a single use case which is the LongestIncreasingSequence.
- The solution follows SOLID and Clean Architecture principles.
---
## Use Cases

### 1. LongestIncreasingSequence
- **Name:** LongestIncreasingSequence (default)
- **Description:** Given an array of integers, return the longest incresing sequence sub array within the input array.
- **Input:** An array of integers number seperated by space (multiple spaces are tolerated, but other non numeric characters considered as error). Array must contain at least one integer (when executed from command line)
- **Output:** Return the longest increasing sequence within the array, if more than one found with same length, first one is returned
- **Examples:**

```
Input: 3 0 1

Output: 0 1

Input: 90 -66 4 20 33 5 7 0 1

Output: -66 4 20 33
```
---
## Installation

1. **Download the ZIP**  
- From the GitHub Release page: `ArrayProcessor.zip`

2. **Extract the ZIP**  
- Extract to any folder on your system.

3. **Run the program**  
- Open a terminal/command prompt in the extracted folder and run:

```bash
ArrayProcessor.exe
---
## Usage

ArrayProcessor [-u <UseCaseName>] <input>  
- `-u <UseCaseName>` → (optional) the use case to run; if omitted, the default use case is executed.  
- `<input>` → the raw input for the use case.
---
## Testing
The solution holds a unit test project ArrayProcessor.Test that executes all provided tests. 
It can be invoked on a local repository clone with 'dotnet test' 
