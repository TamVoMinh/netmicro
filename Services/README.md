## Serilog Levels Visible Map

✓ → Mean visible

|               | FATAL | ERROR | WARN  | INFO  | DEBUG | TRACE | Method |
|--------------:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|-------|
| OFF           |       |       |       |       |       |       |       |
| Fatal         | ✓     |       |       |       |       |       |LogCritical   |
| Error         | ✓     | ✓     |       |       |       |       |LogError      |
| Warning       | ✓     | ✓     | ✓     |       |       |       |LogWarning    |
| Information   | ✓     | ✓     | ✓     | ✓     |       |       |LogInformation|
| Debug         | ✓     | ✓     | ✓     | ✓     | ✓     |       |LogDebug      |
| Verbose       | ✓     | ✓     | ✓     | ✓     | ✓     | ✓     |LogTrace      |
