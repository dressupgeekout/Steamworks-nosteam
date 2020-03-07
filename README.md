Steamworks.NET-nosteam
======================

Drop-in replacement for several Steamworks wrappers, to run without Steam client present,
e.g. if running on an operating system that doesn't feature a Steam client.

Why?
----

A number of games are made largely platform-independent, but use try to connect
to Steamworks and error out if no Steam client is present. This project builds
several stub libraries that can be dropped in as a replacement, so that the
parent program can keep running.

How to Build
------------

```
$ make all
```

This will build the following files:
* `Steamworks.NET/bin/Steamworks.NET.dll`
* `native/libSteamworksNative.so.X.Y`
* `wrapper/libsteamwrapper.so.X.Y`
* `hlsteam/steam.hdll`
* `cestub/libcestub.so.X.Y`

How to Install
--------------

```
# make install
```

This will install the files in `$(PREFIX)/lib/steamworks-nosteam/`.

GitHub repo: https://github.com/rfht/Steamworks.-nosteam
