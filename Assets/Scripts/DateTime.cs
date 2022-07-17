using System;
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

    public int Year
    {
        get { return _year; }
        set => _year = Math.Abs(value);
    }

    public int Month
    {
        get { return _month; }
        set
        {
            _month = Math.Abs(value);
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
            OnHourChanged?.Invoke();
            _hours = Math.Abs(value);
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
            if (_minutes >= 60)
            {
                for (; _minutes >= 60; _minutes -= 60)
                    Hours++;
                
            }
        }
    }

    public int Seconds { get { return _seconds; }
        set
        {
            _seconds = Math.Abs(value);
            if(_seconds >= 60)
            {
                for(;_seconds >= 60; _seconds -= 60)
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

    public event Action OnHourChanged;

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
}

public enum DayTime
{
    Morning,
    Day,
    Evening,
    Night
}
