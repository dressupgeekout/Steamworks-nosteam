.PHONY: clean

all: Steamworks.NET.dll native

Steamworks.NET.dll: Steamworks.NET.sln
	cd Steamworks.NET && xbuild Steamworks.NET.sln

native:
	$(MAKE) -C native

#install:


clean:
	rm -rf bin obj
	$(MAKE) -C native clean
