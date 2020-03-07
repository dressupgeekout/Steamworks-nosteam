CXX ?=	c++
CFLAGS ?= -O2 -pipe
LOCALBASE ?=	/usr/local

SRC = native/cloud.o native/common.o native/controller.o native/friends.o native/gameserver.o \
	native/matchmaking.o native/networking.o native/stats.o native/ugc.o

all: $(SRC)
	$(CXX) $(LDFLAGS) -lhl -L $(LOCALBASE)/lib -shared -o steam.hdll $(SRC)

.SUFFIXES : .cpp .o

.cpp.o :
	$(CXX) $(CFLAGS) -std=c++0x -I src -I native/include -fPIC -I $(LOCALBASE)/include -o $@ -c $<
	
clean_o:
	@rm -f $(SRC)

clean: clean_o
	@rm -f steam.hdll

