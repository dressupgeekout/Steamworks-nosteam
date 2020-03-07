CC ?=		cc
CFLAGS ?=	-O2 -pipe
LD ?=		ld
RM =		rm -f
TARGET_LIB =	libcestub.so
SRCS =		cestub.c
NATIVE_MAJOR ?=	0
NATIVE_MINOR ?=	0

.PHONY: all
all: libcestub.so

libcestub.so: cestub.o
	$(CC) $(LDFLAGS) -shared \
		-o libcestub.so.$(NATIVE_MAJOR).$(NATIVE_MINOR) \
		cestub.o

CommunityExpressSW.o:
	$(CC) $(CFLAGS) -fPIC -c cestub.c

.PHONY: clean
clean:
	@$(RM) libcestub.so cestub.o
