using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DateTime
{
    [SerializeField] private int _year;
    [SerializeField] private int _month;
    [SerializeField] private int _day;
    [SerializeField] private int _hours;
    [SerializeField] private int _minutes;
    [SerializeField] private int _seconds;

    private List<Timer> timers;

    public int Year
    {
        get { return _year; }
        set { _year = Math.Abs(value); OnYearChanged?.Invoke(); }
    }

    public int Month
    {
        get { return _month; }
        set
        {
            _month = Math.Abs(value);
            OnMonthChanged?.Invoke();
            if (_month >= 12)
            {
                for (; _month >= 12; _month -= 12)
                    Year++;
            }
        }
    }

    public int Day
    {
        get { return _day; }
        set
        {
            _day = Math.Abs(value);
            OnDayChanged?.Invoke();
            if (_day >= 30)
            {
                for (; _day >= 30; _day -= 30)
                    Month++;
            }
        }
    }

    public int Hours
    {
        get { return _hours; }
        set
        {
            _hours = Math.Abs(value);
            OnHourChanged?.Invoke();
            if (_hours >= 24)
            {
                for (; _hours >= 24; _hours -= 24)
                    Day++;
            }
        }
    }

    public int Minutes
    {
        get { return _minutes; }
        set
        {
            _minutes = Math.Abs(value);
            OnMinuteChanged?.Invoke();
            if (_minutes >= 60)
            {
                for (; _minutes >= 60; _minutes -= 60)
                    Hours++;

            }
        }
    }

    public int Seconds
    {
        get { return _seconds; }
        set
        {
            _seconds = Math.Abs(value);
            OnSecondChanged?.Invoke();
            if (_seconds >= 60)
            {
                for (; _seconds >= 60; _seconds -= 60)
                    Minutes++;
            }

        }
    }

    public DayTime DayPart
    {
        get
        {
            if (Hours <= 9 && Hours > 3) return DayTime.Morning;
            else if (Hours <= 16 && Hours > 9) return DayTime.Day;
            else if (Hours <= 21 && Hours > 16) return DayTime.Evening;
            else if ((Hours <= 23 && Hours > 21) || (Hours >= 0 && Hours <= 3)) return DayTime.Night;
            else return DayTime.Night;
        }
    }

    public event Action OnSecondChanged;
    public event Action OnMinuteChanged;
    public event Action OnHourChanged;
    public event Action OnDayChanged;
    public event Action OnMonthChanged;
    public event Action OnYearChanged;

    public DateTime(int hour, int minutes = 0, int seconds = 0, int day = 1, int month = 1, int year = 2022)
    {
        _year = 0;
        _month = 0;
        _day = 0;
        _hours = 0;
        _minutes = 0;
        _seconds = 0;

        Day = day;
        Month = month;
        Year = year;
        Seconds = seconds;
        Hours = hour;
        Minutes = minutes;
    }

    public static DateTime Zero = new DateTime(0, 0, 0);

    public static bool operator > (DateTime a, DateTime b)
    {
        if (a.Year > b.Year) return true;
        else if (a.Year < b.Year) return false;

        if (a.Month > b.Month) return true;
        else if (a.Month < b.Month) return false;

        if (a.Day > b.Day) return true;
        else if (a.Day < a.Day) return false;

        if (a.Hours > b.Hours) return true;
        else if (a.Hours < a.Hours) return false;

        if (a.Minutes > b.Minutes) return true;
        else if (a.Minutes < a.Minutes) return false;

        if (a.Seconds > b.Seconds) return true;
        else if (a.Seconds < a.Seconds) return false;

        return false;
    }

    public static bool operator < (DateTime a, DateTime b)
    {
        return !(a > b) && a != b;
    }

    public static bool operator ==(DateTime a, DateTime b)
    {
        return a.Year == b.Year && a.Month == b.Month && a.Day == b.Day && a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds == b.Seconds;
    }

    public static bool operator !=(DateTime a, DateTime b)
    {
        return a.Year != b.Year || a.Month != b.Month || a.Day != b.Day || a.Hours != b.Hours || a.Minutes != b.Minutes || a.Seconds != b.Seconds;
    }

    public static bool operator >=(DateTime a, DateTime b)
    {
        return a > b || a == b;
    }
    public static bool operator <=(DateTime a, DateTime b)
    {
        return a < b || a == b;
    }
}

public enum DayTime
{
    Morning,
    Day,
    Evening,
    Night
}
