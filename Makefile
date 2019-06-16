all: Steamworks.NET.dll native

Steamworks.NET.dll:
	xbuild "./Steamworks.NET.sln"
native:
	$(MAKE) -C native

#install:

.PHONY: clean

clean:
	rm -rf bin obj
	$(MAKE) -C native clean
