
public delegate void BusHandler();
public delegate void BusHandler<T>(T t);
public delegate void BusHandler<T, U>(T t, U u);
