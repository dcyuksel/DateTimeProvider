# DateTimeProvider

**Full article:** [The Clean Way to Test DateTime Logic in .NET](https://medium.com/@dnzcnyksl/the-clean-way-to-test-datetime-logic-in-net-6e582a7cd92b)

A clean, lightweight way to handle **date/time logic** in .NET without calling `System.DateTime` directly.  
`IDateTimeProvider` exposes `Now`, `Today`, and `UtcNow`; `DateTimeProvider` implements it on top of `.NET 8`’s `TimeProvider`.

## What the code demonstrates

- **Trial** — checks whether a 14‑day trial is still active and how many days have passed.
- **BusinessHours** — determines if the current moment falls within weekday 09:00–17:00.
- **Subscription** — evaluates expiration and calculates days remaining.

Each scenario reads time through `IDateTimeProvider`, keeping business logic simple and predictable.

## What the tests prove

- Time is **frozen** using `FakeTimeProvider` via small helpers, so each test runs with an exact date/time.
- Results are deterministic and independent of the machine clock (no sleeps, no flakiness).

## Run the tests

```bash
dotnet test
```
