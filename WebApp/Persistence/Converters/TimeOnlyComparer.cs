using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApp.Persistence.Converters;

public class TimeOnlyComparer : ValueComparer<TimeOnly>
{
    public TimeOnlyComparer() : base(
        (x, y) => x.Ticks == y.Ticks,
        timeOnly => timeOnly.GetHashCode())
    { }
}