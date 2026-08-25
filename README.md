# amitkuzi.utils

A lightweight C#/.NET utility library centered around **TaskTimer** — a simple way to execute an action repeatedly with configurable delays, timeout, cancellation, and completion handling.

## Features

* ⏱️ Configurable repeat interval
* 🚀 Optional initial delay
* ⏳ Optional execution timeout
* 🛑 Cancellation via `CancellationTokenSource`
* ✅ Completion callback
* 🔧 Supports both `TimeSpan` and millisecond-based configuration

## Example

```csharp
var cancellation = TaskTimer.Run(
    action: () => DoWork(),
    repeatWait: TimeSpan.FromSeconds(1),
    firstWait: TimeSpan.FromSeconds(2),
    timeout: TimeSpan.FromMinutes(1),
    onFinish: task =>
    {
        Console.WriteLine("Timer finished");
    });
```

The returned `CancellationTokenSource` can be used to stop the timer:

```csharp
cancellation.Cancel();
```

## Project Structure

* `amitkuzi.TPLExtention` — TaskTimer implementation
* `TaskTimerTester` — console application demonstrating timer behavior

## Technology

* C#
* .NET
* Task Parallel Library (TPL)
* `async` / `await`
* `CancellationToken`

Originally created as a small reusable .NET utility for recurring background operations.
