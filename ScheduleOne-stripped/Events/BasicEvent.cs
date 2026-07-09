namespace ScheduleOne.Events;
public delegate void BasicEvent();
public delegate void BasicEvent<T>(T param);